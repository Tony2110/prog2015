using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;
using DevExpress.XtraReports.UI;

namespace WindowsFormsApplication2
{
    public partial class MainForm : Form
    {
        public class ResultOfTest
        {
            public string Name { get; set; }
            public DateTime Date_Time { get; set; }
            public string Test_Time { get; set; }
            public int Score_Test { get; set; }
            public int Lenght { get; set; }
            public string Lang { get; set; }
            public override string ToString()
            {
                return string.Format("ФИО:{0} Дата и время:{1} Язык:{5} Длительность:{2} Верно:{3} из {4}", Name, Date_Time, Test_Time, Score_Test, Lenght, Lang);
            }
        }
        public ResultOfTest Parsing(string s)
        {
            var A = new ResultOfTest();
            string[] SL = Regex.Split(s, "ФИО:(.*) Дата и время:(.*) Язык:(.*) Длительность:(.*) Верно:(.*) из (.*)");
            A.Lang = SL[3];
            A.Lenght = Int32.Parse(SL[6]);
            A.Name = SL[1];
            A.Score_Test = Int32.Parse(SL[5]);
            A.Test_Time = SL[4];
            A.Date_Time = DateTime.Parse(SL[2]);
            return A;
        }
        string Checked_Key = string.Empty;
        string ResultTime;
        char[] stringTest = null;
        int LenghtTest = 15;
        int score = 0;
        public MainForm()
        {
            InitializeComponent();
            label6.Text = "15";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0) label11.Text = "Перед сохранением необходимо добавить хотя бы одну строку!";
            else
            {
                var BufferTest = new List<ResultOfTest>();
                var SaveDialog = new SaveFileDialog() { Title = "Сохранение данных", Filter = "файл результата|*.test" };
                var SaveForm = SaveDialog.ShowDialog(this);
                if (SaveForm != DialogResult.OK)
                    return;
                var XConvert = new XmlSerializer(typeof(List<ResultOfTest>));
                var file = File.Create(SaveDialog.FileName);
                listBox1.SelectedIndex = 0;
                while (listBox1.SelectedIndex < listBox1.Items.Count)
                {
                    BufferTest.Add(Parsing(listBox1.SelectedItem.ToString()));
                    if ((listBox1.Items.Count - listBox1.SelectedIndex) - 1 == 0) break;
                    else listBox1.SelectedIndex += 1;
                }
                    XConvert.Serialize(file, BufferTest);
                    file.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fix.Enabled = false;
            print.BackgroundImage = Properties.Resources.printer;
            print.BackgroundImageLayout = ImageLayout.Center;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Choose_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public ResultOfTest test{get;set;}
        private void Fix_Click(object sender, EventArgs e)
        {
            Fix.Text = "Зафиксировать";
            if (textBox3.Text == string.Empty) { label7.Visible = true; return; }
            else
            {
                label11.Text = string.Empty;
                test = new ResultOfTest();
                test.Name = textBox3.Text;
                test.Lenght = LenghtTest;
                test.Score_Test = score;
                test.Test_Time = ResultTime;
                test.Date_Time = System.DateTime.Now;
                if (En.Checked == true && Ru.Checked == true) test.Lang = "RUS/ENG";
                else if (Ru.Checked == true && En.Checked != true) test.Lang = "RUS";
                else test.Lang = "ENG";
                listBox1.Items.Add(test);
                Fix.Enabled = false;
                En.Enabled = true;
                Ru.Enabled = true;
                trackBar1.Enabled = true;
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            LenghtTest = trackBar1.Value;
            label6.Text = LenghtTest.ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            textBox3.Focus();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fix.Text = "Зафиксировать";
            bool err = true;
            Stopwatch time = new Stopwatch();
            Random rnd = new Random();
            while (err == true)
            {
                if (En.Checked == true && Ru.Checked != true) { stringTest = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' }; label.Text = string.Empty; start.Enabled = false; err = false; label.ForeColor = System.Drawing.Color.Blue; }
                else
                    if (En.Checked != true && Ru.Checked == true) { stringTest = new char[33] { 'Й', 'Ц', 'У', 'К', 'Е', 'Н', 'Г', 'Ш', 'Щ', 'З', 'Х', 'Ъ', 'Ф', 'Ы', 'В', 'А', 'П', 'Р', 'О', 'Л', 'Д', 'Ж', 'Э', 'Я', 'Ч', 'С', 'М', 'И', 'Т', 'Ь', 'Б', 'Ю', 'Ё' }; label.Text = string.Empty; start.Enabled = false; err = false; label.ForeColor = System.Drawing.Color.Red; }
                    else
                        if (En.Checked == true && Ru.Checked == true) { stringTest = new char[59] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'Й', 'Ц', 'У', 'К', 'Е', 'Н', 'Г', 'Ш', 'Щ', 'З', 'Х', 'Ъ', 'Ф', 'Ы', 'В', 'А', 'П', 'Р', 'О', 'Л', 'Д', 'Ж', 'Э', 'Я', 'Ч', 'С', 'М', 'И', 'Т', 'Ь', 'Б', 'Ю', 'Ё' }; label.Text = string.Empty; start.Enabled = false; err = false; }
                        else { label.ForeColor = System.Drawing.Color.Black; label.Text = "?"; return; }
            }
            Ru.Enabled = false;
            En.Enabled = false;
            trackBar1.Enabled = false;
            time.Start();
            score = 0;
            int ind;
            for (int i = 0; i < LenghtTest; i++)//##################################################### цикл теста ###################################################################
            {
                textBox1.Focus();
                label.Text = string.Empty;
                ind = rnd.Next(0, stringTest.Length);
                if (stringTest.Length > 50)
                {
                    if (ind < 26) label.ForeColor = System.Drawing.Color.Blue;
                    else label.ForeColor = System.Drawing.Color.Red;
                }
                label.Text += stringTest[ind];
                while (textBox2.Text==string.Empty) 
                {
                    Application.DoEvents();
                }

                /*ПроверкаНажатой клавиши*/
                if ((Checked_Key == label.Text) || ((Checked_Key == "Q") && (label.Text == "Й")) || ((Checked_Key == "W") && (label.Text == "Ц")) || ((Checked_Key == "E") && (label.Text == "У")) || ((Checked_Key == "R") && (label.Text == "К")) || ((Checked_Key == "T") && (label.Text == "Е")) || ((Checked_Key == "Y") && (label.Text == "Н")) || ((Checked_Key == "U") && (label.Text == "Г")) || ((Checked_Key == "I") && (label.Text == "Ш")) || ((Checked_Key == "O") && (label.Text == "Щ")) || ((Checked_Key == "P") && (label.Text == "З")) || ((Checked_Key == "Oemtilde") && (label.Text == "Ё")) || ((Checked_Key == "A") && (label.Text == "Ф")) || ((Checked_Key == "S") && (label.Text == "Ы")) || ((Checked_Key == "D") && (label.Text == "В")) || ((Checked_Key == "F") && (label.Text == "А")) || ((Checked_Key == "G") && (label.Text == "П")) || ((Checked_Key == "H") && (label.Text == "Р")) || ((Checked_Key == "J") && (label.Text == "О")) || ((Checked_Key == "K") && (label.Text == "Л")) || ((Checked_Key == "L") && (label.Text == "Д")) || ((Checked_Key == "Z") && (label.Text == "Я")) || ((Checked_Key == "X") && (label.Text == "Ч")) || ((Checked_Key == "C") && (label.Text == "С")) || ((Checked_Key == "V") && (label.Text == "М")) || ((Checked_Key == "B") && (label.Text == "И")) || ((Checked_Key == "N") && (label.Text == "Т")) || ((Checked_Key == "M") && (label.Text == "Ь")) || ((Checked_Key == "OemOpenBrackets") && (label.Text == "Х")) || ((Checked_Key == "Oem6") && (label.Text == "Ъ")) || ((Checked_Key == "Oem1") && (label.Text == "Ж")) || ((Checked_Key == "Oem7") && (label.Text == "Э")) || ((Checked_Key == "Oemcomma") && (label.Text == "Б")) || ((Checked_Key == "OemPeriod") && (label.Text == "Ю"))) score += 1;
                textBox2.Text = string.Empty;
                label9.Text = score.ToString();
            }/*################################################### Конец цикла теста ##############################################*/
            TimeSpan ts = time.Elapsed;
            time.Stop();
            label.Text = string.Empty;
            ResultTime = string.Empty;
            ResultTime = string.Format("{0:00}:{1:00}.{2:000}", ts.Minutes, ts.Seconds, ts.Milliseconds);
            TimeLabel.Text = ResultTime;
            Fix.Enabled = true;
            start.Enabled = true;
            Fix.Enabled = true;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Checked_Key = e.KeyCode.ToString();
            textBox2.Text = e.KeyCode.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Del_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0 || listBox1.SelectedIndex == 0) { label11.Text = "Нет доступных позиций для удаления!"; }
            else
            {
                if (listBox1.SelectedIndex == (listBox1.Items.Count - 1)) { Fix.Enabled = true; Fix.Text = "Востановить"; }
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                var QD = new QF();
                var Form = QD.ShowDialog(this);
                if (Form != DialogResult.OK)
                    return;
            }
            {
                var OpenDialog = new OpenFileDialog() { Title = "Загрузка таблицы результатов", Filter = "файл результата|*.test" };
                var result = OpenDialog.ShowDialog(this);
                if (result != DialogResult.OK)
                {
                    return;
                }
                var XConvert = new XmlSerializer(typeof(List<ResultOfTest>));
                var file = File.OpenRead(OpenDialog.FileName);
                List<ResultOfTest> OF = (List<ResultOfTest>)XConvert.Deserialize(file);
                listBox1.Items.Clear();
                foreach (var item in OF)
                {
                    listBox1.Items.Add(item.ToString());
                }
                listBox1.SelectedIndex = 0;
            }
        }
        
        private void print_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                var PrintBuffer = new List<ResultOfTest>();
                listBox1.SelectedIndex = 0;
                while (listBox1.SelectedIndex < listBox1.Items.Count)
                {
                    PrintBuffer.Add(Parsing(listBox1.SelectedItem.ToString()));
                    if ((listBox1.Items.Count - listBox1.SelectedIndex) - 1 == 0) break;
                    else listBox1.SelectedIndex += 1;
                }
                //Printing
                var rpt = new ReportPrintTool(new XtraReport1()
                {
                    DataSource = new BindingSource()
                    {
                        DataSource = PrintBuffer
                    }
                });
                rpt.Report.CreateDocument(false);
                rpt.ShowPreview();
            }
            else label11.Text = "Нечего печатать!";
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            label7.Visible = false;
        }
    }
}