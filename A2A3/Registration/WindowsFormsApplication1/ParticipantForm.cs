using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class ParticipantForm : Form
    {
        public ParticipantForm()
        {
            InitializeComponent();
        }
        public Participant Data { get; set; }
        private void button2_Click(object sender, EventArgs e)
        {
            Data = new Participant();
            Data.Name = textBoxName.Text;
            Data.Age = textBoxAge.Text;

        }

        private void textBoxAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
