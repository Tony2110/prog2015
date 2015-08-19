using DevExpress.XtraReports.UI;
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

namespace Zayvka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Title = "Сохранение данных", Filter = "файл заказа|*.zakaz" };
            var result = sfd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var cd = new Zakaz();
            cd.name = name.Text;
            cd.surname = surname.Text;
            cd.place = place.Text;
            cd.time = time.Value;

            foreach (ComicData ed in ComicData.Items)
            {
                cd.Comic.Add(ed);
            }

            var xs = new XmlSerializer(typeof(Zakaz));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file,cd);
            file.Close();
            
        }

        private Zakaz GetZakaz()
        {
            var cd = new Zakaz();
            cd.name = name.Text;
            cd.surname = surname.Text;
            cd.place = place.Text;
            cd.time = time.Value;
            foreach (ComicData ed in ComicData.Items)
            {
                cd.Comic.Add(ed);
            }
            return cd;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var form = new ComicForm();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
                {
                    ComicData.Items.Add(form.Data);
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ComicData.Items.RemoveAt(ComicData.SelectedIndices[0]);
        }

        private void ComicData_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void download_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Загрузка данных", Filter = "файл заказа|*.zakaz" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(Zakaz));
            var file = File.OpenRead(ofd.FileName);
            Zakaz cd = (Zakaz)xs.Deserialize(file);
            file.Close();

           name.Text = cd.name;
           surname.Text = cd.surname;
           place.Text = cd.place;
           time.Value = cd.time;
           ComicData.Items.Clear();
           foreach (ComicData ed in cd.Comic)
           {
               ComicData.Items.Add(ed);
           }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var rpt = new ReportPrintTool(new zayvkaReport1()
            {
                DataSource = new BindingSource()
                {
                    DataSource = GetZakaz()
                }
            });

            rpt.Report.CreateDocument(false);
            rpt.ShowPreview();
        }

            }
}
