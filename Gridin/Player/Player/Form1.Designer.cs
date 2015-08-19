namespace Player
{
    partial class PlayerForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            this.ChangePage = new System.Windows.Forms.TabControl();
            this.PlayerPage = new System.Windows.Forms.TabPage();
            this.VolumeLabel = new System.Windows.Forms.Label();
            this.VolumeTrackBar = new System.Windows.Forms.TrackBar();
            this.PlayPauseLabel = new System.Windows.Forms.Label();
            this.EndTime = new System.Windows.Forms.Label();
            this.StartTime = new System.Windows.Forms.Label();
            this.TrackBar = new System.Windows.Forms.TrackBar();
            this.NextTrackButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.StopTrackButton = new System.Windows.Forms.Button();
            this.PreviousTrackButton = new System.Windows.Forms.Button();
            this.PlaylistPage = new System.Windows.Forms.TabPage();
            this.DeleteFilesButton = new System.Windows.Forms.Button();
            this.AddFilesBox = new System.Windows.Forms.ListBox();
            this.LoadFilesButton = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ChangePage.SuspendLayout();
            this.PlayerPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar)).BeginInit();
            this.PlaylistPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChangePage
            // 
            this.ChangePage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangePage.Controls.Add(this.PlayerPage);
            this.ChangePage.Controls.Add(this.PlaylistPage);
            this.ChangePage.Location = new System.Drawing.Point(-1, 0);
            this.ChangePage.Name = "ChangePage";
            this.ChangePage.SelectedIndex = 0;
            this.ChangePage.Size = new System.Drawing.Size(471, 286);
            this.ChangePage.TabIndex = 0;
            // 
            // PlayerPage
            // 
            this.PlayerPage.BackgroundImage = global::Player.Properties.Resources._533;
            this.PlayerPage.Controls.Add(this.VolumeLabel);
            this.PlayerPage.Controls.Add(this.VolumeTrackBar);
            this.PlayerPage.Controls.Add(this.PlayPauseLabel);
            this.PlayerPage.Controls.Add(this.EndTime);
            this.PlayerPage.Controls.Add(this.StartTime);
            this.PlayerPage.Controls.Add(this.TrackBar);
            this.PlayerPage.Controls.Add(this.NextTrackButton);
            this.PlayerPage.Controls.Add(this.PlayButton);
            this.PlayerPage.Controls.Add(this.StopTrackButton);
            this.PlayerPage.Controls.Add(this.PreviousTrackButton);
            this.PlayerPage.Location = new System.Drawing.Point(4, 22);
            this.PlayerPage.Name = "PlayerPage";
            this.PlayerPage.Padding = new System.Windows.Forms.Padding(3);
            this.PlayerPage.Size = new System.Drawing.Size(463, 260);
            this.PlayerPage.TabIndex = 0;
            this.PlayerPage.Text = "Player";
            this.PlayerPage.UseVisualStyleBackColor = true;
            this.PlayerPage.Click += new System.EventHandler(this.PlayerPage_Click);
            // 
            // VolumeLabel
            // 
            this.VolumeLabel.AutoSize = true;
            this.VolumeLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.VolumeLabel.Location = new System.Drawing.Point(61, 123);
            this.VolumeLabel.Name = "VolumeLabel";
            this.VolumeLabel.Size = new System.Drawing.Size(42, 13);
            this.VolumeLabel.TabIndex = 9;
            this.VolumeLabel.Text = "Volume";
            // 
            // VolumeTrackBar
            // 
            this.VolumeTrackBar.BackColor = System.Drawing.Color.Firebrick;
            this.VolumeTrackBar.Location = new System.Drawing.Point(58, 139);
            this.VolumeTrackBar.Name = "VolumeTrackBar";
            this.VolumeTrackBar.Size = new System.Drawing.Size(318, 45);
            this.VolumeTrackBar.TabIndex = 8;
            this.VolumeTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // PlayPauseLabel
            // 
            this.PlayPauseLabel.AutoSize = true;
            this.PlayPauseLabel.BackColor = System.Drawing.Color.Transparent;
            this.PlayPauseLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.PlayPauseLabel.Location = new System.Drawing.Point(61, 49);
            this.PlayPauseLabel.Name = "PlayPauseLabel";
            this.PlayPauseLabel.Size = new System.Drawing.Size(35, 13);
            this.PlayPauseLabel.TabIndex = 7;
            this.PlayPauseLabel.Text = "label1";
            this.PlayPauseLabel.Click += new System.EventHandler(this.button1_Click);
            // 
            // EndTime
            // 
            this.EndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EndTime.AutoSize = true;
            this.EndTime.BackColor = System.Drawing.Color.Firebrick;
            this.EndTime.Location = new System.Drawing.Point(364, 99);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(43, 13);
            this.EndTime.TabIndex = 6;
            this.EndTime.Text = "0:00:00";
            // 
            // StartTime
            // 
            this.StartTime.AutoSize = true;
            this.StartTime.BackColor = System.Drawing.Color.Firebrick;
            this.StartTime.Location = new System.Drawing.Point(58, 99);
            this.StartTime.Name = "StartTime";
            this.StartTime.Size = new System.Drawing.Size(43, 13);
            this.StartTime.TabIndex = 5;
            this.StartTime.Text = "0:00:00";
            this.StartTime.Click += new System.EventHandler(this.StartTime_Click);
            // 
            // TrackBar
            // 
            this.TrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TrackBar.BackColor = System.Drawing.Color.Firebrick;
            this.TrackBar.Enabled = false;
            this.TrackBar.Location = new System.Drawing.Point(58, 68);
            this.TrackBar.Name = "TrackBar";
            this.TrackBar.Size = new System.Drawing.Size(349, 45);
            this.TrackBar.TabIndex = 4;
            this.TrackBar.Scroll += new System.EventHandler(this.TrackBar_Scroll_1);
            this.TrackBar.ValueChanged += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // NextTrackButton
            // 
            this.NextTrackButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NextTrackButton.BackColor = System.Drawing.Color.Firebrick;
            this.NextTrackButton.Enabled = false;
            this.NextTrackButton.Location = new System.Drawing.Point(316, 6);
            this.NextTrackButton.Name = "NextTrackButton";
            this.NextTrackButton.Size = new System.Drawing.Size(75, 23);
            this.NextTrackButton.TabIndex = 1;
            this.NextTrackButton.Text = "►►";
            this.NextTrackButton.UseVisualStyleBackColor = false;
            this.NextTrackButton.Click += new System.EventHandler(this.NextTrackButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PlayButton.BackColor = System.Drawing.Color.Firebrick;
            this.PlayButton.Enabled = false;
            this.PlayButton.Location = new System.Drawing.Point(235, 6);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(75, 23);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "►";
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayPauseButton_Click);
            // 
            // StopTrackButton
            // 
            this.StopTrackButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.StopTrackButton.BackColor = System.Drawing.Color.Firebrick;
            this.StopTrackButton.Enabled = false;
            this.StopTrackButton.Location = new System.Drawing.Point(154, 6);
            this.StopTrackButton.Name = "StopTrackButton";
            this.StopTrackButton.Size = new System.Drawing.Size(75, 23);
            this.StopTrackButton.TabIndex = 1;
            this.StopTrackButton.Text = "■";
            this.StopTrackButton.UseVisualStyleBackColor = false;
            this.StopTrackButton.Click += new System.EventHandler(this.StopTrackButton_Click);
            // 
            // PreviousTrackButton
            // 
            this.PreviousTrackButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PreviousTrackButton.BackColor = System.Drawing.Color.Firebrick;
            this.PreviousTrackButton.Enabled = false;
            this.PreviousTrackButton.Location = new System.Drawing.Point(73, 6);
            this.PreviousTrackButton.Name = "PreviousTrackButton";
            this.PreviousTrackButton.Size = new System.Drawing.Size(75, 23);
            this.PreviousTrackButton.TabIndex = 1;
            this.PreviousTrackButton.Text = "◄◄";
            this.PreviousTrackButton.UseVisualStyleBackColor = false;
            this.PreviousTrackButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // PlaylistPage
            // 
            this.PlaylistPage.BackgroundImage = global::Player.Properties.Resources._533;
            this.PlaylistPage.Controls.Add(this.DeleteFilesButton);
            this.PlaylistPage.Controls.Add(this.AddFilesBox);
            this.PlaylistPage.Controls.Add(this.LoadFilesButton);
            this.PlaylistPage.Location = new System.Drawing.Point(4, 22);
            this.PlaylistPage.Name = "PlaylistPage";
            this.PlaylistPage.Padding = new System.Windows.Forms.Padding(3);
            this.PlaylistPage.Size = new System.Drawing.Size(463, 260);
            this.PlaylistPage.TabIndex = 1;
            this.PlaylistPage.Text = "Playlist";
            this.PlaylistPage.UseVisualStyleBackColor = true;
            // 
            // DeleteFilesButton
            // 
            this.DeleteFilesButton.BackColor = System.Drawing.Color.Firebrick;
            this.DeleteFilesButton.Enabled = false;
            this.DeleteFilesButton.Location = new System.Drawing.Point(293, 225);
            this.DeleteFilesButton.Name = "DeleteFilesButton";
            this.DeleteFilesButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteFilesButton.TabIndex = 4;
            this.DeleteFilesButton.Text = "Delete Files";
            this.DeleteFilesButton.UseVisualStyleBackColor = false;
            this.DeleteFilesButton.Click += new System.EventHandler(this.DeleteFilesButton_Click_1);
            // 
            // AddFilesBox
            // 
            this.AddFilesBox.BackColor = System.Drawing.Color.Firebrick;
            this.AddFilesBox.FormattingEnabled = true;
            this.AddFilesBox.Location = new System.Drawing.Point(9, 6);
            this.AddFilesBox.Name = "AddFilesBox";
            this.AddFilesBox.Size = new System.Drawing.Size(440, 186);
            this.AddFilesBox.TabIndex = 2;
            this.AddFilesBox.SelectedIndexChanged += new System.EventHandler(this.AddFilesBox_SelectedIndexChanged);
            this.AddFilesBox.DoubleClick += new System.EventHandler(this.PlayPauseButton_Click);
            // 
            // LoadFilesButton
            // 
            this.LoadFilesButton.BackColor = System.Drawing.Color.Firebrick;
            this.LoadFilesButton.Location = new System.Drawing.Point(374, 225);
            this.LoadFilesButton.Name = "LoadFilesButton";
            this.LoadFilesButton.Size = new System.Drawing.Size(75, 23);
            this.LoadFilesButton.TabIndex = 1;
            this.LoadFilesButton.Text = "Load Files";
            this.LoadFilesButton.UseVisualStyleBackColor = false;
            this.LoadFilesButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "OpenFileDialog";
            this.OpenFileDialog.Multiselect = true;
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(464, 282);
            this.Controls.Add(this.ChangePage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(640, 480);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 320);
            this.Name = "PlayerForm";
            this.Text = "Player";
            this.ChangePage.ResumeLayout(false);
            this.PlayerPage.ResumeLayout(false);
            this.PlayerPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar)).EndInit();
            this.PlaylistPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ChangePage;
        private System.Windows.Forms.TabPage PlayerPage;
        private System.Windows.Forms.TabPage PlaylistPage;
        private System.Windows.Forms.Button NextTrackButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button StopTrackButton;
        private System.Windows.Forms.Button PreviousTrackButton;
        private System.Windows.Forms.TrackBar TrackBar;
        private System.Windows.Forms.Label EndTime;
        private System.Windows.Forms.Label StartTime;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.ListBox AddFilesBox;
        private System.Windows.Forms.Button LoadFilesButton;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Label PlayPauseLabel;
        private System.Windows.Forms.Label VolumeLabel;
        private System.Windows.Forms.TrackBar VolumeTrackBar;
        private System.Windows.Forms.Button DeleteFilesButton;
    }
}

