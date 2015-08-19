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

namespace Опросник.Создание_конференц_зала
{
    public partial class FormHello : Form
    {
        public string Path { get; set; }
        public FormHello()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.Logo;
        }

        private void FormHello_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ////////////////////////////OFD//////////////////////////////и Path=OFD.FileName
            var OpenDialog = new OpenFileDialog() { Title = "Загрузка результата опроса", Filter = "Результаты опроса|*.Q" };
            var result = OpenDialog.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                return;
            }
            Path = OpenDialog.FileName;
            this.Close();
        }
    }
}
