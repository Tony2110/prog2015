using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GEK
{
    public partial class CnAddDialog : Form
    {
        public CnAddDialog()
        {
            InitializeComponent();
            //RBCold.Checked = true;
        }


        private void TBID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        public Counter CnData;

        private void button1_Click(object sender, EventArgs e)
        {
            CnData = new Counter();
            CnData.id = TBID.Text;
            CnData.val = TBVal.Text;
            if (RBCold.Checked)
            {
                CnData.water=water.Cold;
            }
            else
            {
                CnData.water = water.Hot;
            }
        }

        private void CnAddDialog_Load(object sender, EventArgs e)
        {
            
        }
    }
}
