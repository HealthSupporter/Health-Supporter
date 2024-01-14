using SelfImplement_Libraries;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace ExerciseApp
{
    public partial class ExerciseApp : Form
    {
        // Event Handler ---------------------------------------------------

        //------------ Menu Tab -------------
        private void mainTabButton_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = true;
            timeSettingsPanel.Visible = false;
            videoSettingsPanel.Visible = false;
            sysSettingsPanel.Visible = false;
            helpPanel.Visible = false;
            mainPanel.BringToFront();
            Invalidate();
        }

        private void setTimerButton_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            timeSettingsPanel.Visible = true;
            videoSettingsPanel.Visible = false;
            sysSettingsPanel.Visible = false;
            helpPanel.Visible = false;
            timeSettingsPanel.BringToFront();
            Invalidate();
        }

        private void videoSettingsButton_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            timeSettingsPanel.Visible = false;
            videoSettingsPanel.Visible = true;
            sysSettingsPanel.Visible = false;
            helpPanel.Visible = false;
            videoSettingsPanel.BringToFront();
            Invalidate();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            timeSettingsPanel.Visible = false;
            videoSettingsPanel.Visible = false;
            sysSettingsPanel.Visible = true;
            helpPanel.Visible = false;
            sysSettingsPanel.BringToFront();
            Invalidate();
        }

        //------------ mainPanel ------------
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "Chọn video",
                Filter = string.Format("Tệp video ({0}) | {0}", supportedFileType),
                Multiselect = true,
                InitialDirectory = System.Environment.GetEnvironmentVariable("USERPROFILE"),
                RestoreDirectory = true
            };
            openFileDialog.Multiselect = true;
            DialogResult dialogResult = openFileDialog.ShowDialog();


            if (dialogResult == DialogResult.OK)
            {
                int numVid = 0;
                List<string> fileNames = new List<string>(openFileDialog.FileNames.Length);
                foreach (var item in openFileDialog.FileNames)
                {
                    if (validateTargetFile(item, supportedFileType))
                    {
                        numVid++;
                        fileNames.Add(item);
                    }
                }

                if (numVid == 0)
                {
                    MessageBox.Show("KHÔNG CÓ VIDEO NÀO PHÙ HỢP ĐỊNH DẠNG. HÃY THỬ CHỌN TỆP KHÁC.", "Định dạng file không được hỗ trợ");
                    num_videos = 0;
                    vidPath[0] = string.Empty;
                    return;
                }

                num_videos = numVid;
                vidPath = fileNames;
                textBox1.Text = vidPath[0];
            }
            else
            {
                MessageBox.Show("Không thể chọn tệp lúc này");
            }
        }

        private void textBox1_TextChanged(object? sender, EventArgs e)
        {
            if (vidPath[0] != textBox1.Text)
            {

                if (supportedFileType.Contains(Path.GetExtension(textBox1.Text)))
                {
                    vidPath[0] = textBox1.Text;
                }
                else
                {
                    MessageBox.Show("File bạn vừa nhập không phù hợp định dạng.");
                }
            }
        }

        private void hourUpDown_ValueChanged(object? sender, EventArgs e)
        {
            if (stateLocked)
            {
                hourUpDown.Value = currentHourConfig;
                return;
            }

            currentHourConfig = hourUpDown.Value;
            updateTime(currentHourConfig, currentMinuteConfig, currentSecondConfig);
        }

        private void minUpDown_ValueChanged(object? sender, EventArgs e)
        {
            if (stateLocked)
            {
                minUpDown.Value = currentMinuteConfig;
                return;
            }

            currentMinuteConfig = minUpDown.Value;
            updateTime(currentHourConfig, currentMinuteConfig, currentSecondConfig);
        }

        private void secUpDown_ValueChanged(object? sender, EventArgs e)
        {
            if (stateLocked)
            {
                secUpDown.Value = currentSecondConfig;
                return;
            }

            if (secUpDown.Value > 59)
            {
                minUpDown.Value++;
                secUpDown.Value = 0;
            }
            currentSecondConfig = secUpDown.Value;
            updateTime(currentHourConfig, currentMinuteConfig, currentSecondConfig);
        }

        private void stopHourUpDown_ValueChanged(object? sender, EventArgs e)
        {
            if (stateLocked)
            {
                stopHourUpDown.Value = currentStopHourConfig;
                return;
            }

            if (stopHourUpDown.Value >= 60)
            {
                stopHourUpDown.Value = 59;
                stopMinUpDown.Value = 59;
                stopSecUpDown.Value = 59;
            }

            currentStopHourConfig = stopHourUpDown.Value;
        }

        private void stopMinUpDown_ValueChanged(object? sender, EventArgs e)
        {
            if (stateLocked)
            {
                stopMinUpDown.Value = currentStopMinuteConfig;
                return;
            }

            if (stopMinUpDown.Value >= 60)
            {
                stopHourUpDown.Value++;
                stopMinUpDown.Value = 0;
            }

            currentStopMinuteConfig = stopMinUpDown.Value;
        }

        private void stopSecUpDown_ValueChanged(object? sender, EventArgs e)
        {
            if (stateLocked)
            {
                stopSecUpDown.Value = currentStopSecondConfig;
                return;
            }

            if (stopSecUpDown.Value >= 60)
            {
                stopMinUpDown.Value++;
                stopSecUpDown.Value = 0;
            }
            currentStopSecondConfig = stopSecUpDown.Value;
        }

        private void hourUpDown_Leave(object sender, EventArgs e)
        {
            if (hourUpDown.Text == String.Empty)
            {
                hourUpDown.Text = hourUpDown.Minimum.ToString();
                hourUpDown.Value = hourUpDown.Minimum;
            }
        }

        private void minUpDown_Leave(object sender, EventArgs e)
        {
            if (minUpDown.Text == String.Empty)
            {
                minUpDown.Text = minUpDown.Minimum.ToString();
                minUpDown.Value = minUpDown.Minimum;
            }
        }

        private void secUpDown_Leave(object sender, EventArgs e)
        {
            if (secUpDown.Text == String.Empty)
            {
                secUpDown.Text = secUpDown.Minimum.ToString();
                secUpDown.Value = secUpDown.Minimum;
            }
        }

        private void stopHourUpDown_Leave(object sender, EventArgs e)
        {
            if (stopHourUpDown.Text == String.Empty)
            {
                stopHourUpDown.Text = stopHourUpDown.Minimum.ToString();
                stopMinUpDown.Value = stopHourUpDown.Minimum;
            }
        }

        private void stopMinUpDown_Leave(object sender, EventArgs e)
        {
            if (stopMinUpDown.Text == String.Empty)
            {
                stopMinUpDown.Text = stopMinUpDown.Minimum.ToString();
                stopMinUpDown.Value = stopMinUpDown.Minimum;
            }
        }

        private void stopSecUpDown_Leave(object sender, EventArgs e)
        {
            if (stopSecUpDown.Text == String.Empty)
            {
                stopSecUpDown.Text = stopSecUpDown.Minimum.ToString();
                stopSecUpDown.Value = stopSecUpDown.Minimum;
            }
        }

        private void saveAllButton_Click(object? sender, EventArgs e)
        {
            saveConfig();
        }

        private void startCountButton_Click(object? sender, EventArgs e)
        {
            if (!started && !stateLocked)
            {
                int dur = Convert.ToInt32(((currentHourConfig * 3600) + (currentMinuteConfig * 60) + (currentSecondConfig)) * 1000);
                if (dur == 0)
                {
                    MessageBox.Show("Không thể đặt thời gian là 0.");
                    return;
                }
                if (!validateVideos())
                {
                    MessageBox.Show("Video không hợp lệ.");
                }

                if (!counting)
                {
                    timer1.Interval = dur;
                    updateTime(currentHourConfig, currentMinuteConfig, currentSecondConfig);
                    counting = true;
                }

                if (multiple_videos && num_videos < 2)
                {
                    MessageBox.Show("Tùy chọn \"Phát tất cả video trong thư mục\" được bật khi chỉ 1 file");
                    multiple_videos = playAllVideoCheckBox.Checked = play_random = false;
                }

                stateLocked = true;
                changeState();
                timer1.Start();
                timer2.Start();

                notifyIcon1.Visible = true;
                if (firstRun)
                {
                    notifyIcon1.ShowBalloonTip(3000);
                    firstRun = false;
                }
                this.Hide();
            }
        }

        private void timer1_Tick(object? sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timeLabel.Text = "0:00:00";

            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
            this.TopMost = true;
            this.Show();

            var result = MessageBox.Show("Đã đến giờ nghỉ, bạn có muốn nghỉ ngơi và tập thể dục không?", "Đã đến giờ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (Form2 subForm = new Form2(this))
                {
                    subForm.Bounds = screenResolution;
                    subForm.FormClosed += new FormClosedEventHandler(subForm_closed);
                    subForm.ShowDialog();
                }
            } else
            {
                FormClosedEventArgs tmp = new FormClosedEventArgs(CloseReason.None);
                subForm_closed(sender, tmp);
            }
        }

        private void stopCountButton_Click(object? sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            stateLocked = false;
            changeState();
        }

        private void resetCountButton_Click(object? sender, EventArgs e)
        {
            stateLocked = false;

            // Unhook event handler to avoid overflow
            hourUpDown.ValueChanged -= hourUpDown_ValueChanged;
            minUpDown.ValueChanged -= minUpDown_ValueChanged;
            secUpDown.ValueChanged -= secUpDown_ValueChanged;
            stopHourUpDown.ValueChanged -= stopHourUpDown_ValueChanged;
            stopMinUpDown.ValueChanged -= stopMinUpDown_ValueChanged;
            stopSecUpDown.ValueChanged -= stopSecUpDown_ValueChanged;
            dateTimePicker1.ValueChanged -= dateTimePicker1_ValueChanged!;
            playRandomCheckBox.CheckedChanged -= playRandomCheckBox_CheckedChanged!;
            playAllVideoCheckBox.CheckedChanged -= playAllVideoCheckBox_CheckedChanged!;
            useSleepPickerCheckBox.CheckedChanged -= useSleepPickerCheckBox_CheckedChanged!;
            textBox1.TextChanged -= textBox1_TextChanged;
            startwithWinBox.CheckedChanged -= startwithWinBox_CheckedChanged;

            hourUpDown.Value = stopHourUpDown.Value = currentHourConfig = currentStopHourConfig
            = minUpDown.Value = stopMinUpDown.Value = currentMinuteConfig = currentStopMinuteConfig
            = secUpDown.Value = stopSecUpDown.Value = currentSecondConfig = currentStopSecondConfig
            = sleepHourUpDown.Value = sleepMinUpDown.Value = sleepSecUpDown.Value
            = sleepHourTimeNumericUpDown.Value = sleepMinTimeNumericUpDown.Value = sleepSecTimeNumericUpDown.Value = 0;
            dateTimePicker1.Value = currentSleepDateTimeConfig = DateTime.Now;
            textBox1.Text = vidPath[0] = "";
            num_videos = 0;
            timeLabel.Text = "0:00:00";

            DateTime now = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;


            startWithSystem = startwithWinBox.Checked = false;
            play_random = playRandomCheckBox.Checked = false;
            multiple_videos = playAllVideoCheckBox.Checked = false;
            continuePlay = keepOpeningForm2CheckBox.Checked = false;
            useSleepPicker = useSleepPickerCheckBox.Checked = false;

            started = true;
            changeState();

            // Hook event handler after finished modified the value
            hourUpDown.ValueChanged += hourUpDown_ValueChanged;
            minUpDown.ValueChanged += minUpDown_ValueChanged;
            secUpDown.ValueChanged += secUpDown_ValueChanged;
            stopHourUpDown.ValueChanged += stopHourUpDown_ValueChanged;
            stopMinUpDown.ValueChanged += stopMinUpDown_ValueChanged;
            stopSecUpDown.ValueChanged += stopSecUpDown_ValueChanged;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged!;
            playRandomCheckBox.CheckedChanged += playRandomCheckBox_CheckedChanged!;
            playAllVideoCheckBox.CheckedChanged += playAllVideoCheckBox_CheckedChanged!;
            useSleepPickerCheckBox.CheckedChanged += useSleepPickerCheckBox_CheckedChanged!;
            textBox1.TextChanged += textBox1_TextChanged;
            startwithWinBox.CheckedChanged += startwithWinBox_CheckedChanged;
        }

        private void subForm_closed(object? sender, FormClosedEventArgs e)
        {
            timer1.Start();
            updateTime(currentHourConfig, currentMinuteConfig, currentSecondConfig);
            timer2.Start();
        }

        private void startwithWinBox_CheckedChanged(object? sender, EventArgs e)
        {
            if (startwithWinBox.CheckState == CheckState.Checked)
            {
                CreateShortcut();
                startWithSystem = true;
            }
            else
            {
                DeleteShortcut();
                startWithSystem = false;
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            mainPanel.Visible = false;
            timeSettingsPanel.Visible = false;
            videoSettingsPanel.Visible = false;
            sysSettingsPanel.Visible = false;
            helpPanel.Visible = true;
            helpPanel.BringToFront();
        }

        private bool doubleClicked = false;

        private void ExerciseApp_Resize(object sender, EventArgs e)
        {
            if (doubleClicked)
            {
                // doubleClicked = false;
                return;
            };
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                if (firstRun)
                {
                    firstRun = false;
                    notifyIcon1.ShowBalloonTip(3000);
                }
                this.ShowInTaskbar = false;
                // this.Hide();
            }
            Invalidate();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs? e)
        {
            doubleClicked = true;
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            this.ShowInTaskbar = true;
            this.Show();
            this.BringToFront();
            Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            currentSecond--;
            if (currentSecond < 0)
            {
                currentMinute--;
                currentSecond = 59;
            }
            if (currentMinute < 0)
            {
                currentMinute = 59;
                currentHour--;
            }
            if (currentHour < 0)
            {
                timer2.Stop();
                currentMinute = 0;
                currentSecond = 0;
                currentHour = 0;
            }

            updateTime();
        }

        private void bắtĐầuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!started)
            {
                showInfo_viaNotifyIcon("Đang bắt đầu tính giờ...");
                startCountButton_Click(sender, e);
            }
        }

        private void dừngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!stopped)
            {
                showInfo_viaNotifyIcon("Đã tạm dừng tính giờ");
                stopCountButton_Click(sender, e);
            }
        }

        private void kếtThúcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitProc();
            this.Close();
        }

        private void mởỨngDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1_MouseDoubleClick(sender, null);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (useSleepPicker)
                currentSleepDateTimeConfig = dateTimePicker1.Value;
        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            // Handler here
        }

        private void sleepHourUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (stateLocked || sleepState)
            {
                sleepHourUpDown.Value = currentSleepHourConfig;
                return;
            }

            if (sleepHourUpDown.Value >= 24)
            {
                sleepHourUpDown.Value = 23;
                sleepMinUpDown.Value = 59;
                sleepSecUpDown.Value = 59;
            }

            currentSleepHourConfig = sleepHourUpDown.Value;
        }

        private void sleepHourUpDown_Leave(object sender, EventArgs e)
        {
            if (sleepHourUpDown.Text == String.Empty)
            {
                sleepHourUpDown.Text = sleepHourUpDown.Minimum.ToString();
                sleepHourUpDown.Value = sleepHourUpDown.Minimum;
            }
        }

        private void sleepMinUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (stateLocked || sleepState)
            {
                sleepMinUpDown.Value = currentSleepMinConfig;
                return;
            }

            if (sleepMinUpDown.Value >= 60)
            {
                sleepMinUpDown.Value++;
                sleepMinUpDown.Value = 0;
            }

            currentSleepMinConfig = sleepMinUpDown.Value;
        }

        private void sleepMinUpDown_Leave(object sender, EventArgs e)
        {
            if (sleepMinUpDown.Text == String.Empty)
            {
                sleepMinUpDown.Text = sleepMinUpDown.Minimum.ToString();
                sleepMinUpDown.Value = sleepMinUpDown.Minimum;
            }
        }

        private void sleepSecUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (stateLocked || sleepState)
            {
                sleepSecUpDown.Value = currentSleepSecConfig;
                return;
            }

            if (sleepSecUpDown.Value >= 60)
            {
                sleepSecUpDown.Value++;
                sleepSecUpDown.Value = 0;
            }

            currentSleepSecConfig = sleepSecUpDown.Value;
        }

        private void sleepSecUpDown_Leave(object sender, EventArgs e)
        {
            if (sleepSecUpDown.Text == String.Empty)
            {
                sleepSecUpDown.Text = sleepSecUpDown.Minimum.ToString();
                sleepSecUpDown.Value = sleepSecUpDown.Minimum;
            }
        }

        private void sleepHourTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (stateLocked || sleepState)
            {
                sleepHourTimeNumericUpDown.Value = currentSleepDateTimeConfig.Hour;
                return;
            }

            if (sleepHourTimeNumericUpDown.Value >= 24)
            {
                sleepHourTimeNumericUpDown.Value = 23;
                sleepMinTimeNumericUpDown.Value = 59;
                sleepSecTimeNumericUpDown.Value = 59;
            }

            currentSleepDateTimeConfig = changeDateTime(currentSleepDateTimeConfig, sleepHourTimeNumericUpDown.Value, -1, -1, -1, -1, -1);
        }

        private void sleepHourTimeNumericUpDown_Leave(object sender, EventArgs e)
        {
            if (sleepHourTimeNumericUpDown.Text == String.Empty)
            {
                sleepHourTimeNumericUpDown.Text = sleepHourTimeNumericUpDown.Minimum.ToString();
                sleepHourTimeNumericUpDown.Value = sleepHourTimeNumericUpDown.Minimum;
            }
        }

        private void sleepMinTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (stateLocked || sleepState)
            {
                sleepMinTimeNumericUpDown.Value = currentSleepDateTimeConfig.Minute;
                return;
            }

            if (sleepMinTimeNumericUpDown.Value >= 60)
            {
                sleepHourTimeNumericUpDown.Value++;
                sleepMinTimeNumericUpDown.Value = 0;
            }

            currentSleepDateTimeConfig = changeDateTime(currentSleepDateTimeConfig, -1, sleepMinTimeNumericUpDown.Value, -1, -1, -1, -1);
        }

        private void sleepMinTimeNumericUpDown_Leave(object sender, EventArgs e)
        {
            if (sleepMinTimeNumericUpDown.Text == String.Empty)
            {
                sleepMinTimeNumericUpDown.Text = sleepMinTimeNumericUpDown.Minimum.ToString();
                sleepMinTimeNumericUpDown.Value = sleepMinTimeNumericUpDown.Minimum;
            }
        }

        private void sleepSecTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (stateLocked || sleepState)
            {
                sleepSecTimeNumericUpDown.Value = currentSleepDateTimeConfig.Second;
                return;
            }

            if (sleepSecTimeNumericUpDown.Value >= 60)
            {
                sleepMinTimeNumericUpDown.Value++;
                sleepSecTimeNumericUpDown.Value = 0;
            }

            currentSleepDateTimeConfig = changeDateTime(currentSleepDateTimeConfig, -1, -1, sleepSecTimeNumericUpDown.Value, -1, -1, -1);
        }

        private void sleepSecTimeNumericUpDown_Leave(object sender, EventArgs e)
        {
            if (sleepSecTimeNumericUpDown.Text == String.Empty)
            {
                sleepSecTimeNumericUpDown.Text = sleepSecTimeNumericUpDown.Minimum.ToString();
                sleepSecTimeNumericUpDown.Value = sleepSecTimeNumericUpDown.Minimum;
            }
        }

        private void useSleepPickerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            useSleepPicker = useSleepPickerCheckBox.Checked;
            if (useSleepPicker)
            {
                wakeDateTime = new DateTime(
                    currentSleepDateTimeConfig.Year,
                    currentSleepDateTimeConfig.Month,
                    currentSleepDateTimeConfig.Day,
                    (int)(currentSleepDateTimeConfig.Hour + currentSleepHourConfig),
                    (int)(currentSleepDateTimeConfig.Minute + currentSleepMinConfig),
                    (int)(currentSleepDateTimeConfig.Second + currentSleepSecConfig)
                    );
                sleep_tick = currentSleepDateTimeConfig.ToTick();
                target_tick = wakeDateTime.ToTick();
                tick = DateTime.Now.ToTick();

                MessageBox.Show(string.Format("{0} {1} {2}", tick, sleep_tick, target_tick));
            }
            useSleep = useSleepPicker;
        }

        private void playRandomCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            play_random = playRandomCheckBox.Checked;
        }

        private void playAllVideoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            multiple_videos = playAllVideoCheckBox.Checked;
        }

        private void keepOpeningForm2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            continuePlay = keepOpeningForm2CheckBox.Checked;
        }

        private ulong tick = 0;
        private ulong sleep_tick = 0;
        private ulong target_tick = 0;
        private bool useSleep = false;

        private string lastProcess;
        private int interval = 0;
        private string process;
        

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                process = GetCurrentProcess();
            } catch (Exception)
            {

            }

            /* if (processName != process)
            {
                lastProcess = process;
                this.TopMost = false;
                this.SendToBack();
                this.Hide();
            } else
            {
                this.Show();
            }
            */

            playRandomCheckBox.Enabled = multiple_videos;
            
            playRandomCheckBox.Checked = play_random;
            playAllVideoCheckBox.Checked = multiple_videos;
            keepOpeningForm2CheckBox.Checked = continuePlay;
            startwithWinBox.Checked = startWithSystem;

            hourUpDown.Value = currentHourConfig;
            minUpDown.Value = currentMinuteConfig;
            secUpDown.Value = currentSecondConfig;
            stopHourUpDown.Value = currentStopHourConfig;
            stopMinUpDown.Value = currentStopMinuteConfig;
            stopSecUpDown.Value = currentStopSecondConfig;
            textBox1.Text = vidPath[0];
        }

        private void sleepTimer_OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            sleepTimer.Stop();
            sleepState = false;
            MessageBox.Show("Đã thoát khỏi trạng thái ngủ");
            useSleepPickerCheckBox.Checked = useSleepPicker = false;

            startCountButton.Click += startCountButton_Click;
            resetCountButton.Click += resetCountButton_Click;
            stopCountButton.Click += stopCountButton_Click;
        }

        private void ExerciseApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer1.Enabled || timer2.Enabled || stateLocked)
            {
                var result = MessageBox.Show("Ứng dụng đang chạy, bạn có chắc chắn muốn thoát không?", "Đóng ứng dụng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}