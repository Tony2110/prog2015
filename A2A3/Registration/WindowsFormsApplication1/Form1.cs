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
using DevExpress.XtraReports.UI;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Title = "Сохранение данных", Filter = "Участники соревнований|*.participant" };
            var result = sfd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;


            Participant1 par = GetParticipant1();

            var xs = new XmlSerializer(typeof(Participant1));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, par);
            file.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new ParticipantForm();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(form.Data);
            }
        }

        public Participant1 GetParticipant1()
        {
            var par = new Participant1();
            par.TeamName = TeamNameBox.Text;
            par.Town = TownBox.Text;
            par.FI = FIBox.Text;
            par.Size = (int)numericUpDown1.Value;
            par.Email = EmailBox.Text;
            par.TelNumber = TelNumberBox.Text;
            if (MaleButton.Checked)
            {
                par.Gender = Gender.Male;
            }
            else 
            {
                par.Gender = Gender.Female;
            }

            if (JuniorButton.Checked)
            {
                par.TeamAge = TeamAge.Junior;
            }
            else
                if (VarsityButton.Checked)
                {
                    par.TeamAge = TeamAge.Varsity;
                }
                else
                {
                    par.TeamAge = TeamAge.Adult;
                }

            foreach (Participant ed in listBox1.Items)
            {
                par.Part.Add(ed);
            }
            return par;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void Male_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TeamNameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new ParticipantForm();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(form.Data);
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Загрузка данных", Filter = "Участники соревнований|*.participant" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(Participant1));
            var file = File.OpenRead(ofd.FileName);
            Participant1 par = (Participant1)xs.Deserialize(file);
            file.Close();


            listBox1.Items.Clear();
            TeamNameBox.Text = par.TeamName;
            TownBox.Text = par.Town;
            FIBox.Text = par.FI;
            numericUpDown1.Value =(int) par.Size;
            EmailBox.Text = par.Email;
            TelNumberBox.Text = par.TelNumber;

            if (par.Gender == Gender.Male)
            {
                MaleButton.Checked = true;
                FemaleButton.Checked = false;
            }
            else
            {
                MaleButton.Checked = false;
                FemaleButton.Checked = true;
            }

            if (par.TeamAge == TeamAge.Junior)
            {
                JuniorButton.Checked = true;
                VarsityButton.Checked = false;
                AdultButton.Checked = false;
            }
            else
                if (par.TeamAge == TeamAge.Varsity)
                {
                    JuniorButton.Checked = false;
                    VarsityButton.Checked = true;
                    AdultButton.Checked = false;
                }
                else
                {
                    JuniorButton.Checked = false;
                    VarsityButton.Checked = false;
                    AdultButton.Checked = false;
                }
           
            foreach (Participant ed in par.Part)
            {
                listBox1.Items.Add(ed);
            }   
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            var rpt = new ReportPrintTool(new XtraReport1()
            {
                DataSource = new BindingSource()
                {
                    DataSource = GetParticipant1()
                }
            });

            rpt.Report.CreateDocument(false);
            rpt.ShowPreview();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
