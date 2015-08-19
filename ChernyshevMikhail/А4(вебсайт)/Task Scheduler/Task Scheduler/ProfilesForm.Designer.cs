namespace Task_Scheduler
{
    partial class ProfilesForm
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
            this.ProfBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ProfBox
            // 
            this.ProfBox.FormattingEnabled = true;
            this.ProfBox.Location = new System.Drawing.Point(12, 12);
            this.ProfBox.Name = "ProfBox";
            this.ProfBox.Size = new System.Drawing.Size(117, 173);
            this.ProfBox.TabIndex = 0;
            this.ProfBox.SelectedIndexChanged += new System.EventHandler(this.ProfBox_SelectedIndexChanged);
            this.ProfBox.DoubleClick += new System.EventHandler(this.ProfBox_SelectedIndexChanged);
            // 
            // ProfilesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(142, 196);
            this.Controls.Add(this.ProfBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfilesForm";
            this.Text = "Профили";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox ProfBox;

    }
}