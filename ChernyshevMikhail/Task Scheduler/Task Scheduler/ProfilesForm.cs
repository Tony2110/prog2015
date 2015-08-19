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

namespace Task_Scheduler
{
    public partial class ProfilesForm : Form
    {
        public string resultProfile;
        public string[] FilesP;

        public ProfilesForm()
        {
            var s = Application.StartupPath + "\\Profiles\\";
            FilesP = Directory.GetFiles(s);
            InitializeComponent();
            foreach (var item in FilesP)
            {
                s = Path.GetFileName(item);
                ProfBox.Items.Add(s);
            }
        }

        private void ProfBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultProfile = ProfBox.SelectedItem.ToString();
            this.Close();
        }
    }
}