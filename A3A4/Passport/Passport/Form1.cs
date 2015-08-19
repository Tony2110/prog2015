using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevExpress.XtraReports.UI;

namespace Passport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!(maleRadioButton.Checked || femaleRadioButton.Checked))
            {
                var box = new NoNoMessageBox();
                box.ShowDialog(this);
                return;
            }

            var sfd = new SaveFileDialog() {Title = "Сохранение данных", Filter = "файл паспорта|*.passport" };
            var result = sfd.ShowDialog(this);
            if(result!=DialogResult.OK)
                return;

            PassportData pd = GetPassportData();
/*

            File.WriteAllText(sfd.FileName,nameTextBox.Text + Environment.NewLine);
            File.AppendAllText(sfd.FileName, surenameTextbox.Text + "\r\n");
            File.AppendAllText(sfd.FileName, patronimicTextBox.Text+"\r\n");
*/

            var xs = new XmlSerializer(typeof(PassportData));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file,pd);
            file.Close();
        }

        public PassportData GetPassportData()
        {
            var pd = new PassportData();
            pd.Name = nameTextBox.Text;
            pd.Surname = surenameTextbox.Text;
            pd.Patronimyc = patronimicTextBox.Text;

            if (pictureBox1.Image != null)
            {
                var ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Png);

                pd.Photo = ms.GetBuffer();
            }

            if (maleRadioButton.Checked)
            {
                pd.Gender = Gender.Male;
            }
            else
            {
                pd.Gender = Gender.Female;
            }

            foreach (EmploymentData ed in listBox1.Items)
            {
                pd.Employments.Add(ed);
            }
            return pd;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new EmploymentForm();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(form.Data);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndices[0]);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Загрузка данных", Filter = "файл паспорта|*.passport" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(PassportData));
            var file = File.OpenRead(ofd.FileName);
            PassportData pd = (PassportData) xs.Deserialize(file);
            file.Close();


            nameTextBox.Text = pd.Name;
            surenameTextbox.Text = pd.Surname;
            patronimicTextBox.Text = pd.Patronimyc;

            if (pd.Gender == Gender.Male)
            {
                maleRadioButton.Checked = true;
                femaleRadioButton.Checked = false;
            }
            else
            {
                maleRadioButton.Checked = false;
                femaleRadioButton.Checked = true;
            }

            foreach (EmploymentData ed in pd.Employments)
            {
                listBox1.Items.Add(ed);
            }

            if (pd.Photo == null)
            {
                pictureBox1.Image = null;
            }
            else
            {
                var ms = new MemoryStream(pd.Photo);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() {Filter = "*.png|*.png|*.jpg|*.jpg"};
            var result = ofd.ShowDialog(this);
            if(result!=DialogResult.OK)
                return;
            pictureBox1.Image = Image.FromFile(ofd.FileName);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var rpt = new ReportPrintTool(new PassportReport()
            {
                DataSource = new BindingSource()
                {
                    DataSource = GetPassportData()
                }
            });

            rpt.Report.CreateDocument(false);
            rpt.ShowPreview();
        }
    }
}
