using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration
{
    public partial class NoNoMessageBox : Form
    {
        public NoNoMessageBox()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            button1.Visible = false;
        }
    }
}
