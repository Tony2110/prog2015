namespace WindowsFormsApplication1
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveButton = new System.Windows.Forms.Button();
            this.TeamNameBox = new System.Windows.Forms.TextBox();
            this.TeamName = new System.Windows.Forms.Label();
            this.Town = new System.Windows.Forms.Label();
            this.TownBox = new System.Windows.Forms.TextBox();
            this.FI = new System.Windows.Forms.Label();
            this.FIBox = new System.Windows.Forms.TextBox();
            this.Size = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.TelNumber = new System.Windows.Forms.Label();
            this.TelNumberBox = new System.Windows.Forms.TextBox();
            this.AgeGroup = new System.Windows.Forms.Label();
            this.JuniorButton = new System.Windows.Forms.RadioButton();
            this.AdultButton = new System.Windows.Forms.RadioButton();
            this.VarsityButton = new System.Windows.Forms.RadioButton();
            this.TeamAgePanel = new System.Windows.Forms.Panel();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.MaleButton = new System.Windows.Forms.RadioButton();
            this.FemaleButton = new System.Windows.Forms.RadioButton();
            this.GenderPanel = new System.Windows.Forms.Panel();
            this.PrintButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.TeamAgePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.GenderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveButton.Location = new System.Drawing.Point(626, 414);
            this.saveButton.Margin = new System.Windows.Forms.Padding(0);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(119, 39);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // TeamNameBox
            // 
            this.TeamNameBox.Location = new System.Drawing.Point(160, 22);
            this.TeamNameBox.Name = "TeamNameBox";
            this.TeamNameBox.Size = new System.Drawing.Size(156, 20);
            this.TeamNameBox.TabIndex = 1;
            this.TeamNameBox.TextChanged += new System.EventHandler(this.TeamNameBox_TextChanged);
            // 
            // TeamName
            // 
            this.TeamName.AutoSize = true;
            this.TeamName.Location = new System.Drawing.Point(48, 25);
            this.TeamName.Name = "TeamName";
            this.TeamName.Size = new System.Drawing.Size(106, 13);
            this.TeamName.TabIndex = 2;
            this.TeamName.Text = "Название команды";
            // 
            // Town
            // 
            this.Town.AutoSize = true;
            this.Town.Location = new System.Drawing.Point(336, 25);
            this.Town.Name = "Town";
            this.Town.Size = new System.Drawing.Size(37, 13);
            this.Town.TabIndex = 3;
            this.Town.Text = "Город";
            // 
            // TownBox
            // 
            this.TownBox.Location = new System.Drawing.Point(394, 22);
            this.TownBox.Name = "TownBox";
            this.TownBox.Size = new System.Drawing.Size(156, 20);
            this.TownBox.TabIndex = 4;
            // 
            // FI
            // 
            this.FI.AutoSize = true;
            this.FI.Location = new System.Drawing.Point(48, 77);
            this.FI.Name = "FI";
            this.FI.Size = new System.Drawing.Size(105, 13);
            this.FI.TabIndex = 5;
            this.FI.Text = "Ф.И. руководителя";
            // 
            // FIBox
            // 
            this.FIBox.Location = new System.Drawing.Point(160, 74);
            this.FIBox.Name = "FIBox";
            this.FIBox.Size = new System.Drawing.Size(156, 20);
            this.FIBox.TabIndex = 6;
            // 
            // Size
            // 
            this.Size.AutoSize = true;
            this.Size.Location = new System.Drawing.Point(404, 77);
            this.Size.Name = "Size";
            this.Size.Size = new System.Drawing.Size(97, 13);
            this.Size.TabIndex = 9;
            this.Size.Text = "Размер футболки";
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Location = new System.Drawing.Point(48, 123);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(35, 13);
            this.Email.TabIndex = 11;
            this.Email.Text = "E-mail";
            // 
            // EmailBox
            // 
            this.EmailBox.Location = new System.Drawing.Point(100, 120);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(216, 20);
            this.EmailBox.TabIndex = 12;
            // 
            // TelNumber
            // 
            this.TelNumber.AutoSize = true;
            this.TelNumber.Location = new System.Drawing.Point(336, 123);
            this.TelNumber.Name = "TelNumber";
            this.TelNumber.Size = new System.Drawing.Size(52, 13);
            this.TelNumber.TabIndex = 13;
            this.TelNumber.Text = "Телефон";
            // 
            // TelNumberBox
            // 
            this.TelNumberBox.Location = new System.Drawing.Point(394, 120);
            this.TelNumberBox.Name = "TelNumberBox";
            this.TelNumberBox.Size = new System.Drawing.Size(156, 20);
            this.TelNumberBox.TabIndex = 14;
            // 
            // AgeGroup
            // 
            this.AgeGroup.AutoSize = true;
            this.AgeGroup.Location = new System.Drawing.Point(48, 181);
            this.AgeGroup.Name = "AgeGroup";
            this.AgeGroup.Size = new System.Drawing.Size(122, 13);
            this.AgeGroup.TabIndex = 15;
            this.AgeGroup.Text = "Возрастная категория";
            // 
            // JuniorButton
            // 
            this.JuniorButton.AutoSize = true;
            this.JuniorButton.Location = new System.Drawing.Point(16, 10);
            this.JuniorButton.Name = "JuniorButton";
            this.JuniorButton.Size = new System.Drawing.Size(83, 17);
            this.JuniorButton.TabIndex = 16;
            this.JuniorButton.TabStop = true;
            this.JuniorButton.Text = "Junior (7-12)";
            this.JuniorButton.UseVisualStyleBackColor = true;
            // 
            // AdultButton
            // 
            this.AdultButton.AutoSize = true;
            this.AdultButton.Location = new System.Drawing.Point(257, 10);
            this.AdultButton.Name = "AdultButton";
            this.AdultButton.Size = new System.Drawing.Size(76, 17);
            this.AdultButton.TabIndex = 17;
            this.AdultButton.TabStop = true;
            this.AdultButton.Text = "Adult (18+)";
            this.AdultButton.UseVisualStyleBackColor = true;
            // 
            // VarsityButton
            // 
            this.VarsityButton.AutoSize = true;
            this.VarsityButton.Location = new System.Drawing.Point(137, 10);
            this.VarsityButton.Name = "VarsityButton";
            this.VarsityButton.Size = new System.Drawing.Size(92, 17);
            this.VarsityButton.TabIndex = 18;
            this.VarsityButton.TabStop = true;
            this.VarsityButton.Text = "Varsity (13-18)";
            this.VarsityButton.UseVisualStyleBackColor = true;
            // 
            // TeamAgePanel
            // 
            this.TeamAgePanel.Controls.Add(this.JuniorButton);
            this.TeamAgePanel.Controls.Add(this.VarsityButton);
            this.TeamAgePanel.Controls.Add(this.AdultButton);
            this.TeamAgePanel.Location = new System.Drawing.Point(202, 169);
            this.TeamAgePanel.Name = "TeamAgePanel";
            this.TeamAgePanel.Size = new System.Drawing.Size(348, 39);
            this.TeamAgePanel.TabIndex = 21;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLoad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonLoad.Location = new System.Drawing.Point(459, 414);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(119, 39);
            this.buttonLoad.TabIndex = 22;
            this.buttonLoad.Text = "Загрузить";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(507, 74);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            42,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown1.TabIndex = 23;
            this.numericUpDown1.Value = new decimal(new int[] {
            42,
            0,
            0,
            0});
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(51, 256);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(250, 121);
            this.listBox1.TabIndex = 24;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 28);
            this.button1.TabIndex = 25;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MaleButton
            // 
            this.MaleButton.AutoSize = true;
            this.MaleButton.Location = new System.Drawing.Point(3, 1);
            this.MaleButton.Name = "MaleButton";
            this.MaleButton.Size = new System.Drawing.Size(34, 17);
            this.MaleButton.TabIndex = 7;
            this.MaleButton.TabStop = true;
            this.MaleButton.Text = "М";
            this.MaleButton.UseVisualStyleBackColor = true;
            this.MaleButton.CheckedChanged += new System.EventHandler(this.Male_CheckedChanged);
            // 
            // FemaleButton
            // 
            this.FemaleButton.AutoSize = true;
            this.FemaleButton.Location = new System.Drawing.Point(41, 1);
            this.FemaleButton.Name = "FemaleButton";
            this.FemaleButton.Size = new System.Drawing.Size(36, 17);
            this.FemaleButton.TabIndex = 8;
            this.FemaleButton.TabStop = true;
            this.FemaleButton.Text = "Ж";
            this.FemaleButton.UseVisualStyleBackColor = true;
            // 
            // GenderPanel
            // 
            this.GenderPanel.Controls.Add(this.FemaleButton);
            this.GenderPanel.Controls.Add(this.MaleButton);
            this.GenderPanel.Location = new System.Drawing.Point(322, 74);
            this.GenderPanel.Name = "GenderPanel";
            this.GenderPanel.Size = new System.Drawing.Size(80, 26);
            this.GenderPanel.TabIndex = 20;
            // 
            // PrintButton
            // 
            this.PrintButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PrintButton.Location = new System.Drawing.Point(12, 414);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(119, 39);
            this.PrintButton.TabIndex = 26;
            this.PrintButton.Text = "Печать";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Участники:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // button2
            // 
            this.button2.AccessibleDescription = "";
            this.button2.AccessibleName = "";
            this.button2.Location = new System.Drawing.Point(160, 215);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 28);
            this.button2.TabIndex = 28;
            this.button2.Text = "Очистить список";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(754, 462);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.TeamAgePanel);
            this.Controls.Add(this.GenderPanel);
            this.Controls.Add(this.AgeGroup);
            this.Controls.Add(this.TelNumberBox);
            this.Controls.Add(this.TelNumber);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Size);
            this.Controls.Add(this.FIBox);
            this.Controls.Add(this.FI);
            this.Controls.Add(this.TownBox);
            this.Controls.Add(this.Town);
            this.Controls.Add(this.TeamName);
            this.Controls.Add(this.TeamNameBox);
            this.Controls.Add(this.saveButton);
            this.MaximumSize = new System.Drawing.Size(770, 500);
            this.MinimumSize = new System.Drawing.Size(770, 500);
            this.Name = "MainForm";
            this.Text = "Регистрация команды";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TeamAgePanel.ResumeLayout(false);
            this.TeamAgePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.GenderPanel.ResumeLayout(false);
            this.GenderPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox TeamNameBox;
        private System.Windows.Forms.Label TeamName;
        private System.Windows.Forms.Label Town;
        private System.Windows.Forms.TextBox TownBox;
        private System.Windows.Forms.Label FI;
        private System.Windows.Forms.TextBox FIBox;
        private System.Windows.Forms.Label Size;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.Label TelNumber;
        private System.Windows.Forms.TextBox TelNumberBox;
        private System.Windows.Forms.Label AgeGroup;
        private System.Windows.Forms.RadioButton JuniorButton;
        private System.Windows.Forms.RadioButton AdultButton;
        private System.Windows.Forms.RadioButton VarsityButton;
        private System.Windows.Forms.Panel TeamAgePanel;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton MaleButton;
        private System.Windows.Forms.RadioButton FemaleButton;
        private System.Windows.Forms.Panel GenderPanel;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}

