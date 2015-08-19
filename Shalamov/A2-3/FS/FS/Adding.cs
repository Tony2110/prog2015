using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FS
{
    public partial class Adding : Form
    {
        public Item Added { get; set; }
        public Adding()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Added = new Item();
            Added.Name = textBox1.Text;
            switch (comboBox1.Text)
            {
                case "Dir": Added.Rule = ItemRule.Dir;
                    break;
                case "Item": Added.Rule = ItemRule.Text; break;
                default: break;
            }
            Added.Description = textBox2.Text;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
