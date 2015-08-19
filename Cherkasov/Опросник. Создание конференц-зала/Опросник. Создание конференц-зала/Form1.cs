using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Опросник.Создание_конференц_зала
{
    public partial class Form1 : Form
    {
        private int Lit { get; set; }
        public Form1(string Path)
        {
            Lit = 0;
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Logo;
            var conv = new XmlSerializer(typeof(Person));
            var file = File.OpenRead(Path);
            PastData((Person)conv.Deserialize(file));
            file.Close();
        }

        private void PastData(Person B)
        {
            mail.Text = B.Cont.Email;
            NameBox.Text = B.Cont.Name;
            org.Text = B.Cont.Organization;
            phone.Text = B.Cont.Phone;
            post.Text = B.Cont.Post;
            checkBar.Checked = B.Room.Barriers;
            checkChange.Checked = B.Room.Change;
            comboLight.Text = B.Room.Light;
            comboRedy.Text = B.Room.Redy;
            comboShadow.Text = B.Room.Shadowed;
            numericX.Value = B.Room.XYZ.X;
            numericY.Value = B.Room.XYZ.Y;
            numericZ.Value = B.Room.XYZ.Z;
            checkAdminSpot.Checked = B.Spots.AdminSpot;
            numericSpots.Value = (decimal)B.Spots.Number;
            numericPre.Value = (decimal)B.Spots.NumPres;
            checkPre.Checked = B.Spots.Presidium;
            checkTrib.Checked = B.Spots.Tribune;
            comboSeatsType.Text = B.Spots.Type;
            checkCancelPre.Checked = B.Spots.CP;
            checkCancelTri.Checked = B.Spots.CT;
            textBox1.Text = B.Equipment;
        }
        public Form1()
        {
            Lit = 0;
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Logo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if(Lit < 4 && NameBox.Text != string.Empty && phone.Text != string.Empty)
            {
                Lit++;
                switch (Lit)
                {
                    case 0:
                        {
                            Stap1.Visible = true;
                            stap2.Visible = false;
                            stap3.Visible = false;
                            stap4.Visible = false;
                            button1.Enabled = false;
                        }
                        break;
                    case 1:
                        {
                            Stap1.Visible = false;
                            stap3.Visible = false;
                            stap2.Visible = true;
                            stap4.Visible = false;
                            button1.Enabled = false;
                        }
                        break;
                    case 2:
                        {
                            Stap1.Visible = false;
                            stap2.Visible = false;
                            stap3.Visible = true;
                            stap4.Visible = false;
                            button1.Enabled = false;
                        }
                        break;
                    case 3:
                        {
                            Stap1.Visible = false;
                            stap2.Visible = false;
                            stap3.Visible = false;
                            stap4.Visible = true;
                            button1.Enabled = true;
                            buttonNext.Text = "Печать";
                        }
                        break;
                    case 4:
                        {
                            Stap1.Visible = true;
                            stap2.Visible = false;
                            stap3.Visible = false;
                            stap4.Visible = false;
                            Lit = 0;
                            Print();
                            button1.Enabled = false;
                            buttonNext.Text = "Далее";
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                var F = new EmptyControls();
                F.ShowDialog();
            }
        }

        private void Print()
        {
            var P = new DevExpress.XtraReports.UI.ReportPrintTool(new XtraReport1()
                {
                    DataSource = new BindingSource()
                    {
                        DataSource = GetData()
                    }
                });
            P.Report.CreateDocument(false);
            P.ShowPreview();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if(Lit>0)
            {
                Lit--;
                switch (Lit)
                {
                    case 0:
                        {
                            Stap1.Visible = true;
                            stap2.Visible = false;
                            stap3.Visible = false;
                            stap4.Visible = false;
                            button1.Enabled = false;
                        }
                        break;
                    case 1:
                        {
                            Stap1.Visible = false;
                            stap2.Visible = true;
                            stap3.Visible = false;
                            stap4.Visible = false;
                            button1.Enabled = false;
                        }
                        break;
                    case 2:
                        {
                            Stap1.Visible = false;
                            stap2.Visible = false;
                            stap3.Visible = true;
                            stap4.Visible = false;
                            button1.Enabled = false;
                            buttonNext.Text = "Далее";
                        }
                        break;
                    case 3:
                        {
                            Stap1.Visible = false;
                            stap2.Visible = false;
                            stap3.Visible = false;
                            stap4.Visible = true;
                            button1.Enabled = true;
                            buttonNext.Text = "Печать";
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var SD = new SaveFileDialog() { Title = "Сохранение результатов опроса.", Filter = "Результаты опроса|*.Q" };
            var SaveForm = SD.ShowDialog(this);
            if (SaveForm != DialogResult.OK)
                return;
            var Conv = new XmlSerializer(typeof(Person));
            var file = File.Create(SD.FileName);
            Conv.Serialize(file, GetData());
            file.Close();
        }

        private Person GetData()
        {
            var B = new Person();
            B.Cont.Email = mail.Text;
            B.Cont.Name = NameBox.Text;
            B.Cont.Organization = org.Text;
            B.Cont.Phone = phone.Text;
            B.Cont.Post = post.Text;
            B.Room.Barriers = checkBar.Checked;
            B.Room.Change = checkChange.Checked;
            B.Room.Light = comboLight.Text;
            B.Room.Redy = comboRedy.Text;
            B.Room.Shadowed = comboShadow.Text;
            B.Room.XYZ.X = numericX.Value;
            B.Room.XYZ.Y = numericY.Value;
            B.Room.XYZ.Z = numericZ.Value;
            B.Spots.AdminSpot = checkAdminSpot.Checked;
            B.Spots.Number = (int)numericSpots.Value;
            B.Spots.NumPres = (int)numericPre.Value;
            B.Spots.Presidium = checkPre.Checked;
            B.Spots.Tribune = checkTrib.Checked;
            B.Spots.Type = comboSeatsType.Text;
            B.Spots.CP = checkCancelPre.Checked;
            B.Spots.CT = checkCancelTri.Checked;
            B.Equipment = textBox1.Text;
            return B;
        }
    }
}
