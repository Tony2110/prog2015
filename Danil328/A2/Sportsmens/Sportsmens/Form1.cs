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

namespace Sportsmens
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() {Title = "Сохранение данных", Filter = "Участники соревнований|*.sportmens"}; 
            var result = sfd.ShowDialog(this);
            if(result!=DialogResult.OK)
                return;

            var sp = new Sportsmens();
            sp.Name = nameTextBox.Text;
            sp.Surname = surenameTextbox.Text;
            sp.Patronimyc = patronimicTextBox.Text;
            sp.DateofBithday = dateTimePicker1.Value;
            sp.razryad = comboBoxRazryad.Text;
            sp.team = textBoxTeam.Text;
          
            if (maleRadioButton.Checked)
            {
                sp.Gender = Gender.Male;
            }
            else
            {
                sp.Gender = Gender.Female;
            }

            foreach (DostData ed in listBox1.Items)
            {
                sp.Dost.Add(ed);
            }

            var xs = new XmlSerializer(typeof(Sportsmens));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file,sp);
            file.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new DostForm();
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
            var ofd = new OpenFileDialog() { Title = "Загрузка данных", Filter = "Участники соревнований|*.sportmens" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(Sportsmens));
            var file = File.OpenRead(ofd.FileName);
            Sportsmens sp = (Sportsmens) xs.Deserialize(file);
            file.Close();


            nameTextBox.Text = sp.Name;
            surenameTextbox.Text = sp.Surname;
            patronimicTextBox.Text = sp.Patronimyc;
            dateTimePicker1.Value=sp.DateofBithday;
            comboBoxRazryad.Text = sp.razryad;
            textBoxTeam.Text = sp.team;

            if (sp.Gender == Gender.Male)
            {
                maleRadioButton.Checked = true;
                femaleRadioButton.Checked = false;
            }
            else
            {
                maleRadioButton.Checked = false;
                femaleRadioButton.Checked = true;
            }

            foreach (DostData ed in sp.Dost)
            {
                listBox1.Items.Add(ed);
            }   
        }
    }
}
