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
using DevExpress.XtraReports.UI;

namespace The_Voice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadPhotoButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Filter = "*.jpg|*.jpg*|*.png|*.png" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;
            PhotoBox.Image = Image.FromFile(ofd.FileName);
            label9.Visible = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Title = "Сохранение анкеты", Filter = "Певец|*.singer" };
            var result = sfd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;
            SingerData sd = GetSingerData();
            var xs = new XmlSerializer(typeof(SingerData));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, sd);
            file.Close();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Загрузка анкеты", Filter = "Певец|*.singer" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;
            var xs = new XmlSerializer(typeof(SingerData));
            var file = File.OpenRead(ofd.FileName);
            SingerData sd = (SingerData)xs.Deserialize(file);
            file.Close();
            NameBox.Text = sd.Name;
            GenderBox.Text = sd.Gender;
            HomeTownBox.Text = sd.Hometown;
            RegionBox.Text = sd.Region;
            DateOfBirthBox.Value = sd.DateOfBirth;
            AddressBox.Text = sd.Address;
            PhoneBox.Text = sd.Phone;
            InformationBox.Text = sd.Information;
            
            if (sd.Photo == null)
            {
                PhotoBox.Image = null;
                label9.Visible = true;
            }
            else
            {
                var ms = new MemoryStream(sd.Photo);
                PhotoBox.Image = Image.FromStream(ms);
                label9.Visible = false;
            }
        }

        public SingerData GetSingerData()
        {
            var sd = new SingerData();
            sd.Name = NameBox.Text;
            sd.Gender = GenderBox.Text;
            sd.Region = RegionBox.Text;
            sd.Hometown = HomeTownBox.Text;
            sd.DateOfBirth = DateOfBirthBox.Value;
            sd.Address = AddressBox.Text;
            sd.Phone = PhoneBox.Text;
            sd.Information = InformationBox.Text;
            if (PhotoBox.Image != null)
            {
                var ms = new MemoryStream();
                PhotoBox.Image.Save(ms, ImageFormat.Png);
                sd.Photo = ms.GetBuffer();
            }
            return sd;
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            var rpt = new ReportPrintTool(new TheVoiceReport()
            {
                DataSource = new BindingSource()
                {
                    DataSource = GetSingerData()
                }
            });

            rpt.Report.CreateDocument(false);
            rpt.ShowPreview();
        }

    }
}
