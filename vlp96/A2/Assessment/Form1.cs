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
using System.Drawing.Imaging;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assessment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "*.jpg|*.jpg*|*.png|*.png" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;
            pictureBox1.Image = Image.FromFile(ofd.FileName);
        }
        public void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] directions1 = new string[] { "Банковское дело", "Бухгалтерский учет, анализ и аудит", "Мировая экономика и международный бизнес", "Прикладная экономика", "Финансы и кредит", "Экономика предприятия" };
            string[] directions2 = new string[] { "Журналистика", "Издательское дело", "История", "История искусств", "Культурология", "Прикладная этика" };
            string[] directions3 = new string[] { "Компьютерная безопасность", "Web-программирование", "Математические методы в экономике и финансах", "Математические основы компьютерных наук", "Сетевые технологии", "Системное программирование" };
            string[] directions4 = new string[] { "Информационные системы и технологии", "Информатика и вычислительная техника", "Радиотехника", "Технология полиграфического производства", "Cети связи и системы коммутации", "Системы мобильной связи" };
            string[] directions5 = new string[] { "Технологии разделения изотопов и ядерное топливо", "Химическая технология материалов ЯТЦ", "Ядерные реакторы и материалы", "Стандартизация и метрология в приборостроении", "Физическая электроника", "Ядерная физика и реакторные технологии" };
            ComboBox c = sender as ComboBox;
            switch (c.Text)
            {
                case "Высшая школа экономики и менеджмента":
                    {
                        comboBox3.Items.Clear();
                        comboBox3.Items.AddRange(directions1);
                    }
                    break;
                case "Институт гуманитарных наук и искусств":
                    {
                        comboBox3.Items.Clear();
                        comboBox3.Items.AddRange(directions2);
                    }
                    break;
                case "Институт математики и компьютерных наук":
                    {
                        comboBox3.Items.Clear();
                        comboBox3.Items.AddRange(directions3);
                    }
                    break;
                case "Институт радиоэлектроники и информационных технологий–РтФ":
                    {
                        comboBox3.Items.Clear();
                        comboBox3.Items.AddRange(directions4);
                    }
                    break;
                case "Физико-технологический институт – ФизТех":
                    {
                        comboBox3.Items.Clear();
                        comboBox3.Items.AddRange(directions5);
                    }
                    break;
            }
        }
        public int i = 0;
        public void button2_Click(object sender, EventArgs e)
        {
            var form = new ExamsForm();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                
                listView1.Items.Add(GetListViewItemFromExamData(form.Data));
            }
        }

        private ListViewItem GetListViewItemFromExamData(ExamsData examData)
        {
            ListViewItem lvi = new ListViewItem(examData.Exam);
            lvi.SubItems.Add(examData.Scores);
            lvi.Tag = examData;
            return lvi; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            listView1.SelectedItems[0].Remove();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "*.jpg|*.jpg*|*.png|*.png" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;
            imageList1.Images.Add(Image.FromFile(ofd.FileName));
            listView2.FullRowSelect = true;
            listView2.LargeImageList = imageList1;
            listView2.Items.Add(new ListViewItem(new string[] { "Документ" }, i));
            i++;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0) return;
            listView2.SelectedItems[0].Remove();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Title = "Сохранение анкеты", Filter = "Абитуриент|*.enrollee" };
            var result = sfd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;
            var ed = new EnrolleeData();
            ed.Name = EnName.Text;
            ed.LastName = EnLastName.Text;
            ed.Patronymic = EnPatronymic.Text;
            ed.Birth = DateOfBirth.Value;
            ed.Institute = comboBox2.Text;
            ed.Direction = comboBox3.Text;
            if (pictureBox1.Image != null)
            {
                var ms = new MemoryStream();
                pictureBox1.Image.Save(ms, ImageFormat.Png);
                ed.Photo = ms.GetBuffer();
            }
            if (radioButton1.Checked)
            {
                ed.Gender = Gender.Male;
            }
            else
            {
                ed.Gender = Gender.Female;
            }
            foreach (ListViewItem exd in listView1.Items)
            {
                ed.Exams.Add((ExamsData)exd.Tag);
            }

            foreach (Image image in imageList1.Images)
            {
                
                var ms = new MemoryStream();
                image.Save(ms, ImageFormat.Png);
                ed.Documents.Add(ms.GetBuffer());
            }
           var xs = new XmlSerializer(typeof(EnrolleeData));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, ed);
            file.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Загрузка анкеты", Filter = "Абитуриент|*.enrollee" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;
            var xs = new XmlSerializer(typeof(EnrolleeData));
            var file = File.OpenRead(ofd.FileName);
            EnrolleeData ed = (EnrolleeData)xs.Deserialize(file);
            file.Close();
                EnName.Text = ed.Name;
                EnLastName.Text = ed.LastName;
                EnPatronymic.Text = ed.Patronymic;
                DateOfBirth.Value = ed.Birth;
                comboBox2.Text = ed.Institute;
                comboBox3.Text = ed.Direction;
                if (ed.Gender == Gender.Male)
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
                else
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                }
                listView1.Items.Clear();
                foreach (ExamsData exd in ed.Exams)
                {
                    listView1.Items.Add(GetListViewItemFromExamData(exd));
                }
                if (ed.Photo == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    var ms = new MemoryStream(ed.Photo);
                    pictureBox1.Image = Image.FromStream(ms);
                }


                listView2.Items.Clear();
                imageList1.Images.Clear();
                i = 0;

                listView2.FullRowSelect = true;
                listView2.LargeImageList = imageList1;

                foreach (var d in ed.Documents)
                {
                    imageList1.Images.Add(Image.FromStream(new MemoryStream(d)));
                    listView2.Items.Add(new ListViewItem(new string[] { "Документ" }, i++));
                }
            
        }
     }
}
