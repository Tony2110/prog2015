using DevExpress.XtraReports.UI;
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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            var form = new Form2();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(form.Data);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(form.Data);
            }
        }

        public DayData GetDay()
        {
            var sp = new DayData();
            sp.Name = textBox1.Text;
            sp.Surname = textBox2.Text;


       foreach (EmploymentData ed in listBox1.Items)
        {
        sp.Employments.Add(ed);
        }
          return sp;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "*.png|*.png|*.jpg|*.jpg" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;
            pictureBox1.Image = Image.FromFile(ofd.FileName);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Title = "Сохранение данных", Filter = "файл паспорта|*.passport" };
            var result = sfd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var pd = new DayData();
            pd.Name = textBox1.Text;
            pd.Surname = textBox2.Text;

            if (pictureBox1.Image != null)
            {
                var ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Png);

                pd.Photo = ms.GetBuffer();
            }


                foreach (EmploymentData ed in listBox1.Items)
                {
                    pd.Employments.Add(ed);
                }

                var xs = new XmlSerializer(typeof(DayData));
                var file = File.Create(sfd.FileName);
                xs.Serialize(file, pd);
                file.Close();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Title = "Сохранение данных", Filter = "файл паспорта|*.passport" };
            var result = sfd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var pd = new DayData();
            pd.Name = textBox1.Text;
            pd.Surname = textBox2.Text;

            if (pictureBox1.Image != null)
            {
                var ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Png);

                pd.Photo = ms.GetBuffer();
            }


            foreach (EmploymentData ed in listBox1.Items)
            {
                pd.Employments.Add(ed);
            }

            var xs = new XmlSerializer(typeof(DayData));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, pd);
            file.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
             var ofd = new OpenFileDialog() { Title = "Загрузка данных", Filter = "файл паспорта|*.passport" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(DayData));
            var file = File.OpenRead(ofd.FileName);
            DayData pd = (DayData) xs.Deserialize(file);
            file.Close();


            textBox1.Text = pd.Name;
            textBox2.Text = pd.Surname;


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

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndices[0]);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var rpt = new ReportPrintTool(new RegistrationReport()
            {
                DataSource = new BindingSource()
                {
                    DataSource = GetDay()
                }
            });

            rpt.Report.CreateDocument(false);
            rpt.ShowPreview();
        }
        }
    }
