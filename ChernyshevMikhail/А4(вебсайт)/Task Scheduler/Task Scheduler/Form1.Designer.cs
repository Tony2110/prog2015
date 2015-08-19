namespace Task_Scheduler
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.DataProfilePage = new System.Windows.Forms.TabPage();
            this.LoadPhotoButton = new System.Windows.Forms.Button();
            this.PhotoBox = new System.Windows.Forms.PictureBox();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.PatronymicLabel = new System.Windows.Forms.Label();
            this.SurnameLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.FemaleButton = new System.Windows.Forms.RadioButton();
            this.MaleButton = new System.Windows.Forms.RadioButton();
            this.UserSurname = new System.Windows.Forms.TextBox();
            this.UserPatronymic = new System.Windows.Forms.TextBox();
            this.UserName = new System.Windows.Forms.TextBox();
            this.TasksPage = new System.Windows.Forms.TabPage();
            this.DeleteTaskButton = new System.Windows.Forms.Button();
            this.AddTaskButton = new System.Windows.Forms.Button();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ChangeProfileButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.TabControl1.SuspendLayout();
            this.DataProfilePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).BeginInit();
            this.TasksPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl1.Controls.Add(this.DataProfilePage);
            this.TabControl1.Controls.Add(this.TasksPage);
            this.TabControl1.Location = new System.Drawing.Point(-3, 0);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(630, 364);
            this.TabControl1.TabIndex = 1;
            // 
            // DataProfilePage
            // 
            this.DataProfilePage.Controls.Add(this.LoadPhotoButton);
            this.DataProfilePage.Controls.Add(this.PhotoBox);
            this.DataProfilePage.Controls.Add(this.GenderLabel);
            this.DataProfilePage.Controls.Add(this.PatronymicLabel);
            this.DataProfilePage.Controls.Add(this.SurnameLabel);
            this.DataProfilePage.Controls.Add(this.NameLabel);
            this.DataProfilePage.Controls.Add(this.FemaleButton);
            this.DataProfilePage.Controls.Add(this.MaleButton);
            this.DataProfilePage.Controls.Add(this.UserSurname);
            this.DataProfilePage.Controls.Add(this.UserPatronymic);
            this.DataProfilePage.Controls.Add(this.UserName);
            this.DataProfilePage.Location = new System.Drawing.Point(4, 22);
            this.DataProfilePage.Name = "DataProfilePage";
            this.DataProfilePage.Padding = new System.Windows.Forms.Padding(3);
            this.DataProfilePage.Size = new System.Drawing.Size(622, 338);
            this.DataProfilePage.TabIndex = 0;
            this.DataProfilePage.Text = "Данные профиля";
            this.DataProfilePage.UseVisualStyleBackColor = true;
            // 
            // LoadPhotoButton
            // 
            this.LoadPhotoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadPhotoButton.Location = new System.Drawing.Point(392, 266);
            this.LoadPhotoButton.Name = "LoadPhotoButton";
            this.LoadPhotoButton.Size = new System.Drawing.Size(145, 23);
            this.LoadPhotoButton.TabIndex = 10;
            this.LoadPhotoButton.Text = "Загрузить фото";
            this.LoadPhotoButton.UseVisualStyleBackColor = true;
            this.LoadPhotoButton.Click += new System.EventHandler(this.LoadPhotoButton_Click);
            // 
            // PhotoBox
            // 
            this.PhotoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PhotoBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PhotoBox.Location = new System.Drawing.Point(392, 51);
            this.PhotoBox.Name = "PhotoBox";
            this.PhotoBox.Size = new System.Drawing.Size(145, 197);
            this.PhotoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PhotoBox.TabIndex = 9;
            this.PhotoBox.TabStop = false;
            this.PhotoBox.Click += new System.EventHandler(this.PhotoBox_Click);
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Location = new System.Drawing.Point(66, 228);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(104, 13);
            this.GenderLabel.TabIndex = 8;
            this.GenderLabel.Text = "Пол пользователя:";
            // 
            // PatronymicLabel
            // 
            this.PatronymicLabel.AutoSize = true;
            this.PatronymicLabel.Location = new System.Drawing.Point(63, 154);
            this.PatronymicLabel.Name = "PatronymicLabel";
            this.PatronymicLabel.Size = new System.Drawing.Size(54, 13);
            this.PatronymicLabel.TabIndex = 7;
            this.PatronymicLabel.Text = "Отчество";
            // 
            // SurnameLabel
            // 
            this.SurnameLabel.AutoSize = true;
            this.SurnameLabel.Location = new System.Drawing.Point(63, 103);
            this.SurnameLabel.Name = "SurnameLabel";
            this.SurnameLabel.Size = new System.Drawing.Size(56, 13);
            this.SurnameLabel.TabIndex = 6;
            this.SurnameLabel.Text = "Фамилия";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(63, 51);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(29, 13);
            this.NameLabel.TabIndex = 5;
            this.NameLabel.Text = "Имя";
            this.NameLabel.Click += new System.EventHandler(this.NameLabel_Click);
            // 
            // FemaleButton
            // 
            this.FemaleButton.AutoSize = true;
            this.FemaleButton.Location = new System.Drawing.Point(165, 247);
            this.FemaleButton.Name = "FemaleButton";
            this.FemaleButton.Size = new System.Drawing.Size(51, 17);
            this.FemaleButton.TabIndex = 4;
            this.FemaleButton.TabStop = true;
            this.FemaleButton.Text = "Жен.";
            this.FemaleButton.UseVisualStyleBackColor = true;
            // 
            // MaleButton
            // 
            this.MaleButton.AutoSize = true;
            this.MaleButton.Location = new System.Drawing.Point(66, 247);
            this.MaleButton.Name = "MaleButton";
            this.MaleButton.Size = new System.Drawing.Size(50, 17);
            this.MaleButton.TabIndex = 3;
            this.MaleButton.TabStop = true;
            this.MaleButton.Text = "Муж.";
            this.MaleButton.UseVisualStyleBackColor = true;
            // 
            // UserSurname
            // 
            this.UserSurname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserSurname.Location = new System.Drawing.Point(66, 119);
            this.UserSurname.Name = "UserSurname";
            this.UserSurname.Size = new System.Drawing.Size(246, 20);
            this.UserSurname.TabIndex = 2;
            // 
            // UserPatronymic
            // 
            this.UserPatronymic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserPatronymic.Location = new System.Drawing.Point(66, 170);
            this.UserPatronymic.Name = "UserPatronymic";
            this.UserPatronymic.Size = new System.Drawing.Size(246, 20);
            this.UserPatronymic.TabIndex = 1;
            this.UserPatronymic.TextChanged += new System.EventHandler(this.UserPatronymic_TextChanged);
            // 
            // UserName
            // 
            this.UserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserName.Location = new System.Drawing.Point(66, 67);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(246, 20);
            this.UserName.TabIndex = 0;
            // 
            // TasksPage
            // 
            this.TasksPage.Controls.Add(this.DeleteTaskButton);
            this.TasksPage.Controls.Add(this.AddTaskButton);
            this.TasksPage.Controls.Add(this.ListBox1);
            this.TasksPage.Location = new System.Drawing.Point(4, 22);
            this.TasksPage.Name = "TasksPage";
            this.TasksPage.Padding = new System.Windows.Forms.Padding(3);
            this.TasksPage.Size = new System.Drawing.Size(622, 338);
            this.TasksPage.TabIndex = 1;
            this.TasksPage.Text = "Задачи";
            this.TasksPage.UseVisualStyleBackColor = true;
            // 
            // DeleteTaskButton
            // 
            this.DeleteTaskButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteTaskButton.Location = new System.Drawing.Point(465, 295);
            this.DeleteTaskButton.Name = "DeleteTaskButton";
            this.DeleteTaskButton.Size = new System.Drawing.Size(144, 23);
            this.DeleteTaskButton.TabIndex = 2;
            this.DeleteTaskButton.Text = "Удалить задачу";
            this.DeleteTaskButton.UseVisualStyleBackColor = true;
            this.DeleteTaskButton.Click += new System.EventHandler(this.DeleteTaskButton_Click);
            // 
            // AddTaskButton
            // 
            this.AddTaskButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddTaskButton.Location = new System.Drawing.Point(301, 295);
            this.AddTaskButton.Name = "AddTaskButton";
            this.AddTaskButton.Size = new System.Drawing.Size(144, 23);
            this.AddTaskButton.TabIndex = 1;
            this.AddTaskButton.Text = "Добавить задачу";
            this.AddTaskButton.UseVisualStyleBackColor = true;
            this.AddTaskButton.Click += new System.EventHandler(this.AddTaskButton_Click);
            // 
            // ListBox1
            // 
            this.ListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.Location = new System.Drawing.Point(6, 15);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(610, 264);
            this.ListBox1.TabIndex = 0;
            this.ListBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CloseButton.Location = new System.Drawing.Point(370, 400);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(144, 23);
            this.CloseButton.TabIndex = 10;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ChangeProfileButton
            // 
            this.ChangeProfileButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ChangeProfileButton.Location = new System.Drawing.Point(370, 370);
            this.ChangeProfileButton.Name = "ChangeProfileButton";
            this.ChangeProfileButton.Size = new System.Drawing.Size(144, 23);
            this.ChangeProfileButton.TabIndex = 9;
            this.ChangeProfileButton.Text = "Смена пользователя";
            this.ChangeProfileButton.UseVisualStyleBackColor = true;
            this.ChangeProfileButton.Click += new System.EventHandler(this.ChangeProfileButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PrintButton.Location = new System.Drawing.Point(280, 370);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(75, 52);
            this.PrintButton.TabIndex = 8;
            this.PrintButton.Text = "Печать";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LoadButton.Location = new System.Drawing.Point(120, 400);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(144, 23);
            this.LoadButton.TabIndex = 7;
            this.LoadButton.Text = "Загрузить";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SaveButton.Location = new System.Drawing.Point(120, 370);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(144, 23);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ChangeProfileButton);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.TabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "Form1";
            this.Text = "Планировщик задач";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TabControl1.ResumeLayout(false);
            this.DataProfilePage.ResumeLayout(false);
            this.DataProfilePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhotoBox)).EndInit();
            this.TasksPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage DataProfilePage;
        internal System.Windows.Forms.Button LoadPhotoButton;
        internal System.Windows.Forms.Label GenderLabel;
        internal System.Windows.Forms.Label PatronymicLabel;
        internal System.Windows.Forms.Label SurnameLabel;
        internal System.Windows.Forms.Label NameLabel;
        internal System.Windows.Forms.RadioButton FemaleButton;
        internal System.Windows.Forms.RadioButton MaleButton;
        internal System.Windows.Forms.TextBox UserSurname;
        internal System.Windows.Forms.TextBox UserPatronymic;
        internal System.Windows.Forms.TextBox UserName;
        internal System.Windows.Forms.TabPage TasksPage;
        internal System.Windows.Forms.Button DeleteTaskButton;
        internal System.Windows.Forms.Button AddTaskButton;
        internal System.Windows.Forms.ListBox ListBox1;
        internal System.Windows.Forms.Button CloseButton;
        internal System.Windows.Forms.Button ChangeProfileButton;
        internal System.Windows.Forms.Button PrintButton;
        internal System.Windows.Forms.Button LoadButton;
        internal System.Windows.Forms.Button SaveButton;
        internal System.Windows.Forms.PictureBox PhotoBox;
    }
}

