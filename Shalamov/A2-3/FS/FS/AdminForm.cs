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
    public partial class AdminForm : Form
    {
        private User SesUs { get; set; }
        public List<Item> Buffer { get; set; }
        public AdminForm(User S)
        {
            SesUs = S;
            Buffer = new List<Item>();
            InitializeComponent();
            if(S.UserRule == Rule.Moder)
            {
                button2.Enabled = false;
                comboBox1.Enabled = false;
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            List<User> LU;
            var file = File.OpenRead("Logs");
            var sz = new XmlSerializer(typeof(List<User>));
            if (file.Length != 0)
            {
                LU = (List<User>)sz.Deserialize(file);
            }
            else
            {
                LU = new List<User>();
            }
            file.Close();
            foreach (var item in LU)
            {
                listBox2.Items.Add(item);
            }
            listBox2.SelectedIndex = 0;
            file = File.OpenRead("FS");
            sz = new XmlSerializer(typeof(List<Item>));
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

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Admin": ChangeUser(Rule.Admin);
                    break;
                case "User": ChangeUser(Rule.User);
                    break;
                case "Moder": ChangeUser(Rule.Moder);
                    break;
                case "Banned": ChangeUser(Rule.Banned);
                    break;
                case "New": ChangeUser(Rule.New);
                    break;
                default:
                    break;
            }
        }
        private void ChangeUser(Rule R)
        {
            var err = (int)0;
            List<User> LU;
            var file = File.OpenRead("Logs");
            var sz = new XmlSerializer(typeof(List<User>));
            if (file.Length != 0)
            {
                LU = (List<User>)sz.Deserialize(file);
            }
            else
            {
                LU = new List<User>();
            }
            file.Close();
            if (err == 0)
            {
                File.Delete("Logs");
                file = File.OpenWrite("Logs");
                LU[listBox2.SelectedIndex].UserRule = R;
                sz.Serialize(file, LU);
                file.Close();
                Program.SessionLog.Add(string.Format("{0};{1}-Пользователь {2} изменил уровень доступа для {3} на {4} !", DateTime.Now.ToString(), SesUs.UserRule, SesUs.Login, listBox2.SelectedItem, R.ToString())); 
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var F = new Adding();
            F.ShowDialog();
            if (F.DialogResult != DialogResult.OK)
                return;
            var S = F.Added;
            Buffer.Add(S);
            listBox1.Items.Add(S);
            var file = File.OpenRead("FS");
            var sz = new XmlSerializer(typeof(List<Item>));
            var Buf = new List<Item>();
            if (file.Length != 0)
            {
                Buf = (List<Item>)sz.Deserialize(file);
            }
            else
            {
                Buf = new List<Item>();
            }
            file.Close();
            Buf.Add(S);
            file = File.OpenWrite("FS");
            sz.Serialize(file, Buf);
            file.Close();
            Program.SessionLog.Add(string.Format("{0};{1}-Пользователь {2} добавил единицу {3}  !", DateTime.Now.ToString(), SesUs.UserRule, SesUs.Login, S));
            Buf = new List<Item>();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.Items.Count != 0)
            {
                textBox1.Text = Buffer[listBox1.SelectedIndex].Description;
                Program.SessionLog.Add(string.Format("{0};{1}-Пользователь {2} просмотрел {3}!", DateTime.Now.ToString(), SesUs.UserRule, SesUs.Login, Buffer[listBox1.SelectedIndex].ToString()));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var F = new LogPre();
            F.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var sz = new XmlSerializer(typeof(List<Item>));
            var S = Buffer[listBox1.SelectedIndex];
            Buffer.RemoveAt(listBox1.SelectedIndex);
            File.Delete("FS");
            var file = File.OpenWrite("FS");
            sz.Serialize(file, Buffer);
            file.Close();
            Program.SessionLog.Add(string.Format("{0};{1}-Пользователь {2} удалил единицу {3}  !", DateTime.Now.ToString(), SesUs.UserRule, SesUs.Login, S));
            listBox1.Items.Clear();
            foreach (var item in Buffer)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != Buffer[listBox1.SelectedIndex].Description)
            {
                Buffer[listBox1.SelectedIndex].Description = textBox1.Text;
                File.Delete("FS");
                var sz = new XmlSerializer(typeof(List<Item>));
                File.Delete("FS");
                var file = File.OpenWrite("FS");
                sz.Serialize(file, Buffer);
                file.Close();
                Program.SessionLog.Add(string.Format("{0};{1}-Пользователь {2} изменил {3}!", DateTime.Now, SesUs.UserRule, SesUs.Login, listBox1.SelectedItem.ToString()));
            }
        }
    }
}
