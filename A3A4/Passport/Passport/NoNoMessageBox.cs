using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Passport
{
    public partial class NoNoMessageBox : Form
    {
        public NoNoMessageBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool gone;

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            if (!gone)
            {
                jumpingButton.Top += 5 + jumpingButton.Height;
                gone = true;
            }
            else
            {
                jumpingButton.Top -= 5 + jumpingButton.Height;
                gone = false;
            }
        }

        private void jumpingButton_Click(object sender, EventArgs e)
        {
            jumpingButton.Visible = false;
        }

        private void jumpingButton_Enter(object sender, EventArgs e)
        {
            jumpingButton.Visible = false;
        }
    }
}
