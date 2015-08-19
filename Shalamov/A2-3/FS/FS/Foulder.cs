using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace FS
{
    public partial class Foulder : Form
    {
        private List<Item> Buffer { get; set; }
        private User SesUs { get; set; }
        public Foulder(User S)
        {
            SesUs = S;
            InitializeComponent();
        }

        private void Foulder_Load(object sender, EventArgs e)
        {

            Buffer = new List<Item>();
            var file = File.OpenRead("FS");
            var sz = new XmlSerializer(typeof(List<Item>));
            if (file.Length != 0)
            {
                Buffer = (List<Item>)sz.Deserialize(file);
            }
            else
            {
                Buffer = new List<Item>();
            }
            file.Close();
            foreach (var item in Buffer)
            {
                listBox1.Items.Add(item);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                textBox1.Text = Buffer[listBox1.SelectedIndex].Description;
                Program.SessionLog.Add(string.Format("{0};{1}-Пользователь {2} просмотрел {3}!", DateTime.Now.ToString(), SesUs.UserRule, SesUs.Login, Buffer[listBox1.SelectedIndex].ToString()));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != Buffer[listBox1.SelectedIndex].Description)
            {
                Buffer[listBox1.SelectedIndex].Description = textBox1.Text;
                File.Delete("FS");
                var sz = new XmlSerializer(typeof(List<Item>));
                File.Delete("FS");
                var file = File.OpenWrite("FS");
                sz.Serialize(file, Buffer);
                file.Close();
                Program.SessionLog.Add(string.Format("{0};{1}-Пользователь {2} изменил {3}!",DateTime.Now, SesUs.UserRule, SesUs.Login, listBox1.SelectedItem.ToString()));
            }
        }
    }
}
