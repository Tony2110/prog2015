using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public EmploymentData Data { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Data = new EmploymentData();
            Data.Start = dateTimePicker1.Value;
            Data.Name = richTextBox1.Text;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
