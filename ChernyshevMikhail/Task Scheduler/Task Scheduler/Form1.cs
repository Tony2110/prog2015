using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevExpress.XtraReports.Extensions;
using DevExpress.XtraReports.UI;

namespace Task_Scheduler
{
    public partial class Form1 : Form
    {
        public TaskSchedulerData LoadedP;
        public ProfilesForm PF;

        public Form1()
        {
            LoadedP = new TaskSchedulerData();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadPhotoButton_Click(object sender, EventArgs e)
        {
            var photo = new OpenFileDialog() {Filter = "*.png|*.png|*.jpg|*.jpg"};
            var result = photo.ShowDialog(this);
            if (result != DialogResult.OK)
                return;
            PhotoBox.Image = Image.FromFile(photo.FileName);
        }

        private void PhotoBox_Click(object sender, EventArgs e)
        {
            LoadPhotoButton_Click(sender, e);
        }

        private void NameLabel_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (UserName.Text == string.Empty && ListBox1.Items.Count == 0 || PhotoBox.Image == null)
            {
                var RERER = new EmptyError();
                RERER.ShowDialog();
            }
            else
            {

                var pd = new TaskSchedulerData();
                if (!(MaleButton.Checked || FemaleButton.Checked))
                {
                    var box = new NoNoMessageBox();
                    box.ShowDialog();
                    if (box.DialogResult == DialogResult.OK)
                    {
                        pd.Gender = Gender.NoSelected;
                        box.Close();
                    }
                    else
                    {
                        return;
                    }
                }

                var sfd = new SaveFileDialog() {Title = "Сохранение данных", Filter = "файл планировщика|*.ts"};
                var result = sfd.ShowDialog(this);
                if (result != DialogResult.OK)
                    return;


                pd.Name = UserName.Text;
                pd.Surname = UserSurname.Text;
                pd.Patronimyc = UserPatronymic.Text;

                if (PhotoBox.Image != null)
                {
                    var ms = new MemoryStream();
                    PhotoBox.Image.Save(ms, ImageFormat.Png);

                    pd.Photo = ms.GetBuffer();
                }


                if (MaleButton.Checked)
                {
                    pd.Gender = Gender.Male;
                }
                if (FemaleButton.Checked)
                {
                    pd.Gender = Gender.Female;
                }

                foreach (TaskData ed in ListBox1.Items)
                {
                    pd.Tasks.Add(ed);
                }

                var xs = new XmlSerializer(typeof (TaskSchedulerData));
                var file = File.Create(sfd.FileName);
                xs.Serialize(file, pd);
                file.Close();

                var s = Application.StartupPath + "\\Profiles\\" + pd.Name + " " + pd.Patronimyc + " " + pd.Surname;
                file = File.Create(s);
                xs.Serialize(file, pd);
                file.Close();
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() {Title = "Загрузка данных", Filter = "файл планировщика|*.ts"};
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof (TaskSchedulerData));
            var file = File.OpenRead(ofd.FileName);
            TaskSchedulerData pd = (TaskSchedulerData) xs.Deserialize(file);
            file.Close();


            UserName.Text = pd.Name;
            UserSurname.Text = pd.Surname;
            UserPatronymic.Text = pd.Patronimyc;

            if (pd.Gender == Gender.Male)
            {
                MaleButton.Checked = true;
                FemaleButton.Checked = false;
            }
            else
            {
                MaleButton.Checked = false;
                FemaleButton.Checked = true;
            }

            foreach (TaskData ed in pd.Tasks)
            {
                ListBox1.Items.Add(ed);
            }

            if (pd.Photo == null)
            {
                PhotoBox.Image = null;
            }
            else
            {
                var ms = new MemoryStream(pd.Photo);
                PhotoBox.Image = Image.FromStream(ms);
            }
        }

        private void UserPatronymic_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteTaskButton.Enabled = true;
        }

        private void DeleteTaskButton_Click(object sender, EventArgs e)
        {
            if (ListBox1.Items.Count != 0) ListBox1.Items.RemoveAt(ListBox1.SelectedIndices[0]);
        }

        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            var form = new TaskForm();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                ListBox1.Items.Add(form.Data);
            }
        }

        private void ChangeProfileButton_Click(object sender, EventArgs e)
        {
            PF = new ProfilesForm();
            if (PF.ProfBox.Items.Count == 0)
            {
                var EF = new ErrorPF();
                EF.ShowDialog();
            }
            else
            {
                PF.ShowDialog();
                var LoadedProfileName = PF.resultProfile;
                var xs = new XmlSerializer(typeof (TaskSchedulerData));
                var file1 = File.OpenRead(Application.StartupPath + "\\Profiles\\" + LoadedProfileName);
                TaskSchedulerData LoadedP = (TaskSchedulerData) xs.Deserialize(file1);
                file1.Close();
                UserName.Text = LoadedP.Name;
                UserSurname.Text = LoadedP.Surname;
                UserPatronymic.Text = LoadedP.Patronimyc;
                MemoryStream PhotoBuffer = new MemoryStream(LoadedP.Photo);
                PhotoBox.Image = Image.FromStream(PhotoBuffer);
                ListBox1.Items.Clear();
                foreach (TaskData item in LoadedP.Tasks)
                {
                    ListBox1.Items.Add(item);
                }
                switch (LoadedP.Gender)
                {
                    case Gender.Male:
                    {
                        MaleButton.Checked = true;
                    }
                        break;
                    case Gender.Female:
                    {
                        FemaleButton.Checked = true;
                    }
                        break;
                    case Gender.NoSelected:
                        break;
                }
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            var prnt = new ReportPrintTool(new Report()
            {
                DataSource = new BindingSource()
                {
                    DataSource = GetData()
                }
            });
            prnt.Report.CreateDocument(false);
            prnt.ShowPreview();
        }

        public object GetData()
        {
            var td = new TaskSchedulerData();
            td.Name = UserName.Text;
            td.Surname = UserSurname.Text;
            td.Patronimyc = UserPatronymic.Text;
            if (MaleButton.Checked)
            {
                td.Gender = Gender.Male;
            }
            if (FemaleButton.Checked)
            {
                td.Gender = Gender.Female;
            }



            foreach (TaskData ed in ListBox1.Items)
            {
                td.Tasks.Add(ed);
            }


            var ms = new MemoryStream();
            PhotoBox.Image.Save(ms, ImageFormat.Png);
            td.Photo = ms.GetBuffer();

            return td;
        }
    }
}