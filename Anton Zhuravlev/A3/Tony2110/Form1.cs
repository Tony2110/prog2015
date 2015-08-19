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
using DevExpress.XtraReports.UI;

namespace Tony2110
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     
        private void save_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Title = "Сохранение данных", Filter = "файл наряда|*.nrd" };
            var result = sfd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var zd = new ZakazData();
            zd.Name = nameTextBox.Text;
            zd.Surname = surenameTextBox.Text;
            zd.Patronimyc = patronimicTextBox.Text;
            zd.Mark = markTextbox.Text;
            zd.Model = modelTextbox.Text;
            zd.Year = (int)yearNumeric.Value;
            zd.Mileage = (int)mileageTextbox.Value;

          

                


            if (maleRadioButton.Checked)
            {
                zd.Gender = Gender.Male;
            }
            else
            {
                zd.Gender = Gender.Female;
            }

            foreach (ServiceData ed in listBox1.Items)
            {
                zd.Services.Add(ed);
            }

/*

            File.WriteAllText(sfd.FileName,nameTextBox.Text + Environment.NewLine);
            File.AppendAllText(sfd.FileName, surenameTextbox.Text + "\r\n");
            File.AppendAllText(sfd.FileName, patronimicTextBox.Text+"\r\n");
*/

            var xs = new XmlSerializer(typeof(ZakazData));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, zd);
            file.Close();
        }

         private void button2_Click(object sender, EventArgs e)
        {
            var form = new ServiceForm();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(form.Data);
            }

            RecalcTotals();
        }

         private void RecalcTotals()
         {
             FinalPrice1.Text= listBox1.Items.OfType<ServiceData>().Sum(sd => sd.Price).ToString()+" руб.";
         }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndices[0]);

            RecalcTotals();
        }

        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void open_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Загрузка данных", Filter = "файл наряда|*.nrd" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(ZakazData));
            var file = File.OpenRead(ofd.FileName);
            ZakazData zd = (ZakazData) xs.Deserialize(file);
            file.Close();


            nameTextBox.Text = zd.Name;
            surenameTextBox.Text = zd.Surname;
            patronimicTextBox.Text = zd.Patronimyc;
            markTextbox.Text = zd.Mark;
            modelTextbox.Text = zd.Model;
            yearNumeric.Value = zd.Year;
            mileageTextbox.Value = zd.Mileage;
            

            if (zd.Gender == Gender.Male)
            {
                maleRadioButton.Checked = true;
                femaleRadioButton.Checked = false;
            }
            else
            {
                maleRadioButton.Checked = false;
                femaleRadioButton.Checked = true;
            }

            foreach (ServiceData ed in zd.Services)
            {
                listBox1.Items.Add(ed);
            }
            RecalcTotals();

           
        }

        

       

        private void surenameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void MarkTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void surnameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void printButton_Click(object sender, EventArgs e)
        {
            var prnt = new ReportPrintTool(new Print()
            {
                DataSource = new BindingSource()
                {
                    DataSource = Get()
                }
            });
            prnt.Report.CreateDocument(false);
            prnt.ShowPreview();
        }

        private ZakazData Get()
        {
            var zd = new ZakazData();
            zd.Name = nameTextBox.Text;
            zd.Surname = surenameTextBox.Text;
            zd.Patronimyc = patronimicTextBox.Text;
            zd.Mark = markTextbox.Text;
            zd.Model = modelTextbox.Text;
            zd.Year = (int)yearNumeric.Value;
            zd.Mileage = (int)mileageTextbox.Value;






            if (maleRadioButton.Checked)
            {
                zd.Gender = Gender.Male;
            }
            else
            {
                zd.Gender = Gender.Female;
            }

            foreach (ServiceData ed in listBox1.Items)
            {
                zd.Services.Add(ed);
            }
            return zd;
        }
    }
}
