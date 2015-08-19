using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevExpress.XtraReports.UI;

namespace Registration
{
    public partial class Form1 : Form
    {
        public RegestrationData rd { get; set; }
        public Form1()
        {
            rd = new RegestrationData();
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(!(FemaleRadioButton.Checked || MaleRadioButton.Checked))
            {
                var box = new NoNoMessageBox();
                box.ShowDialog(this);
                return;
            }

            var sfd = new SaveFileDialog() {Title = "Сохранение данных", Filter = "Файл регистрации|*.rgsr"};
            var result = sfd.ShowDialog(this);
            if(result!=DialogResult.OK)
            return;
            
            rd = new RegestrationData();
            rd.Name = NameTextBox.Text;
            rd.Surname = SurnameTextBox.Text;
            rd.Patronimyc = PatronimycTextBox.Text;

            if (PictureBox.Image != null)
            {
                var ms = new MemoryStream();
                PictureBox.Image.Save(ms,ImageFormat.Png);

                rd.Photo = ms.GetBuffer();
            }

            if (MaleRadioButton.Checked)
            {
                rd.Gender = Gender.Male;
            }
            else
            {
                rd.Gender = Gender.Female;
            }

            foreach (ConcertData ed in listBox1.Items)
            {
                rd.Concerts.Add(ed);
            }

            var xs = new XmlSerializer(typeof(RegestrationData));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file,rd);
            file.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var form = new ConcertForm();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(form.Data);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndices[0]);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteButton.Enabled = true;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Загрузка данных", Filter = "файл регистрации|*.rgsr" };
            var result = ofd.ShowDialog(this);
            if (result!=DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(RegestrationData));
            var file = File.OpenRead(ofd.FileName);
            rd = (RegestrationData) xs.Deserialize(file);
            file.Close();


            NameTextBox.Text = rd.Name;
            SurnameTextBox.Text = rd.Surname;
            PatronimycTextBox.Text = rd.Patronimyc;

            if (rd.Gender == Gender.Male)
            {
                MaleRadioButton.Checked = true;
                FemaleRadioButton.Checked = false;
            }
            else
            {
                MaleRadioButton.Checked = false;
                FemaleRadioButton.Checked = true;
            }

            foreach (ConcertData ed in rd.Concerts)
            {
                listBox1.Items.Add(ed);
            }

            if (rd.Photo == null)
            {
                PictureBox.Image = null;
            }
            else
            {
                var ms = new MemoryStream(rd.Photo);
                PictureBox.Image = Image.FromStream(ms);
            }
        }

        private void PictureBoxButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() {Filter = "*.png|*.png|*.jpg|*.jpg"};
            var result = ofd.ShowDialog(this);
            if(result!=DialogResult.OK)
                return;
            PictureBox.Image = Image.FromFile(ofd.FileName);
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            if (rd.Concerts.Count() != 0)
            {
                var report = new ReportPrintTool(new Report()
                {
                    DataSource = new BindingSource()
                    {
                        DataSource = rd
                    }
                });
                report.Report.CreateDocument(false);
                report.ShowPreview();
            }
        }
    }
}

