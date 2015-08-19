using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevExpress.XtraReports.UI;

namespace MatCen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var form = new MatForm();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                listBox.Items.Add(form.Data);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            listBox.Items.RemoveAt(listBox.SelectedIndices[0]);
        }
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeleteButton.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Title = "Сохранение данных", Filter = "файл доверенности|*.mc" };
            var result = sfd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var mcd = new MatCenData();
            mcd.NazvOrg = NazvOrg.Text;
            mcd.GiveDate = GiveDate.Value;
            mcd.LongDate = LongDate.Value;
            mcd.NaimAdress = NaimAdress.Text;
            mcd.CountNumber = CountNumber.Text;
            mcd.Bank = Bank.Text;
            mcd.Job = Job.Text;
            mcd.SurName = SurName.Text;
            mcd.Name1 = Name1.Text;
            mcd.PatronimicName = PatronimicName.Text;
            mcd.PassSer = PassSer.Text;
            mcd.PassNumber = PassNumber.Text;
            mcd.PassGive = PassGive.Text;
            mcd.PassGiveDate = PassGiveDate.Value;
            mcd.DillerName = DillerName.Text;
            mcd.NaimNumberDocum = NaimNumberDocum.Text;
            mcd.DateDocum = DateDocum.Value;

            foreach (MatData ed in listBox.Items)
            {
                mcd.Mat.Add(ed);
            }

           // MatCenData mcd = GeMatCenData();
            
            var xs = new XmlSerializer(typeof(MatCenData));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, mcd);
            file.Close();
        }

       /* public MatCenData GeMatCenData()
        {
            var mcd = new MatCenData();
            mcd.NazvOrg = NazvOrg.Text;
            mcd.GiveDate = GiveDate.Value;
            mcd.LongDate = LongDate.Value;
            mcd.NaimAdress = NaimAdress.Text;
            mcd.CountNumber = CountNumber.Text;
            mcd.Bank = Bank.Text;
            mcd.Job = Job.Text;
            mcd.SurName = SurName.Text;
            mcd.Name1 = Name1.Text;
            mcd.PatronimicName = PatronimicName.Text;
            mcd.PassSer = PassSer.Text;
            mcd.PassNumber = PassNumber.Text;
            mcd.PassGive = PassGive.Text;
            mcd.PassGiveDate = PassGiveDate.Value;
            mcd.DillerName = DillerName.Text;
            mcd.NaimNumberDocum = NaimNumberDocum.Text;
            mcd.DateDocum = DateDocum.Value;

            foreach (MatData ed in listBox.Items)
            {
                mcd.Mat.Add(ed);
            }
            return mcd;
        }*/
        private void LoadButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Загрузка данных", Filter = "файл доверенности|*.mc" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(MatCenData));
            var file = File.OpenRead(ofd.FileName);
            MatCenData mcd = (MatCenData)xs.Deserialize(file);
            file.Close();


            NazvOrg.Text = mcd.NazvOrg;
            GiveDate.Value = mcd.GiveDate;
            LongDate.Value = mcd.LongDate;
            NaimAdress.Text = mcd.NaimAdress;
            CountNumber.Text = mcd.CountNumber;
            Bank.Text = mcd.Bank;
            Job.Text = mcd.Job;
            SurName.Text = mcd.SurName;
            Name1.Text = mcd.Name1;
            PatronimicName.Text = mcd.PatronimicName;
            PassSer.Text = mcd.PassSer;
            PassNumber.Text = mcd.PassNumber;
            PassGive.Text = mcd.PassGive;
            PassGiveDate.Value = mcd.PassGiveDate;
            DillerName.Text = mcd.DillerName;
            NaimNumberDocum.Text = mcd.NaimNumberDocum;
            DateDocum.Value = mcd.DateDocum;

            foreach (MatData ed in mcd.Mat)
            {
                listBox.Items.Add(ed);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var mcd = new MatCenData();
            mcd.NazvOrg = NazvOrg.Text;
            mcd.GiveDate = GiveDate.Value;
            mcd.LongDate = LongDate.Value;
            mcd.NaimAdress = NaimAdress.Text;
            mcd.CountNumber = CountNumber.Text;
            mcd.Bank = Bank.Text;
            mcd.Job = Job.Text;
            mcd.SurName = SurName.Text;
            mcd.Name1 = Name1.Text;
            mcd.PatronimicName = PatronimicName.Text;
            mcd.PassSer = PassSer.Text;
            mcd.PassNumber = PassNumber.Text;
            mcd.PassGive = PassGive.Text;
            mcd.PassGiveDate = PassGiveDate.Value;
            mcd.DillerName = DillerName.Text;
            mcd.NaimNumberDocum = NaimNumberDocum.Text;
            mcd.DateDocum = DateDocum.Value;

            foreach (MatData ed in listBox.Items)
            {
                mcd.Mat.Add(ed);
            }

            var rpt = new ReportPrintTool(new MatCenXtraReport()
            {
                DataSource = new BindingSource()
                {
                  DataSource = mcd
                }
            });
            rpt.Report.CreateDocument(false);
            rpt.ShowPreview();


        }

      
    }
}
