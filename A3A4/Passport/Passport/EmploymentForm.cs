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
    public partial class EmploymentForm : Form
    {
        public EmploymentForm()
        {
            InitializeComponent();
        }

        public EmploymentData Data { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Data = new EmploymentData();
            Data.Start = dateTimePicker1.Value;
            Data.End = dateTimePicker2.Value;
            Data.Name = textBox1.Text;
            Data.Address = textBox2.Text;
        }
    }
}
