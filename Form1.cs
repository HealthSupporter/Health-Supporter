#nullable disable

using IWshRuntimeLibrary;
using System.Timers;
using SelfImplement_Libraries;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ExerciseApp
{
    public partial class ExerciseApp : Form
    {

        // Constructor -----------------------------------------------------
        public ExerciseApp()
        {
            // System generated code ------
            InitializeComponent();
            // End system generated code --


            // User generated code --------
            mainTimer.Interval = 1;
            mainTimer.Start();
            currentConfigs = new(configPath, configNames);

            if (!currentConfigs.Load(configPath))
            {
                makeNewConfig();
            }

            try
            {

                string[] configs = currentConfigs.GetListOfValue();
                vidPath[0] = configs[0];
                int.TryParse(currentConfigs.Lookup("num_videos"), out num_videos);
                bool.TryParse(currentConfigs.Lookup("start_with_system"), out startWithSystem);
                bool.TryParse(currentConfigs.Lookup("play_random"), out play_random);
                bool.TryParse(currentConfigs.Lookup("play_all"), out multiple_videos);
                bool.TryParse(currentConfigs.Lookup("continue_play_when_end_of_video"), out continuePlay);
                decimal.TryParse(currentConfigs.Lookup("current_hour_cfg"), out currentHourConfig);
                decimal.TryParse(currentConfigs.Lookup("current_min_cfg"), out currentMinuteConfig);
                decimal.TryParse(currentConfigs.Lookup("current_sec_cfg"), out currentSecondConfig);
                decimal.TryParse(currentConfigs.Lookup("current_shour_cfg"), out currentStopHourConfig);
                decimal.TryParse(currentConfigs.Lookup("current_smin_cfg"), out currentStopMinuteConfig);
                decimal.TryParse(currentConfigs.Lookup("current_ssec_cfg"), out currentStopSecondConfig);
                bool.TryParse(currentConfigs.Lookup("use_sleep_picker"), out useSleepPicker);
                currentSleepDateTimeConfig = DateTime.Parse(configs[13]);
                decimal.TryParse(currentConfigs.Lookup("current_sleep_hour_cfg"), out currentSleepHourConfig);
                decimal.TryParse(currentConfigs.Lookup("current_sleep_min_cfg"), out currentSleepMinConfig);
                decimal.TryParse(currentConfigs.Lookup("current_sleep_sec_cfg"), out currentSleepSecConfig);

                if (!validateTargetFile(vidPath[0], supportedFileType))
                {
                    MessageBox.Show("Tệp media trong thiết lập không phù hợp định dạng");
                    vidPath[0] = "";
                }

                hourUpDown.Value = currentHourConfig;
                minUpDown.Value = currentMinuteConfig;
                secUpDown.Value = currentSecondConfig;
                stopHourUpDown.Value = currentStopHourConfig;
                stopMinUpDown.Value = currentStopMinuteConfig;
                stopSecUpDown.Value = currentStopSecondConfig;
                sleepHourUpDown.Value = currentSleepHourConfig;
                sleepMinUpDown.Value = currentSleepMinConfig;
                sleepSecUpDown.Value = currentSleepSecConfig;
                sleepHourTimeNumericUpDown.Value = currentSleepDateTimeConfig.Hour;
                sleepMinTimeNumericUpDown.Value = currentSleepDateTimeConfig.Minute;
                sleepSecTimeNumericUpDown.Value = currentSleepDateTimeConfig.Second;

                playRandomCheckBox.Checked = play_random;
                useSleepPickerCheckBox.Checked = useSleepPicker;
                playAllVideoCheckBox.Checked = multiple_videos;
                dateTimePicker1.Value = currentSleepDateTimeConfig;
                startwithWinBox.Checked = startWithSystem;
                textBox1.Text = vidPath[0];
                countStateButton.Text = countState[0];
                if (startWithSystem)
                {
                    CreateShortcut();
                }
                else
                {
                    DeleteShortcut();
                }

                if (!validateTarget(vidPath[0]))
                {
                    vidPath[0] = processPath + defaultVideo;
                    num_videos = 1;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("Không thể sử dụng thiết lập có sẵn!\nLỗi: {0}", e.Message), "Warning");
            }

            processName = Process.GetCurrentProcess().ProcessName;

            stubInitialize();
            Invalidate();   // Redraw the windows
            // End user generated code ----

            // In progress
            groupBox3.Visible = false;

        }

        // Private function handler ----------------------------------------
        private void stubInitialize()
        {
            notifyIcon1.Visible = false;
            notifyIcon1.Text = "Health Supporter";
            notifyIcon1.BalloonTipText = "Ứng dụng đang chạy dưới nền";
            notifyIcon1.BalloonTipTitle = "Health Supporter";

            currentSize = this.Size;

            screenResolution = Screen.PrimaryScreen!.Bounds;
            centerScreenPos = new Point(
                ((screenResolution.Width / 2) - (this.Width / 2)),
                ((screenResolution.Height / 2) - (this.Height / 2))
            );
            updateTime(currentHourConfig, currentMinuteConfig, currentSecondConfig);


            this.Icon = Properties.Resources.icon;
            notifyIcon1.Icon = this.Icon;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;

            started = false;
            stopped = true;
            bắtĐầuToolStripMenuItem.Enabled = true;
            dừngToolStripMenuItem.Enabled = false;
            kếtThúcToolStripMenuItem.Enabled = true;
            sleepState = false;


            pictureBox1.Image = Properties.Resources.mainIcon;
            bắtĐầuToolStripMenuItem.Image = Properties.Resources.pause;
            kếtThúcToolStripMenuItem.Image = Properties.Resources.play;
            dừngToolStripMenuItem.Image = Properties.Resources.quit;

            mainPanel.Enabled = timeSettingsPanel.Enabled = videoSettingsPanel.Enabled = sysSettingsPanel.Enabled = true;
            mainPanel.Visible = true;
            timeSettingsPanel.Visible = false;
            videoSettingsPanel.Visible = false;
            sysSettingsPanel.Visible = false;
            helpPanel.Visible = false;
            mainPanel.BringToFront();

            corrupted_VidPath_Index = new List<int>();
            sleepTimer = new System.Timers.Timer();
            sleepTimer.Elapsed += new ElapsedEventHandler(sleepTimer_OnTimedEvent!);

            wakeDateTime = changeDateTime(currentSleepDateTimeConfig,
                                            currentSleepDateTimeConfig.Hour + currentSleepHourConfig,
                                            currentSleepDateTimeConfig.Minute + currentSleepMinConfig,
                                            currentSleepDateTimeConfig.Second + currentSleepSecConfig,
                                            -1, -1, -1
                                         );

            helpTextBox.AcceptsReturn = true;
            helpTextBox.Multiline = true;
            helpTextBox.Size = new Size(700, 320);
            helpTextBox.MinimumSize = helpTextBox.Size;
            helpTextBox.BackColor = BackColor;
            getHelpMSG();
        }

        private void getHelpMSG()
        {
            string[] input = [];
            try { input = System.IO.File.ReadAllLines($"{processPath}\\{helpMsgPath}"); }
            catch
            {
                MessageBox.Show("Không tìm thấy tệp help.txt, ngắt quyền truy cập vào tab Trợ giúp.", "Lỗi không tìm thấy tệp");
                helpPanel.Enabled = false;
                return;
            }

            foreach (var item in input)
            {
                helpTextBox.AppendText($"{item}");
                helpTextBox.AppendText(Environment.NewLine);
            }

            lastProcess = GetCurrentProcess();
        }


        private void makeNewConfig()
        {
            // MessageBox.Show(string.Format("Không thể tìm thấy tệp current_config.cfg trong thư mục cài đặt."));

            currentConfigs = new AppConfiguration(configPath, configNames);
            currentConfigs.Edit(configNames,
                [
                    string.Format(@"{0}\Asset\Default\default_video.mp4", processPath),
                    "1",
                    "False",
                    "False",
                    "False",
                    "False",
                    "0",
                    "30",
                    "0",
                    "0",
                    "5",
                    "0",
                    "False",
                    DateTime.Now.AddHours(2).ToString(),
                    "0",
                    "0",
                    "0"
                ]
                );

            vidPath[0] = processPath + @"\Asset\Default\default_video.mp4";
            num_videos = 1;
            play_random = false;
            multiple_videos = false;
            continuePlay = true;
            startWithSystem = false;
            multiple_videos = false;
            currentHourConfig = 0;
            currentMinuteConfig = 30;
            currentSecondConfig = 0;
            currentStopHourConfig = 0;
            currentStopMinuteConfig = 5;
            currentStopSecondConfig = 0;
            useSleepPicker = false;
            currentSleepDateTimeConfig = DateTime.Now.AddHours(2);
            currentSleepHourConfig = 0;
            currentSleepMinConfig = 0;
            currentSleepSecConfig = 0;
            saveConfig();
        }

        private void saveConfig()
        {
            currentConfigs.Edit("video_path", vidPath[0]);
            currentConfigs.Edit("num_videos", num_videos);
            currentConfigs.Edit("play_random", play_random);
            currentConfigs.Edit("continue_play_when_end_of_video", continuePlay);
            currentConfigs.Edit("start_with_system", startWithSystem);
            currentConfigs.Edit("current_hour_cfg", currentHourConfig);
            currentConfigs.Edit("current_min_cfg", currentMinuteConfig);
            currentConfigs.Edit("current_sec_cfg", currentSecondConfig);
            currentConfigs.Edit("current_shour_cfg", currentStopHourConfig);
            currentConfigs.Edit("current_smin_cfg", currentStopMinuteConfig);
            currentConfigs.Edit("current_ssec_cfg", currentStopSecondConfig);
            currentConfigs.Edit("use_sleep_picker", useSleepPicker);
            currentConfigs.Edit("current_sleep_datetime", currentSleepDateTimeConfig);
            currentConfigs.Edit("current_sleep_hour_cfg", currentSleepHourConfig);
            currentConfigs.Edit("current_sleep_min_cfg", currentSleepMinConfig);
            currentConfigs.Edit("current_sleep_sec_cfg", currentSleepSecConfig);

            if (currentConfigs.Save())
            {
                // MessageBox.Show(string.Format("Lưu thiết lập thành công tại {0}", configPath));
            }
        }

        private void CreateShortcut()
        {
            object shDesktop = (object)"StartMenu";
            WshShell shell = new();

            string rootDir = processPath;
            string name = string.Format(@"\{0}.lnk", System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            string exeName = string.Format(@"\{0}", System.AppDomain.CurrentDomain.FriendlyName);
            string startupPath = string.Format(@"{0}\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup", Environment.GetEnvironmentVariable("USERPROFILE"));
            string shortcutAddress = startupPath + name;


            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.TargetPath = rootDir + exeName;
            shortcut.IconLocation = rootDir + @"\Asset\icon.ico";
            shortcut.WorkingDirectory = rootDir;
            shortcut.Save();
        }

        private void DeleteShortcut()
        {
            string name = string.Format(@"\{0}.lnk", System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            string startupPath = string.Format(@"{0}\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup", Environment.GetEnvironmentVariable("USERPROFILE"));
            string shortcutAddress = startupPath + name;
            System.IO.File.Delete(shortcutAddress);
        }

        private string formatTime(decimal hour, decimal minute, decimal second)
        {
            string mm, ss;
            if (minute >= 10)
                mm = minute.ToString();
            else
                mm = string.Format("0{0}", minute);

            if (second >= 10)
                ss = second.ToString();
            else
                ss = string.Format("0{0}", second);

            string res;
            res = string.Format("{0}:{1}:{2}", hour, mm, ss);
            return res;
        }

        private void updateTime()
        {
            timeLabel.Text = formatTime(currentHour, currentMinute, currentSecond);
        }

        private void updateTime(decimal hour, decimal minute, decimal second)
        {
            currentHour = hour > 0 ? hour : 0;
            currentMinute = minute > 0 ? minute : 0;
            currentSecond = second > 0 ? second : 0;
            timeLabel.Text = formatTime(currentHour, currentMinute, currentSecond);
        }

        private void changeState()
        {
            if (started)
            {
                dừngToolStripMenuItem.Enabled = started = false;
                bắtĐầuToolStripMenuItem.Enabled = stopped = true;
                countStateButton.Text = countState[0];
            }
            else
            {
                dừngToolStripMenuItem.Enabled = started = true;
                bắtĐầuToolStripMenuItem.Enabled = stopped = false;
                countStateButton.Text = countState[1];
            }
        }

        private void exitProc()
        {
            saveConfig();
            mainTimer.Stop();
            System.Windows.Forms.Application.Exit();
        }

        private void showInfo_viaNotifyIcon(string msg)
        {
            string old_tttext = notifyIcon1.BalloonTipText;
            notifyIcon1.BalloonTipText = msg;
            notifyIcon1.ShowBalloonTip(3000);
            notifyIcon1.BalloonTipText = old_tttext;
        }

        private bool validateTarget(string path)
        {
            try
            {
                FileAttributes attr = System.IO.File.GetAttributes(path);

                if (attr.HasFlag(FileAttributes.Directory) || attr.HasFlag(FileAttributes.Normal))
                {
                    return true;
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(string.Format("Không tồn tại {0}", path));
                return false;
            }

            return true;
        }

        private bool validateTargetFile(string file, string extension)
        {
            if (validateTarget(file))
                if (extension.Contains(Path.GetExtension(file)))
                    return true;
            return false;
        }

        private bool validateTargetFile(string file, string[] extensions)
        {
            if (validateTarget(file))
                if (extensions.Contains(Path.GetExtension(file)))
                    return true;
            return false;
        }

        private bool validateVideos()
        {
            corrupted_VidPath_Index = new List<int>(num_videos);
            if (validateTarget(vidPath[0]))
            {
                if (num_videos == 1 && validateTargetFile(vidPath[0], supportedFileType))
                    return true;
                for (int i = 1; i <= num_videos; i++)
                {
                    if (!validateTargetFile(vidPath[i], supportedFileType))
                    {
                        corrupted_VidPath_Index.Add(i);
                    }
                }
            }
            return false;
        }

        private DateTime changeDateTime(DateTime dt, decimal hour, decimal min, decimal sec, decimal day, decimal month, decimal year)
        {
            double _h = hour != -1 ? (double)hour : 0;
            double _m = min != -1 ? (double)min : 0;
            double _s = sec != -1 ? (double)sec : 0;
            double _dd = day != -1 ? (double)day : 0;
            int _mm = month != -1 ? (int)month : 0;
            int _yy = year != -1 ? (int)year : 0;

            DateTime newDT = dt;
            newDT.AddSeconds(_s);
            newDT.AddMinutes(_m);
            newDT.AddHours(_h);
            newDT.AddDays(_dd);
            newDT.AddMonths(_mm);
            newDT.AddYears(_yy);

            return newDT;
        }

        private void showNotification(string title, string msg)
        {
            notifyIcon1.Visible = true;
            string old_tttext = notifyIcon1.BalloonTipText;
            notifyIcon1.BalloonTipText = msg;
            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.ShowBalloonTip(3000);
            notifyIcon1.BalloonTipText = old_tttext;
            notifyIcon1.Visible = false;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = false)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        private string GetCurrentProcess()
        {
            IntPtr hWnd = GetForegroundWindow();
            uint procId = 0;
            GetWindowThreadProcessId(hWnd, out procId);
            var proc = Process.GetProcessById((int)procId);
            return proc.ProcessName;
        }

        private void ExerciseApp_Leave(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.SendToBack();
        }
    }
}
