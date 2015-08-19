using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sportsmens
{
    public partial class DostForm : Form
    {
        public DostForm()
        {
            InitializeComponent();
        }

        public DostData Data { get; set; }

        public void button1_Click(object sender, EventArgs e)
        {
            Data = new DostData();
            Data.Date = dateTimePicker1.Value;
            Data.Start = textboxStarts.Text;
            Data.finish = textBoxfinish.Text;
            Data.Distantion = textboxDistantion.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
