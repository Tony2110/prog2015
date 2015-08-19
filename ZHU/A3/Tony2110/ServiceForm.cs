using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tony2110
{
    public partial class ServiceForm : Form
    {
        public ServiceForm()
        {
            InitializeComponent();
        }

        public ServiceData Data { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Data = new ServiceData();
            Data.Start = dateTimePicker1.Value;
            Data.End = dateTimePicker2.Value;
            Data.Service = serviceTextbox.Text;
            Data.Price = (int)priceTextbox.Value;
        }

        private void priceTextbox_ValueChanged(object sender, EventArgs e)
        {

        } 
    }
}
