
namespace ExerciseApp
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            panel1 = new Panel();
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            timer1 = new System.Windows.Forms.Timer(components);
            mainLabel = new Label();
            timer2 = new System.Windows.Forms.Timer(components);
            waitPictureBox = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)waitPictureBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(waitPictureBox);
            panel1.Controls.Add(axWindowsMediaPlayer1);
            panel1.Location = new Point(12, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 397);
            panel1.TabIndex = 0;
            // 
            // axWindowsMediaPlayer1
            // 
            axWindowsMediaPlayer1.Dock = DockStyle.Fill;
            axWindowsMediaPlayer1.Enabled = true;
            axWindowsMediaPlayer1.Location = new Point(0, 0);
            axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            axWindowsMediaPlayer1.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer1.OcxState");
            axWindowsMediaPlayer1.Size = new Size(776, 397);
            axWindowsMediaPlayer1.TabIndex = 0;
            axWindowsMediaPlayer1.PlayStateChange += axWindowsMediaPlayer1_PlayStateChange;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // mainLabel
            // 
            mainLabel.AutoSize = true;
            mainLabel.Font = new Font("Arial Narrow", 24F);
            mainLabel.Location = new Point(199, 4);
            mainLabel.Name = "mainLabel";
            mainLabel.Size = new Size(487, 46);
            mainLabel.TabIndex = 1;
            mainLabel.Text = "ĐẾN GIỜ TẬP THỂ DỤC RỒI";
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // waitPictureBox
            // 
            waitPictureBox.Location = new Point(328, 150);
            waitPictureBox.Name = "waitPictureBox";
            waitPictureBox.Size = new Size(125, 62);
            waitPictureBox.TabIndex = 1;
            waitPictureBox.TabStop = false;
            // 
            // Form2
            // 
            AutoScaleMode = AutoScaleMode.Inherit;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(mainLabel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            ShowInTaskbar = false;
            Text = "ĐẾN GIỜ TẬP THỂ DỤC RỒI";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            FormClosing += Form2_Closing;
            Load += Form2_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer1).EndInit();
            ((System.ComponentModel.ISupportInitialize)waitPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Label mainLabel;
        private System.Windows.Forms.Timer timer2;
        private PictureBox waitPictureBox;
    }
}