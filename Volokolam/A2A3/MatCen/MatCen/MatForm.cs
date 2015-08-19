using System;
using System.Windows.Forms;

namespace MatCen
{
    public partial class MatForm : Form
    {
        public MatForm()
        {
            InitializeComponent();
        }
        public MatData Data { get; set; }


        private void OKButton_Click(object sender, EventArgs e)
        {
            Data = new MatData();
            Data.Naim = Naim.Text;
            Data.Kolvo = Kolvo.Text;
            Data.EdIzm = EdIzm.Text;
            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
