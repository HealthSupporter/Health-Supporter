namespace ExerciseApp
{
    public partial class ExerciseApp
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExerciseApp));
            label1 = new Label();
            label2 = new Label();
            startwithWinBox = new CheckBox();
            sysSettingGBox = new GroupBox();
            timeConfigGBox = new GroupBox();
            label11 = new Label();
            stopHourUpDown = new NumericUpDown();
            label12 = new Label();
            hourUpDown = new NumericUpDown();
            label10 = new Label();
            label9 = new Label();
            label5 = new Label();
            label3 = new Label();
            stopSecUpDown = new NumericUpDown();
            label8 = new Label();
            secUpDown = new NumericUpDown();
            stopMinUpDown = new NumericUpDown();
            label4 = new Label();
            minUpDown = new NumericUpDown();
            saveAllButton = new Button();
            startCountButton = new Button();
            stopCountButton = new Button();
            resetCountButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            label6 = new Label();
            countStateButton = new Label();
            helpButton = new Button();
            notifyIcon1 = new NotifyIcon(components);
            label7 = new Label();
            timeLabel = new Label();
            timer2 = new System.Windows.Forms.Timer(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            mởỨngDụngToolStripMenuItem = new ToolStripMenuItem();
            bắtĐầuToolStripMenuItem = new ToolStripMenuItem();
            dừngToolStripMenuItem = new ToolStripMenuItem();
            kếtThúcToolStripMenuItem = new ToolStripMenuItem();
            menuGroupBox = new GroupBox();
            videoSettingsButton = new Button();
            settingsButton = new Button();
            setTimerButton = new Button();
            mainTabButton = new Button();
            mainPanel = new Panel();
            groupBox1 = new GroupBox();
            timeSettingsPanel = new Panel();
            groupBox3 = new GroupBox();
            useSleepPickerCheckBox = new CheckBox();
            sleepHourTimeNumericUpDown = new NumericUpDown();
            sleepSecTimeNumericUpDown = new NumericUpDown();
            sleepMinTimeNumericUpDown = new NumericUpDown();
            label16 = new Label();
            label15 = new Label();
            sleepHourUpDown = new NumericUpDown();
            label14 = new Label();
            label17 = new Label();
            label13 = new Label();
            sleepSecUpDown = new NumericUpDown();
            dateTimePicker1 = new DateTimePicker();
            label18 = new Label();
            sleepMinUpDown = new NumericUpDown();
            sysSettingsPanel = new Panel();
            mainTimer = new System.Windows.Forms.Timer(components);
            videoSettingsPanel = new Panel();
            keepOpeningForm2CheckBox = new CheckBox();
            playRandomCheckBox = new CheckBox();
            playAllVideoCheckBox = new CheckBox();
            textBox1 = new TextBox();
            button1 = new Button();
            helpTextBox = new TextBox();
            helpPanel = new Panel();
            sysSettingGBox.SuspendLayout();
            timeConfigGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stopHourUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hourUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stopSecUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)secUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stopMinUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            menuGroupBox.SuspendLayout();
            mainPanel.SuspendLayout();
            groupBox1.SuspendLayout();
            timeSettingsPanel.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sleepHourTimeNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sleepSecTimeNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sleepMinTimeNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sleepHourUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sleepSecUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)sleepMinUpDown).BeginInit();
            sysSettingsPanel.SuspendLayout();
            videoSettingsPanel.SuspendLayout();
            helpPanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("UD Digi Kyokasho NP-B", 39.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label1.Location = new Point(325, 9);
            label1.Name = "label1";
            label1.Size = new Size(616, 62);
            label1.TabIndex = 1;
            label1.Text = "HEALTH SUPPORTER";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(20, 17);
            label2.Name = "label2";
            label2.Size = new Size(153, 21);
            label2.TabIndex = 4;
            label2.Text = "Đường dẫn tới video";
            // 
            // startwithWinBox
            // 
            startwithWinBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            startwithWinBox.AutoSize = true;
            startwithWinBox.Font = new Font("Segoe UI", 12F);
            startwithWinBox.Location = new Point(6, 21);
            startwithWinBox.Name = "startwithWinBox";
            startwithWinBox.Size = new Size(208, 25);
            startwithWinBox.TabIndex = 6;
            startwithWinBox.Text = "Khởi động cùng Windows";
            startwithWinBox.UseVisualStyleBackColor = true;
            startwithWinBox.CheckedChanged += startwithWinBox_CheckedChanged;
            // 
            // sysSettingGBox
            // 
            sysSettingGBox.Controls.Add(startwithWinBox);
            sysSettingGBox.Location = new Point(17, 26);
            sysSettingGBox.Name = "sysSettingGBox";
            sysSettingGBox.Size = new Size(279, 52);
            sysSettingGBox.TabIndex = 7;
            sysSettingGBox.TabStop = false;
            sysSettingGBox.Text = "Cài đặt hệ thống";
            // 
            // timeConfigGBox
            // 
            timeConfigGBox.Controls.Add(label11);
            timeConfigGBox.Controls.Add(stopHourUpDown);
            timeConfigGBox.Controls.Add(label12);
            timeConfigGBox.Controls.Add(hourUpDown);
            timeConfigGBox.Controls.Add(label10);
            timeConfigGBox.Controls.Add(label9);
            timeConfigGBox.Controls.Add(label5);
            timeConfigGBox.Controls.Add(label3);
            timeConfigGBox.Controls.Add(stopSecUpDown);
            timeConfigGBox.Controls.Add(label8);
            timeConfigGBox.Controls.Add(secUpDown);
            timeConfigGBox.Controls.Add(stopMinUpDown);
            timeConfigGBox.Controls.Add(label4);
            timeConfigGBox.Controls.Add(minUpDown);
            timeConfigGBox.Location = new Point(3, 14);
            timeConfigGBox.Name = "timeConfigGBox";
            timeConfigGBox.Size = new Size(459, 101);
            timeConfigGBox.TabIndex = 9;
            timeConfigGBox.TabStop = false;
            timeConfigGBox.Text = "Cài đặt hẹn giờ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(232, 69);
            label11.Name = "label11";
            label11.Size = new Size(33, 21);
            label11.TabIndex = 30;
            label11.Text = "giờ";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // stopHourUpDown
            // 
            stopHourUpDown.Location = new Point(188, 69);
            stopHourUpDown.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            stopHourUpDown.Name = "stopHourUpDown";
            stopHourUpDown.Size = new Size(38, 23);
            stopHourUpDown.TabIndex = 29;
            stopHourUpDown.ValueChanged += stopHourUpDown_ValueChanged;
            stopHourUpDown.Leave += stopHourUpDown_Leave;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F);
            label12.Location = new Point(232, 23);
            label12.Name = "label12";
            label12.Size = new Size(33, 21);
            label12.TabIndex = 28;
            label12.Text = "giờ";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // hourUpDown
            // 
            hourUpDown.Location = new Point(188, 23);
            hourUpDown.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            hourUpDown.Name = "hourUpDown";
            hourUpDown.Size = new Size(38, 23);
            hourUpDown.TabIndex = 27;
            hourUpDown.ValueChanged += hourUpDown_ValueChanged;
            hourUpDown.Leave += hourUpDown_Leave;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 15F);
            label10.Location = new Point(6, 64);
            label10.Name = "label10";
            label10.Size = new Size(137, 28);
            label10.TabIndex = 26;
            label10.Text = "Thời gian nghỉ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 15F);
            label9.Location = new Point(6, 19);
            label9.Name = "label9";
            label9.Size = new Size(169, 28);
            label9.TabIndex = 25;
            label9.Text = "Thời gian làm việc";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(409, 69);
            label5.Name = "label5";
            label5.Size = new Size(39, 21);
            label5.TabIndex = 24;
            label5.Text = "giây";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(409, 23);
            label3.Name = "label3";
            label3.Size = new Size(39, 21);
            label3.TabIndex = 20;
            label3.Text = "giây";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // stopSecUpDown
            // 
            stopSecUpDown.Location = new Point(364, 69);
            stopSecUpDown.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            stopSecUpDown.Name = "stopSecUpDown";
            stopSecUpDown.Size = new Size(39, 23);
            stopSecUpDown.TabIndex = 23;
            stopSecUpDown.TabStop = false;
            stopSecUpDown.ValueChanged += stopSecUpDown_ValueChanged;
            stopSecUpDown.Leave += stopSecUpDown_Leave;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(319, 69);
            label8.Name = "label8";
            label8.Size = new Size(42, 21);
            label8.TabIndex = 22;
            label8.Text = "phút";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // secUpDown
            // 
            secUpDown.Location = new Point(364, 23);
            secUpDown.Name = "secUpDown";
            secUpDown.Size = new Size(39, 23);
            secUpDown.TabIndex = 12;
            secUpDown.TabStop = false;
            secUpDown.ValueChanged += secUpDown_ValueChanged;
            secUpDown.Leave += secUpDown_Leave;
            // 
            // stopMinUpDown
            // 
            stopMinUpDown.Location = new Point(275, 69);
            stopMinUpDown.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            stopMinUpDown.Name = "stopMinUpDown";
            stopMinUpDown.Size = new Size(38, 23);
            stopMinUpDown.TabIndex = 21;
            stopMinUpDown.Value = new decimal(new int[] { 5, 0, 0, 0 });
            stopMinUpDown.ValueChanged += stopMinUpDown_ValueChanged;
            stopMinUpDown.Leave += stopMinUpDown_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(319, 23);
            label4.Name = "label4";
            label4.Size = new Size(42, 21);
            label4.TabIndex = 11;
            label4.Text = "phút";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // minUpDown
            // 
            minUpDown.Location = new Point(275, 23);
            minUpDown.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            minUpDown.Name = "minUpDown";
            minUpDown.Size = new Size(38, 23);
            minUpDown.TabIndex = 10;
            minUpDown.ValueChanged += minUpDown_ValueChanged;
            minUpDown.Leave += minUpDown_Leave;
            // 
            // saveAllButton
            // 
            saveAllButton.Font = new Font("Segoe UI", 15F);
            saveAllButton.Location = new Point(20, 20);
            saveAllButton.Name = "saveAllButton";
            saveAllButton.Size = new Size(146, 42);
            saveAllButton.TabIndex = 14;
            saveAllButton.Text = "Lưu thiết lập";
            saveAllButton.UseVisualStyleBackColor = true;
            saveAllButton.Click += saveAllButton_Click;
            // 
            // startCountButton
            // 
            startCountButton.Anchor = AnchorStyles.None;
            startCountButton.Font = new Font("Segoe UI", 30F);
            startCountButton.Location = new Point(206, 168);
            startCountButton.Name = "startCountButton";
            startCountButton.Size = new Size(262, 65);
            startCountButton.TabIndex = 10;
            startCountButton.Text = "Bắt đầu";
            startCountButton.UseVisualStyleBackColor = true;
            startCountButton.Click += startCountButton_Click;
            // 
            // stopCountButton
            // 
            stopCountButton.Anchor = AnchorStyles.None;
            stopCountButton.Font = new Font("Segoe UI", 15F);
            stopCountButton.Location = new Point(524, 98);
            stopCountButton.Name = "stopCountButton";
            stopCountButton.Size = new Size(120, 38);
            stopCountButton.TabIndex = 11;
            stopCountButton.Text = "Tạm dừng";
            stopCountButton.UseVisualStyleBackColor = true;
            stopCountButton.Click += stopCountButton_Click;
            // 
            // resetCountButton
            // 
            resetCountButton.Anchor = AnchorStyles.None;
            resetCountButton.Font = new Font("Segoe UI", 15F);
            resetCountButton.Location = new Point(524, 44);
            resetCountButton.Name = "resetCountButton";
            resetCountButton.Size = new Size(120, 38);
            resetCountButton.TabIndex = 12;
            resetCountButton.Text = "Reset";
            resetCountButton.UseVisualStyleBackColor = true;
            resetCountButton.Click += resetCountButton_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Location = new Point(1041, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(155, 142);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F);
            label6.Location = new Point(54, 52);
            label6.Name = "label6";
            label6.Size = new Size(107, 28);
            label6.TabIndex = 15;
            label6.Text = "Trạng thái: ";
            // 
            // countStateButton
            // 
            countStateButton.Anchor = AnchorStyles.None;
            countStateButton.AutoSize = true;
            countStateButton.Font = new Font("Segoe UI", 15F);
            countStateButton.Location = new Point(167, 52);
            countStateButton.Name = "countStateButton";
            countStateButton.Size = new Size(130, 28);
            countStateButton.TabIndex = 16;
            countStateButton.Text = "ĐANG DỪNG";
            countStateButton.UseMnemonic = false;
            // 
            // helpButton
            // 
            helpButton.Location = new Point(6, 244);
            helpButton.Name = "helpButton";
            helpButton.Size = new Size(188, 30);
            helpButton.TabIndex = 17;
            helpButton.Text = "Trợ giúp";
            helpButton.UseVisualStyleBackColor = true;
            helpButton.Click += helpButton_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipText = "[Idk]\r\n";
            notifyIcon1.BalloonTipTitle = "Health Supporter";
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Health Supporter";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15F);
            label7.Location = new Point(62, 85);
            label7.Name = "label7";
            label7.Size = new Size(97, 28);
            label7.TabIndex = 18;
            label7.Text = "Thời gian:";
            // 
            // timeLabel
            // 
            timeLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Segoe UI", 18F);
            timeLabel.Location = new Point(167, 85);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(89, 32);
            timeLabel.TabIndex = 23;
            timeLabel.Text = "0:00:00";
            // 
            // timer2
            // 
            timer2.Interval = 1000;
            timer2.Tick += timer2_Tick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { mởỨngDụngToolStripMenuItem, bắtĐầuToolStripMenuItem, dừngToolStripMenuItem, kếtThúcToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(150, 92);
            // 
            // mởỨngDụngToolStripMenuItem
            // 
            mởỨngDụngToolStripMenuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mởỨngDụngToolStripMenuItem.Name = "mởỨngDụngToolStripMenuItem";
            mởỨngDụngToolStripMenuItem.Size = new Size(149, 22);
            mởỨngDụngToolStripMenuItem.Text = "Mở ứng dụng";
            mởỨngDụngToolStripMenuItem.Click += mởỨngDụngToolStripMenuItem_Click;
            // 
            // bắtĐầuToolStripMenuItem
            // 
            bắtĐầuToolStripMenuItem.Name = "bắtĐầuToolStripMenuItem";
            bắtĐầuToolStripMenuItem.Size = new Size(149, 22);
            bắtĐầuToolStripMenuItem.Text = "Bắt đầu";
            bắtĐầuToolStripMenuItem.Click += bắtĐầuToolStripMenuItem_Click;
            // 
            // dừngToolStripMenuItem
            // 
            dừngToolStripMenuItem.Name = "dừngToolStripMenuItem";
            dừngToolStripMenuItem.Size = new Size(149, 22);
            dừngToolStripMenuItem.Text = "Dừng";
            dừngToolStripMenuItem.Click += dừngToolStripMenuItem_Click;
            // 
            // kếtThúcToolStripMenuItem
            // 
            kếtThúcToolStripMenuItem.Name = "kếtThúcToolStripMenuItem";
            kếtThúcToolStripMenuItem.Size = new Size(149, 22);
            kếtThúcToolStripMenuItem.Text = "Kết thúc";
            kếtThúcToolStripMenuItem.Click += kếtThúcToolStripMenuItem_Click;
            // 
            // menuGroupBox
            // 
            menuGroupBox.Controls.Add(videoSettingsButton);
            menuGroupBox.Controls.Add(settingsButton);
            menuGroupBox.Controls.Add(setTimerButton);
            menuGroupBox.Controls.Add(mainTabButton);
            menuGroupBox.Controls.Add(helpButton);
            menuGroupBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menuGroupBox.Location = new Point(11, 83);
            menuGroupBox.Name = "menuGroupBox";
            menuGroupBox.Size = new Size(200, 320);
            menuGroupBox.TabIndex = 20;
            menuGroupBox.TabStop = false;
            menuGroupBox.Text = "Menu";
            // 
            // videoSettingsButton
            // 
            videoSettingsButton.Location = new Point(6, 115);
            videoSettingsButton.Name = "videoSettingsButton";
            videoSettingsButton.Size = new Size(188, 30);
            videoSettingsButton.TabIndex = 18;
            videoSettingsButton.Text = "Thiết lập video";
            videoSettingsButton.UseVisualStyleBackColor = true;
            videoSettingsButton.Click += videoSettingsButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.Location = new Point(6, 281);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(188, 30);
            settingsButton.TabIndex = 2;
            settingsButton.Text = "Cài đặt";
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += settingsButton_Click;
            // 
            // setTimerButton
            // 
            setTimerButton.Location = new Point(6, 73);
            setTimerButton.Name = "setTimerButton";
            setTimerButton.Size = new Size(188, 30);
            setTimerButton.TabIndex = 1;
            setTimerButton.Text = "Thiết lập thời gian";
            setTimerButton.UseVisualStyleBackColor = true;
            setTimerButton.Click += setTimerButton_Click;
            // 
            // mainTabButton
            // 
            mainTabButton.Location = new Point(6, 28);
            mainTabButton.Name = "mainTabButton";
            mainTabButton.Size = new Size(188, 30);
            mainTabButton.TabIndex = 0;
            mainTabButton.Text = "Tab chính";
            mainTabButton.UseVisualStyleBackColor = true;
            mainTabButton.Click += mainTabButton_Click;
            // 
            // mainPanel
            // 
            mainPanel.BorderStyle = BorderStyle.Fixed3D;
            mainPanel.Controls.Add(resetCountButton);
            mainPanel.Controls.Add(startCountButton);
            mainPanel.Controls.Add(stopCountButton);
            mainPanel.Controls.Add(groupBox1);
            mainPanel.Location = new Point(300, 90);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(700, 320);
            mainPanel.TabIndex = 30;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.None;
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(countStateButton);
            groupBox1.Controls.Add(timeLabel);
            groupBox1.Location = new Point(152, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(366, 129);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            // 
            // timeSettingsPanel
            // 
            timeSettingsPanel.BorderStyle = BorderStyle.Fixed3D;
            timeSettingsPanel.Controls.Add(groupBox3);
            timeSettingsPanel.Controls.Add(timeConfigGBox);
            timeSettingsPanel.Location = new Point(300, 90);
            timeSettingsPanel.Name = "timeSettingsPanel";
            timeSettingsPanel.RightToLeft = RightToLeft.No;
            timeSettingsPanel.Size = new Size(700, 320);
            timeSettingsPanel.TabIndex = 22;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(useSleepPickerCheckBox);
            groupBox3.Controls.Add(sleepHourTimeNumericUpDown);
            groupBox3.Controls.Add(sleepSecTimeNumericUpDown);
            groupBox3.Controls.Add(sleepMinTimeNumericUpDown);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(sleepHourUpDown);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(sleepSecUpDown);
            groupBox3.Controls.Add(dateTimePicker1);
            groupBox3.Controls.Add(label18);
            groupBox3.Controls.Add(sleepMinUpDown);
            groupBox3.Location = new Point(3, 145);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(866, 155);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Hẹn thời gian tạm ngừng hoạt động";
            // 
            // useSleepPickerCheckBox
            // 
            useSleepPickerCheckBox.AutoSize = true;
            useSleepPickerCheckBox.Font = new Font("Segoe UI", 12F);
            useSleepPickerCheckBox.Location = new Point(396, 17);
            useSleepPickerCheckBox.Name = "useSleepPickerCheckBox";
            useSleepPickerCheckBox.Size = new Size(190, 25);
            useSleepPickerCheckBox.TabIndex = 37;
            useSleepPickerCheckBox.Text = "Đặt thời gian tạm dừng";
            useSleepPickerCheckBox.UseVisualStyleBackColor = true;
            useSleepPickerCheckBox.CheckedChanged += useSleepPickerCheckBox_CheckedChanged;
            // 
            // sleepHourTimeNumericUpDown
            // 
            sleepHourTimeNumericUpDown.Location = new Point(275, 51);
            sleepHourTimeNumericUpDown.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            sleepHourTimeNumericUpDown.Name = "sleepHourTimeNumericUpDown";
            sleepHourTimeNumericUpDown.Size = new Size(38, 23);
            sleepHourTimeNumericUpDown.TabIndex = 42;
            sleepHourTimeNumericUpDown.ValueChanged += sleepHourTimeNumericUpDown_ValueChanged;
            sleepHourTimeNumericUpDown.Leave += sleepHourTimeNumericUpDown_Leave;
            // 
            // sleepSecTimeNumericUpDown
            // 
            sleepSecTimeNumericUpDown.Location = new Point(364, 53);
            sleepSecTimeNumericUpDown.Name = "sleepSecTimeNumericUpDown";
            sleepSecTimeNumericUpDown.Size = new Size(39, 23);
            sleepSecTimeNumericUpDown.TabIndex = 40;
            sleepSecTimeNumericUpDown.TabStop = false;
            sleepSecTimeNumericUpDown.ValueChanged += sleepSecTimeNumericUpDown_ValueChanged;
            sleepSecTimeNumericUpDown.Leave += sleepSecTimeNumericUpDown_Leave;
            // 
            // sleepMinTimeNumericUpDown
            // 
            sleepMinTimeNumericUpDown.Location = new Point(319, 51);
            sleepMinTimeNumericUpDown.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            sleepMinTimeNumericUpDown.Name = "sleepMinTimeNumericUpDown";
            sleepMinTimeNumericUpDown.Size = new Size(38, 23);
            sleepMinTimeNumericUpDown.TabIndex = 38;
            sleepMinTimeNumericUpDown.ValueChanged += sleepMinTimeNumericUpDown_ValueChanged;
            sleepMinTimeNumericUpDown.Leave += sleepMinTimeNumericUpDown_Leave;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F);
            label16.Location = new Point(232, 92);
            label16.Name = "label16";
            label16.Size = new Size(33, 21);
            label16.TabIndex = 36;
            label16.Text = "giờ";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F);
            label15.Location = new Point(6, 93);
            label15.Name = "label15";
            label15.Size = new Size(172, 21);
            label15.TabIndex = 3;
            label15.Text = "Trong khoảng thời gian";
            // 
            // sleepHourUpDown
            // 
            sleepHourUpDown.Location = new Point(188, 92);
            sleepHourUpDown.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            sleepHourUpDown.Name = "sleepHourUpDown";
            sleepHourUpDown.Size = new Size(38, 23);
            sleepHourUpDown.TabIndex = 35;
            sleepHourUpDown.ValueChanged += sleepHourUpDown_ValueChanged;
            sleepHourUpDown.Leave += sleepHourUpDown_Leave;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F);
            label14.Location = new Point(6, 53);
            label14.Name = "label14";
            label14.Size = new Size(80, 21);
            label14.TabIndex = 2;
            label14.Text = "Bắt đầu từ";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 12F);
            label17.Location = new Point(409, 92);
            label17.Name = "label17";
            label17.Size = new Size(39, 21);
            label17.TabIndex = 34;
            label17.Text = "giây";
            label17.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F);
            label13.Location = new Point(6, 18);
            label13.Name = "label13";
            label13.Size = new Size(290, 21);
            label13.TabIndex = 1;
            label13.Text = "Thiết lập thời gian tạm ngừng hoạt động";
            // 
            // sleepSecUpDown
            // 
            sleepSecUpDown.Location = new Point(364, 92);
            sleepSecUpDown.Name = "sleepSecUpDown";
            sleepSecUpDown.Size = new Size(39, 23);
            sleepSecUpDown.TabIndex = 33;
            sleepSecUpDown.TabStop = false;
            sleepSecUpDown.ValueChanged += sleepSecUpDown_ValueChanged;
            sleepSecUpDown.Leave += sleepSecUpDown_Leave;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Segoe UI", 15F);
            dateTimePicker1.CustomFormat = "dd/mm/yyyy";
            dateTimePicker1.Location = new Point(89, 52);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(182, 23);
            dateTimePicker1.TabIndex = 0;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            dateTimePicker1.Leave += dateTimePicker1_Leave;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F);
            label18.Location = new Point(319, 92);
            label18.Name = "label18";
            label18.Size = new Size(42, 21);
            label18.TabIndex = 32;
            label18.Text = "phút";
            label18.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sleepMinUpDown
            // 
            sleepMinUpDown.Location = new Point(271, 92);
            sleepMinUpDown.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            sleepMinUpDown.Name = "sleepMinUpDown";
            sleepMinUpDown.Size = new Size(38, 23);
            sleepMinUpDown.TabIndex = 31;
            sleepMinUpDown.ValueChanged += sleepMinUpDown_ValueChanged;
            sleepMinUpDown.Leave += sleepMinUpDown_Leave;
            // 
            // sysSettingsPanel
            // 
            sysSettingsPanel.BorderStyle = BorderStyle.Fixed3D;
            sysSettingsPanel.Controls.Add(sysSettingGBox);
            sysSettingsPanel.Location = new Point(300, 90);
            sysSettingsPanel.Name = "sysSettingsPanel";
            sysSettingsPanel.Size = new Size(700, 320);
            sysSettingsPanel.TabIndex = 24;
            // 
            // mainTimer
            // 
            mainTimer.Enabled = true;
            mainTimer.Interval = 1;
            mainTimer.Tick += mainTimer_Tick;
            // 
            // videoSettingsPanel
            // 
            videoSettingsPanel.BorderStyle = BorderStyle.Fixed3D;
            videoSettingsPanel.Controls.Add(keepOpeningForm2CheckBox);
            videoSettingsPanel.Controls.Add(playRandomCheckBox);
            videoSettingsPanel.Controls.Add(playAllVideoCheckBox);
            videoSettingsPanel.Controls.Add(textBox1);
            videoSettingsPanel.Controls.Add(button1);
            videoSettingsPanel.Location = new Point(300, 90);
            videoSettingsPanel.Name = "videoSettingsPanel";
            videoSettingsPanel.Size = new Size(700, 320);
            videoSettingsPanel.TabIndex = 25;
            // 
            // keepOpeningForm2CheckBox
            // 
            keepOpeningForm2CheckBox.AutoSize = true;
            keepOpeningForm2CheckBox.Font = new Font("Segoe UI", 15F);
            keepOpeningForm2CheckBox.Location = new Point(46, 186);
            keepOpeningForm2CheckBox.Name = "keepOpeningForm2CheckBox";
            keepOpeningForm2CheckBox.Size = new Size(521, 32);
            keepOpeningForm2CheckBox.TabIndex = 4;
            keepOpeningForm2CheckBox.Text = "Giữ nguyên thời gian nghỉ bỏ qua việc video đã kết thúc";
            keepOpeningForm2CheckBox.UseVisualStyleBackColor = true;
            keepOpeningForm2CheckBox.CheckedChanged += keepOpeningForm2CheckBox_CheckedChanged;
            // 
            // playRandomCheckBox
            // 
            playRandomCheckBox.AutoSize = true;
            playRandomCheckBox.Font = new Font("Segoe UI", 15F);
            playRandomCheckBox.Location = new Point(46, 148);
            playRandomCheckBox.Name = "playRandomCheckBox";
            playRandomCheckBox.Size = new Size(259, 32);
            playRandomCheckBox.TabIndex = 3;
            playRandomCheckBox.Text = "Phát ngẫu nhiên các video";
            playRandomCheckBox.UseVisualStyleBackColor = true;
            playRandomCheckBox.CheckedChanged += playRandomCheckBox_CheckedChanged;
            // 
            // playAllVideoCheckBox
            // 
            playAllVideoCheckBox.AutoSize = true;
            playAllVideoCheckBox.Font = new Font("Segoe UI", 15F);
            playAllVideoCheckBox.Location = new Point(45, 110);
            playAllVideoCheckBox.Name = "playAllVideoCheckBox";
            playAllVideoCheckBox.Size = new Size(341, 32);
            playAllVideoCheckBox.TabIndex = 2;
            playAllVideoCheckBox.Text = "Phát hết tất cả video trong thư mục";
            playAllVideoCheckBox.UseVisualStyleBackColor = true;
            playAllVideoCheckBox.CheckedChanged += playAllVideoCheckBox_CheckedChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(30, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(418, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F);
            button1.Location = new Point(454, 43);
            button1.Name = "button1";
            button1.Size = new Size(49, 23);
            button1.TabIndex = 0;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // helpTextBox
            // 
            helpTextBox.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            helpTextBox.Location = new Point(-2, -2);
            helpTextBox.MaximumSize = new Size(700, 520);
            helpTextBox.Name = "helpTextBox";
            helpTextBox.ScrollBars = ScrollBars.Vertical;
            helpTextBox.Size = new Size(700, 27);
            helpTextBox.TabIndex = 31;
            // 
            // helpPanel
            // 
            helpPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            helpPanel.BorderStyle = BorderStyle.Fixed3D;
            helpPanel.Controls.Add(helpTextBox);
            helpPanel.Location = new Point(300, 90);
            helpPanel.Name = "helpPanel";
            helpPanel.Size = new Size(700, 320);
            helpPanel.TabIndex = 32;
            // 
            // ExerciseApp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1230, 499);
            Controls.Add(helpPanel);
            Controls.Add(mainPanel);
            Controls.Add(videoSettingsPanel);
            Controls.Add(timeSettingsPanel);
            Controls.Add(sysSettingsPanel);
            Controls.Add(menuGroupBox);
            Controls.Add(pictureBox1);
            Controls.Add(saveAllButton);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ExerciseApp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Health Supporter";
            TopMost = true;
            FormClosing += ExerciseApp_FormClosing;
            Leave += ExerciseApp_Leave;
            Resize += ExerciseApp_Resize;
            sysSettingGBox.ResumeLayout(false);
            sysSettingGBox.PerformLayout();
            timeConfigGBox.ResumeLayout(false);
            timeConfigGBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)stopHourUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)hourUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)stopSecUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)secUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)stopMinUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)minUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            menuGroupBox.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            timeSettingsPanel.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sleepHourTimeNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)sleepSecTimeNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)sleepMinTimeNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)sleepHourUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)sleepSecUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)sleepMinUpDown).EndInit();
            sysSettingsPanel.ResumeLayout(false);
            videoSettingsPanel.ResumeLayout(false);
            videoSettingsPanel.PerformLayout();
            helpPanel.ResumeLayout(false);
            helpPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private CheckBox startwithWinBox;
        private GroupBox sysSettingGBox;
        private GroupBox timeConfigGBox;
        private Label label4;
        private NumericUpDown minUpDown;
        private Button saveAllButton;
        private Button startCountButton;
        private Button stopCountButton;
        private Button resetCountButton;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox1;
        private Label label6;
        private Label countStateButton;
        private Button helpButton;
        private NotifyIcon notifyIcon1;
        private Label label7;
        private Label timeLabel;
        private System.Windows.Forms.Timer timer2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem mởỨngDụngToolStripMenuItem;
        private ToolStripMenuItem bắtĐầuToolStripMenuItem;
        private ToolStripMenuItem dừngToolStripMenuItem;
        private ToolStripMenuItem kếtThúcToolStripMenuItem;
        private Label label3;
        private NumericUpDown secUpDown;
        private Label label10;
        private Label label9;
        private Label label5;
        private NumericUpDown stopSecUpDown;
        private Label label8;
        private NumericUpDown stopMinUpDown;
        private GroupBox menuGroupBox;
        private Button settingsButton;
        private Button setTimerButton;
        private Button mainTabButton;
        private Button videoSettingsButton;
        private Panel mainPanel;
        private GroupBox groupBox1;
        private Label label11;
        private NumericUpDown stopHourUpDown;
        private Label label12;
        private NumericUpDown hourUpDown;
        private Panel timeSettingsPanel;
        private GroupBox groupBox3;
        private DateTimePicker dateTimePicker1;
        private Label label13;
        private Label label14;
        private Label label16;
        private Label label15;
        private NumericUpDown sleepHourUpDown;
        private Label label17;
        private NumericUpDown sleepSecUpDown;
        private Label label18;
        private NumericUpDown sleepMinUpDown;
        private Panel sysSettingsPanel;
        private CheckBox useSleepPickerCheckBox;
        private System.Windows.Forms.Timer mainTimer;
        private NumericUpDown sleepHourTimeNumericUpDown;
        private NumericUpDown sleepSecTimeNumericUpDown;
        private NumericUpDown sleepMinTimeNumericUpDown;
        private Panel videoSettingsPanel;
        private TextBox textBox1;
        private Button button1;
        private CheckBox playAllVideoCheckBox;
        private CheckBox keepOpeningForm2CheckBox;
        private CheckBox playRandomCheckBox;
        private TextBox helpTextBox;
        private Panel helpPanel;
    }
}
