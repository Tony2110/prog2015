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
using РВП.Class;
using System.Runtime.Serialization.Formatters.Binary;


namespace РВП
{
    public partial class FrmRegister : Form
    {
        Dictionary<int, Trud> dict = new Dictionary<int, Trud>();
        РВП.Class.Passport passport = new Class.Passport();
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                picBoxImage.ImageLocation = dialog.FileName;
            
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var trud = new Trud() { Start=dtStart.Value,End=dtEnd.Value,Dolj=txtDolj.Text,Adress=txtAdress.Text};
            passport.Truds.Add(trud);
            listTrud.Items.Add(trud.ToString());
            dict.Add(listTrud.Items.Count - 1, trud);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            listTrud.Items.Remove(listTrud.SelectedItem);
            passport.Truds.Remove(dict[listTrud.SelectedIndex]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            passport.Name = txtName.Text;
            passport.Surname = txtSurname.Text;
            passport.LastName = txtLastName.Text;
            passport.BirthDate = dtBirthDate.Value;
            passport.Sex = rabtnMale.Checked ? true : false;
            passport.Citizenship = txtCitizenship.Text;
            passport.Serie = txtSerie.Text;
            //ImageConverter converter = new ImageConverter();
            MemoryStream ms = new MemoryStream();
            picBoxImage.Image.Save(ms, picBoxImage.Image.RawFormat);
            
            passport.Photo = ms.ToArray();
            var SaveDialog = new SaveFileDialog();
            SaveDialog.ShowDialog();
            if (!string.IsNullOrEmpty(SaveDialog.FileName))
            {
                Passport.SaveData(passport,SaveDialog.FileName);
            }
            

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var opendialog = new OpenFileDialog();
            opendialog.ShowDialog();
            if (!string.IsNullOrEmpty(opendialog.FileName))
            {
               passport= Passport.LoadData(opendialog.FileName);
            }
            txtName.Text = passport.Name;
            txtSurname.Text = passport.Surname;
            txtLastName.Text = passport.LastName;
            txtSerie.Text = passport.Serie;
            txtCitizenship.Text = passport.Citizenship;
            dtBirthDate.Value = passport.BirthDate;
            if (passport.Sex) rabtnMale.Checked=true;
            else rabtnFemale.Checked = true;
            MemoryStream ms = new MemoryStream(passport.Photo);
            picBoxImage.Image = Image.FromStream(ms);
            dict.Clear();
            listTrud.Items.Clear();
            foreach (var trud in passport.Truds )
            {
                listTrud.Items.Add(trud.ToString());
                
                dict.Add(listTrud.Items.Count -1, trud);
            }
            
        }

        private void авторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Студент группы РИ-230401 Ахмедов Амир","Автор");
             
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void оПриложенииToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Задание A2. Сбор данных", "О приложении");
        }
    }
}
