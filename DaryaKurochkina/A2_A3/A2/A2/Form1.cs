using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace A2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Загрузка данных", Filter = "файл мероприятия|*.event" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(Event));
            var file = File.OpenRead(ofd.FileName);
            Event cd = (Event)xs.Deserialize(file);
            file.Close();

            dateTimePicker1.Value = cd.dateTimePicker1;
            Time.Text = cd.Time;
            textBox6.Text = cd.textBox6;
            textBox5.Text = cd.textBox5;
            textBox4.Text = cd.textBox4;
            textBox3.Text = cd.textBox3;
            People.Items.Clear();
            foreach (People ed in cd.Form2)
            {
                People.Items.Add(ed);
            }
        }
        private Event GetEvent()
        {
            var cwd = new Event();
            cwd.dateTimePicker1 = dateTimePicker1.Value;
            cwd.Time = Time.Text;
            cwd.textBox6 = textBox6.Text;
            cwd.textBox5 = textBox5.Text;
            cwd.textBox4 = textBox4.Text;
            cwd.textBox3 = textBox3.Text;

            foreach (People ed in People.Items)
            {
                cwd.Form2.Add(ed);
            }
            return cwd;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                People.Items.Add(form.Data);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            People.Items.RemoveAt(People.SelectedIndices[0]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Title = "Сохранение данных", Filter = "файл мероприятия|*.event" };
            var result = sfd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var cd = new Event();

            cd.dateTimePicker1 = dateTimePicker1.Value;
            cd.Time = Time.Text;
            cd.textBox6 = textBox6.Text;
            cd.textBox5 = textBox5.Text;
            cd.textBox4 = textBox4.Text;
            cd.textBox3 = textBox3.Text;

            foreach (People ed in People.Items)
            {
                cd.Form2.Add(ed);
            }

            var xs = new XmlSerializer(typeof(Event));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, cd);
            file.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var rpt = new ReportPrintTool(new Blank()
            {
                DataSource = new BindingSource()
                {
                    DataSource = GetEvent()
                }
            });

            rpt.Report.CreateDocument(false);
            rpt.ShowPreview();
        }
    }
}
