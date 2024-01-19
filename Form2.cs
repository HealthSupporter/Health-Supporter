#nullable disable
using WMPLib;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ExerciseApp
{
    public partial class Form2 : Form
    {
        private bool performClose = false;
        private decimal currentStopHour = 0;
        private decimal currentStopMinute = 0;
        private decimal currentStopSecond = 0;
        private Random randomIndex = new Random();
        private bool pause_for_reason = false;

        private string[] videoFiles;
        private int playingIndex = 0;
        private int maxPlayingIndex = 0;


        public Form2()
        {
            ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
            objKeyboardProcess = new LowLevelKeyboardProc(captureKey);
            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);
            InitializeComponent();
        }

        private ExerciseApp mainForm = new();
        public Form2(Form callingForm)
        {
            ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
            objKeyboardProcess = new LowLevelKeyboardProc(captureKey);
            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);

            mainForm = (ExerciseApp)callingForm;
            videoFiles = [.. mainForm.vidPath];
            maxPlayingIndex = videoFiles.Length;
            
            InitializeComponent();
        }

        private double getDuration(string video)
        {
            double dur;
            double vidDur = getVideoDuration(video);
            double approDur = (double)((mainForm.currentStopHourConfig * 3600) + (mainForm.currentStopMinuteConfig * 60) + mainForm.currentStopSecondConfig);
            if (mainForm.continuePlay)
            {
                dur = double.Max(vidDur, approDur);
            } else
            {
                dur = vidDur;
            }

            return dur;
        }

        private string nextVideo()
        {
            if (mainForm.multiple_videos && mainForm.num_videos > 1)
            {
                if (mainForm.play_random)
                {
                    playingIndex = randomIndex.Next(1, maxPlayingIndex + 1);
                }
                else
                {
                    playingIndex = maxPlayingIndex % (playingIndex + 1);
                }
            } else
            {
                playingIndex = 0;
            }
            return videoFiles[playingIndex];
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            currentStopHour = mainForm.currentStopHourConfig;
            currentStopMinute = mainForm.currentStopMinuteConfig;
            currentStopSecond = mainForm.currentStopSecondConfig;

            Rectangle resolution = mainForm.screenResolution;
            panel1.Bounds = resolution;
            axWindowsMediaPlayer1.Bounds = resolution;
            axWindowsMediaPlayer1.URL = nextVideo();
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.Ctlcontrols.next();

            mainLabel.Location = new Point((resolution.Width / 2) - (mainLabel.Bounds.Width / 2), 20);

            double dur = getDuration(axWindowsMediaPlayer1.URL);
            timer1.Interval = Convert.ToInt32(dur) * 1000;
            timer2.Interval = 1000;

            // var result = MessageBox.Show(
            //    "Đã đến giờ nghỉ. Bạn có muốn tập thể dục không?", "Tập thể dục", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // if (result != DialogResult.Yes)
            // {
            //    performClose = true;
            //    this.Close();
            //    return;
            // }

            axWindowsMediaPlayer1.Ctlenabled = false;
            axWindowsMediaPlayer1.uiMode = "none";

            waitPictureBox.Visible = false;
            waitPictureBox.Bounds = resolution;
            waitPictureBox.Image = Image.FromFile(mainForm.processPath + "\\Asset\\panel.png");
            
            waitPictureBox.Load(mainForm.processPath + "\\Asset\\panel.png");
            waitPictureBox.Location = new Point(-100, 0);
            waitPictureBox.Update();
            // Thread.Sleep(5000);
            waitPictureBox.Visible = false;

            timer1.Start();
            timer2.Start();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private double getVideoDuration(string FileName)
        {
            WindowsMediaPlayer wmp = new WindowsMediaPlayerClass();
            IWMPMedia media_info = wmp.newMedia(FileName);
            return media_info.duration;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop(); timer2.Stop();
            if (currentStopHour >= 0 && currentStopMinute >= 0 && currentStopSecond > 0)
            {
                timer1.Interval = Convert.ToInt32(getDuration(axWindowsMediaPlayer1.URL)) * 1000;
                pauseVid_and_ask();
            }

            // axWindowsMediaPlayer1.Ctlcontrols.pause();
            // performClose = true;
            // this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            currentStopSecond--;
            if (currentStopSecond < 0)
            {
                currentStopMinute--;
                currentStopSecond = 59;
            }
            if (currentStopMinute < 0)
            {
                currentStopHour--;
                currentStopMinute = 0;
                currentStopSecond = 0;
            }
            if (currentStopHour < 0)
            {
                currentStopHour = 0;
                currentStopMinute = 0;
                currentStopSecond = 0;
                pauseVid_and_ask();
            }
        }

        private void pauseVid_and_ask()
        {
            timer1.Stop();
            timer2.Stop();
            pause_for_reason = true;
            axWindowsMediaPlayer1.Ctlcontrols.pause();

            var result = MessageBox.Show(
                string.Format("Đã hết {0} giờ {1} phút {2} giây. Bạn có muốn tiếp tục tập?", mainForm.currentStopHourConfig, mainForm.currentStopMinuteConfig, mainForm.currentStopSecondConfig),
                "Hết thời gian",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
                );
            if (result == DialogResult.Yes)
            {
                currentStopHour = mainForm.currentStopHourConfig;
                currentStopMinute = mainForm.currentStopMinuteConfig;
                currentStopSecond = mainForm.currentStopSecondConfig;
                timer1.Start();
                timer2.Start();
                pause_for_reason = false;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            } else
            {
                performClose = true;
                this.Close();
            }
        }

        private void Form2_Closing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown || performClose == true)
            {
                UnhookWindowsHookEx(ptrHook);
                return;
            }

            if (this.DialogResult == DialogResult.Cancel)
            {
                MessageBox.Show("BẠN KHÔNG THỂ TẮT KHI CHƯA HẾT VIDEO!!");
                e.Cancel = true;
            }
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            switch (axWindowsMediaPlayer1.playState)
            {
                case WMPPlayState.wmppsMediaEnded:
                        axWindowsMediaPlayer1.URL = nextVideo();
                        axWindowsMediaPlayer1.Ctlcontrols.next();
                        axWindowsMediaPlayer1.Ctlcontrols.play();
                    break;
                default:
                    if (!pause_for_reason) axWindowsMediaPlayer1.Ctlcontrols.play();
                    break;
            }
        }

        /* Code to Disable WinKey, Alt+Tab, Ctrl+Esc Starts Here */
        /* https://itecnote.com/tecnote/c-how-to-suppress-task-switch-keys-winkey-alt-tab-alt-esc-ctrl-esc-using-low-level-keyboard-hook-in-c/ */
        // Structure contain information about low-level keyboard input event 
        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public Keys key;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr extra;
        }
        //System level functions to be used for hook and unhook keyboard input  
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string name);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern short GetAsyncKeyState(Keys key);
        //Declaring Global objects     
        private IntPtr ptrHook;
        private LowLevelKeyboardProc objKeyboardProcess;

        private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT) Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));

                // Disabling Windows keys 

                if (objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin || objKeyInfo.key == Keys.Tab && HasAltModifier(objKeyInfo.flags) || objKeyInfo.key == Keys.Escape && (ModifierKeys & Keys.Control) == Keys.Control)
                {
                    return (IntPtr)1; // if 0 is returned then All the above keys will be enabled
                }
            }
            return CallNextHookEx(ptrHook, nCode, wp, lp);
        }

        bool HasAltModifier(int flags)
        {
            return (flags & 0x20) == 0x20;
        }
        /* Code to Disable WinKey, Alt+Tab, Ctrl+Esc Ends Here */
    }
}
