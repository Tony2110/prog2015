using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.Model;

namespace SortingCenter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Now;
        }

      
        private void SaveButton_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Title = "Сохранение данных", Filter = "Файл товара|*.cargo" };
            var result = sfd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var pd = new CargoData
            {
                Worker = textBox1.Text,
                Arriving = dateTimePicker1.Value,
                Number = textBox2.Text,
                Postman = textBox3.Text
            };

            foreach (InsideData ed in listBox1.Items)
            {
                pd.Meow.Add(ed);
            }

            var xs = new XmlSerializer(typeof(CargoData));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, pd);
            file.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Загрузка данных", Filter = "Файл товара|*.cargo" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(CargoData));
            var file = File.OpenRead(ofd.FileName);
            CargoData pd = (CargoData)xs.Deserialize(file);
            file.Close();


            textBox1.Text = pd.Worker;
            dateTimePicker1.Value = pd.Arriving;
            textBox2.Text = pd.Number;
            textBox3.Text = pd.Postman;

            foreach (InsideData ed in pd.Meow)
            {
                listBox1.Items.Add(ed);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new CargoInfo();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(form.Meow);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndices[0]);       
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        public CargoData GetCargo()
        {
            var a = new CargoData();
            a.Worker = textBox1.Text;
            a.Arriving = dateTimePicker1.Value;
            a.Number = textBox2.Text;
            a.Postman = textBox3.Text;

            foreach (InsideData ed in listBox1.Items)
            {
               a.Meow.Add(ed);
            }

            return a;
        }

        private void print_Click(object sender, EventArgs e)
        {
         var report = new ReportPrintTool
                (new CargoReport()
            {
                DataSource = new BindingSource()
                {
                    DataSource = GetCargo()
                }
            }
                );

            report.Report.CreateDocument(false);
            report.ShowPreview();        
        }
    }

}
