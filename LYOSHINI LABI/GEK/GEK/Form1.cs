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

namespace GEK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Info GenInfo()
        {
            var Inf = new Info();
            
            Inf.Name = TBName.Text;
            Inf.Surname = TBSName.Text;
            Inf.Patronymic = TBPatr.Text;
            Inf.Adress = TBAdr.Text;

            foreach (Counter cn in listBox1.Items)
            {
                Inf.Counters.Add(cn);
            }
            return Inf;
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Title = "Сохранение данных", Filter = "Показания счётчиков|*.CNDT" };
            var result = sfd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;


            var xs = new XmlSerializer(typeof(Info));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, GenInfo());
            file.Close();
        }

        private void BLoad_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Сохранение данных", Filter = "Показания счётчиков|*.CNDT" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(Info));
            var file = File.OpenRead(ofd.FileName);
            Info Inf = (Info)xs.Deserialize(file);
            file.Close();

            TBName.Text = Inf.Name;
            TBSName.Text = Inf.Surname;
            TBPatr.Text = Inf.Patronymic;
            TBAdr.Text = Inf.Adress;

            for (int index = 0; index < Inf.Counters.Count; index++)
            {
                Counter cnt = Inf.Counters[index];
                listBox1.Items.Add(cnt);
            }
        }

        private void BAddItem_Click(object sender, EventArgs e)
        {
            var form = new CnAddDialog();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(form.CnData);
            }
        }

        private void BRemoveItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count != 0)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndices[0]);
            }
    }

        private void BPrint_Click(object sender, EventArgs e)
        {
            var rpt = new ReportPrintTool(new PrintSome()
            {
                DataSource = new BindingSource()
                {
                    DataSource = GenInfo()
                }
            });

            rpt.Report.CreateDocument(false);
            rpt.ShowPreview();
        }

    }
}
