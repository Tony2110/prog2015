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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var SesUs = new User(){Login = textBox1.Text, Pass = textBox2.Text};
            var LU = new List<User>();
            var file = File.OpenRead("Logs");
            var sz = new XmlSerializer(typeof(List<User>));
            if (file.Length != 0)
            {
                LU = (List<User>)sz.Deserialize(file);
            }
            file.Close();
            bool SC = false;
            foreach (var item in LU)
            {
                if(item.Login == SesUs.Login && item.Pass == SesUs.Pass)
                {
                    SesUs.UserRule = item.UserRule;
                    SC = true;
                    break;
                }
            }
            if (!SC) { textBox2.SelectAll(); textBox2.Focus() ; return; }
            switch (SesUs.UserRule)
            {
                case Rule.Admin: { var a = new AdminForm(SesUs); Program.SessionLog.Add(string.Format("{0};Пользователь-{1} зашел как {2}!", DateTime.Now.ToString(), SesUs.UserRule, SesUs.Login)); a.ShowDialog(); }
                    break;
                case Rule.User: { var FoulderForm = new Foulder(SesUs); Program.SessionLog.Add(string.Format("{0};Пользователь-{1} зашел как {2}!", DateTime.Now.ToString(), SesUs.UserRule, SesUs.Login)); FoulderForm.ShowDialog(); }
                    break;
                case Rule.Banned: { var ErrForm = new BannForm(); Program.SessionLog.Add(string.Format("{0};Пользователь-{1} пытался зайти как {2}!", DateTime.Now.ToString(), SesUs.UserRule, SesUs.Login)); ErrForm.ShowDialog(); }
                    break;
                case Rule.Moder: { var a = new AdminForm(SesUs); Program.SessionLog.Add(string.Format("{0};Пользователь-{1} зашел как {2}!", DateTime.Now.ToString(), SesUs.UserRule, SesUs.Login)); a.ShowDialog(); }
                    break;
                case Rule.New: { var ErrForm = new BannForm(); Program.SessionLog.Add(string.Format("{0};Пользователь-{1} пытался зайти как {2}!", DateTime.Now.ToString(), SesUs.UserRule, SesUs.Login)); ErrForm.ShowDialog(); }
                    break;
                default:
                    break;
            }
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == textBox4.Text && textBox5.Text != string.Empty)
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
                foreach (var item in LU)
                {
                    if (item.Login == textBox5.Text) err = 1;
                }
                if (err == 0)
                {
                    LU.Add(new User() { Pass = textBox3.Text, Login = textBox5.Text, UserRule = Rule.New });
                    File.Delete("Logs");
                    file = File.OpenWrite("Logs");
                    sz.Serialize(file, LU);
                    file.Close();
                }
                else
                {
                    textBox5.SelectAll();
                    textBox5.Focus();
                    return;
                }
                textBox5.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
            }
            else
            {
                textBox3.Text = string.Empty;
                textBox4.Text = string.Empty;
            }
        }

        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.SessionLog.Clear();
        }
    }
}
