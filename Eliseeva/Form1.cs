using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Каталог_недвижимости
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Квартира": 
                    this.Size = new System.Drawing.Size(396,368);
                    comboBox2.Visible = true;
                    comboBox5.Visible = true;
                    textBox4.Visible = true;
                    label5.Visible = true;
                    comboBox6.Visible = true;
                    textBox5.Visible = true;
                    label6.Visible = true;
                    label8.Visible = true;
                    comboBox7.Visible = true;
                    checkBox3.Visible = true;
                    //Home
                    comboBox3.Visible = false;
                    label12.Visible = false;
                    checkBox5.Visible = false;
                    checkBox6.Visible = false;
                    checkBox7.Visible = false;
                    textBox7.Visible = false;
                    checkBox8.Visible = false;
                    label10.Visible = false;
                    textBox6.Visible = false;
                    textBox3.Visible = false;
                    //Zem y4astok
                    comboBox8.Visible = false;
                    label11.Visible = false;
                    textBox8.Visible = false;
                    label13.Visible = false;
                    //komer
                    comboBox4.Visible = false;
                    //dop
                    label4.Location = new Point(12,191);
                    textBox6.Location = new Point(135, 191);
                    label7.Location = new Point(12, 217);
                    checkBox2.Location = new Point(178, 217);
                    label9.Location = new Point(12, 243);
                    checkBox1.Location = new Point(178, 243);
                    label14.Location = new Point(12, 269);
                    comboBox9.Location = new Point(135, 269);
                    button1.Location = new Point(209, 295);
                    button3.Location = new Point(125, 295);
                    button2.Location = new Point(290, 295);
                    label4.Visible = true;
                    textBox6.Visible = true;
                    label14.Visible = true;
                    label7.Visible = true;
                    checkBox2.Visible = true;
                    checkBox1.Visible = true;
                    label9.Visible = true;
                    comboBox9.Visible = true;
                     break;
                case "Дом":
                     this.Size = new System.Drawing.Size(396, 414);
                     comboBox3.Visible = true;
                     label12.Visible = true;
                     checkBox5.Visible = true;
                     checkBox6.Visible = true;
                     checkBox7.Visible = true;
                     label5.Visible = true;
                     textBox7.Visible = true;
                     label6.Visible = true;
                     comboBox6.Visible = true;
                     textBox5.Visible = true;
                     checkBox8.Visible = true;
                     label10.Visible = true;
                     textBox3.Visible = true;
                     //kvartira
                     comboBox2.Visible = false;
                     comboBox5.Visible = false;
                     textBox4.Visible = false;
                     label8.Visible = false;
                     comboBox7.Visible = false;
                     checkBox3.Visible = false;
                     //zemelka
                     comboBox8.Visible = false;
                     label11.Visible = false;
                     textBox8.Visible = false;
                     label13.Visible = false;
                     //komer
                     comboBox4.Visible = false;
                    //dop
                    label4.Location = new Point(12,243);
                    textBox6.Location = new Point(135, 243);
                    label7.Location = new Point(12, 269);
                    checkBox2.Location = new Point(178, 269);
                    label9.Location = new Point(12, 295);
                    checkBox1.Location = new Point(178, 295);
                    label14.Location = new Point(12, 321);
                    comboBox9.Location = new Point(135, 321);
                    button1.Location = new Point(209, 347);
                    button3.Location = new Point(125, 347);
                    button2.Location = new Point(290, 347);
                    label4.Visible = true;
                    textBox6.Visible = true;
                    label14.Visible = true;
                    label7.Visible = true;
                    checkBox2.Visible = true;
                    checkBox1.Visible = true;
                    label9.Visible = true;
                    comboBox9.Visible = true;
                     break;
                case "Земельный участок":
                     this.Size = new System.Drawing.Size(396, 338);
                     comboBox8.Visible = true;
                     label11.Visible = true;
                     textBox7.Visible = true;
                     textBox8.Visible = true;
                     label13.Visible = true;
                     //kvartira
                     comboBox2.Visible = false;
                     comboBox5.Visible = false;
                     textBox4.Visible = false;
                     label5.Visible = false;
                     comboBox6.Visible = false;
                     textBox5.Visible = false;
                     label6.Visible = false;
                     label8.Visible = false;
                     comboBox7.Visible = false;
                     checkBox3.Visible = false;
                     //Home
                     comboBox3.Visible = false;
                     label12.Visible = false;
                     checkBox5.Visible = false;
                     checkBox6.Visible = false;
                     checkBox7.Visible = false;
                     checkBox8.Visible = false;
                     label10.Visible = false;
                     textBox3.Visible = false;
                     //komer
                     comboBox4.Visible = false;
                    //dop
                    label4.Location = new Point(12,165);
                    textBox6.Location = new Point(135, 165);
                    label7.Location = new Point(12, 191);
                    checkBox2.Location = new Point(178, 191);
                    label9.Location = new Point(12, 217);
                    checkBox1.Location = new Point(178, 217);
                    label14.Location = new Point(12, 243);
                    comboBox9.Location = new Point(135, 243);
                    button1.Location = new Point(209, 269);
                    button3.Location = new Point(125, 269);
                    button2.Location = new Point(290, 269);
                    label4.Visible = true;
                    textBox6.Visible = true;
                    label14.Visible = true;
                    label7.Visible = true;
                    checkBox2.Visible = true;
                    checkBox1.Visible = true;
                    label9.Visible = true;
                    comboBox9.Visible = true;
                     break;
                case "Коммерческая недвижимость":
                     this.Size = new System.Drawing.Size(396, 338);
                     comboBox4.Visible = true;
                     label5.Visible = true;
                     textBox7.Visible = true;
                     label13.Visible = true;
                     textBox8.Visible = true;
                     //kvartira
                     comboBox2.Visible = false;
                    comboBox5.Visible = false;
                    textBox4.Visible = false;
                    comboBox6.Visible = false;
                    textBox5.Visible = false;
                    label6.Visible = false;
                    label8.Visible = false;
                    comboBox7.Visible = false;
                    checkBox3.Visible = false;
                     //Home
                     comboBox3.Visible = false;
                     label12.Visible = false;
                     checkBox5.Visible = false;
                     checkBox6.Visible = false;
                     checkBox7.Visible = false;
                     checkBox8.Visible = false;
                     label10.Visible = false;
                     textBox3.Visible = false;
                    //zemelka
                    comboBox8.Visible = false;
                     label11.Visible = false;
                     //dop
                     label4.Location = new Point(12, 165);
                     textBox6.Location = new Point(135, 165);
                     label7.Location = new Point(12, 191);
                     checkBox2.Location = new Point(178, 191);
                     label9.Location = new Point(12, 217);
                     checkBox1.Location = new Point(178, 217);
                     label14.Location = new Point(12, 243);
                     comboBox9.Location = new Point(135, 243);
                     button1.Location = new Point(209, 269);
                     button3.Location = new Point(125, 269);
                     button2.Location = new Point(290, 269);
                     label4.Visible = true;
                     textBox6.Visible = true;
                     label14.Visible = true;
                     label7.Visible = true;
                     checkBox2.Visible = true;
                     checkBox1.Visible = true;
                     label9.Visible = true;
                     comboBox9.Visible = true;
                     break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(396, 148);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0) {label1.Text = "Ф.И.О. :"; label1.ForeColor = Color.Black; }
            else
            {
                label1.Text = "Ф.И.О. :*";
                label1.ForeColor = Color.Red;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 0) { label2.Text = "Контактный телефон:"; label2.ForeColor = Color.Black; }
            else
            {
                label2.Text = "Контактный телефон:*";
                label2.ForeColor = Color.Red;
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length != 0) { label3.Text = "Тип объекта:"; label3.ForeColor = Color.Black; }
            else
            {
                label3.Text = "Тип объекта:*";
                label3.ForeColor = Color.Red;
            }
        }

        private void вExcelФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        AllData GenData()
        {
            AllData Some = new AllData();
            foreach (Control v in this.Controls)
            {
                if (v is TextBox)
                {
                    Some.TBoxes.Add(((TextBox)v).Name, ((TextBox)v).Text);
                }
                else if (v is CheckBox)
                {
                    Some.CBoxes.Add(((CheckBox)v).Name, ((CheckBox)v).Checked);
                }
                else if (v is ComboBox)
                {
                    Some.TBoxes.Add(((ComboBox)v).Name, ((ComboBox)v).Text);       
                }
            }
            return Some;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Title = "Сохранение данных", Filter = "Показания счётчиков|*.CNDT" };
            var result = sfd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var DData = GenData();
            var xs = new XmlSerializer(typeof(AllData));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, GenData());
            file.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Сохранение данных", Filter = "Показания счётчиков|*.CNDT" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(AllData));
            var file = File.OpenRead(ofd.FileName);
            AllData Some = (AllData)xs.Deserialize(file);
            file.Close();

            foreach (Control v in this.Controls)
            {
                if (v is TextBox)
                {
                    if (Some.TBoxes.ContainsKey(((TextBox) v).Name))
                        ((TextBox)v).Text = Some.TBoxes[((TextBox)v).Name];
                }
                else if (v is CheckBox)
                {
                    if (Some.CBoxes.ContainsKey(((CheckBox)v).Name))
                        ((CheckBox)v).Checked = Some.CBoxes[((CheckBox)v).Name];
                }
                else if (v is ComboBox)
                {
                    if (Some.TBoxes.ContainsKey(((ComboBox)v).Name))
                        ((ComboBox)v).Text = Some.TBoxes[((ComboBox)v).Name];
                }
            }
        }
    }
}
