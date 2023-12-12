using ExerciseApp.Properties;
using Leadtools.Multimedia;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Timers;
using WMPLib;

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


        public Form2()
        {
            KeyboardLLProcedure = new HookProc(KeyboardLLProc);
            hHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardLLProcedure, (IntPtr)0, 0);
            InitializeComponent();
        }

        private ExerciseApp mainForm = new();
        public Form2(Form callingForm)
        {
            KeyboardLLProcedure = new HookProc(KeyboardLLProc);
            hHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardLLProcedure, (IntPtr)0, 0);
            mainForm = (ExerciseApp)callingForm;
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
            int index = mainForm.multiple_videos && mainForm.play_random && mainForm.num_videos > 1 ? randomIndex.Next(1, mainForm.vidPath.Count + 1) : 0;
            return mainForm.vidPath[index];
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

            mainLabel.Location = new Point(resolution.Width / 2 - mainLabel.Bounds.Width / 2, 20);
            
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

            axWindowsMediaPlayer1.Ctlcontrols.pause();
            performClose = true;
            this.Close();
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
            if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                UnhookWindowsHookEx(hHook);
                return;
            }
            if (performClose)
            {
                UnhookWindowsHookEx(hHook);
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
                    if (mainForm.play_random)
                    {
                        axWindowsMediaPlayer1.URL = nextVideo();
                        axWindowsMediaPlayer1.Ctlcontrols.play();
                    }
                    break;
                default:
                    if (!pause_for_reason) axWindowsMediaPlayer1.Ctlcontrols.play();
                    break;
            }
        }

        /* Code to Disable WinKey, Alt+Tab, Ctrl+Esc Starts Here */
        public const int WH_KEYBOARD_LL = 13;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct MSLLHOOKSTRUCT
        {
            public Point pt;
            public int mouseData;
            public int flags;
            public int time;
            public uint dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct KBDLLHOOKSTRUCT
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public uint dwExtraInfo;
        }

        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        static int hHook = 0;
        HookProc KeyboardLLProcedure;

        public const int WM_KEYDOWN = 0x0100;
        public const int WM_SYSKEYDOWN = 0x0104;
        public const int VK_SHIFT = 0x10;
        public const int VK_MENU = 0x12;

        [LibraryImport("User32.dll", SetLastError = true)]
        private static partial short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        public static int KeyboardLLProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                bool bShiftKeyDown = GetAsyncKeyState((Keys)VK_SHIFT) < 0;
                bool bAltKeyDown = GetAsyncKeyState((Keys)VK_MENU) < 0;
                KBDLLHOOKSTRUCT pKBDLLHOOKSTRUCT = new();
                pKBDLLHOOKSTRUCT = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, pKBDLLHOOKSTRUCT.GetType())!;


                switch (pKBDLLHOOKSTRUCT.vkCode)
                {
                    case (short)Keys.LWin:              // Windows button
                        return 1;

                    case (short)Keys.F4:                // Alt + F4
                    case (short)Keys.Tab:               // Alt + Tab
                        if (bAltKeyDown) return 1;
                        else break;

                    default:
                        break;
                }
            }
            return nCode < 0 ? CallNextHookEx(hHook, nCode, wParam, lParam) : 0;
        }
        /* Code to Disable WinKey, Alt+Tab, Ctrl+Esc Ends Here */
    }
}
