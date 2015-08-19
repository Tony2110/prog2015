using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A2
{
    public partial class BodyForm : Form
    {
        private System.Diagnostics.Stopwatch Time;
        private int i;
        private int UnNum;
        public BodyForm()
        {
            InitializeComponent();
            i = 0;
            UnNum = 0;
            Time = new System.Diagnostics.Stopwatch();
        }

        private void BodyForm_Load(object sender, EventArgs e)
        {
            Time.Start();
            label1.Text = Program.F.LE[i].TextOfExpr;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text == Program.F.LE[i].Answer.ToString())
            {
                if (i != Program.F.LE.Count() - 1)
                {
                    i++;
                    label1.Text = Program.F.LE[i].TextOfExpr;
                    textBox1.Text = string.Empty;
                    textBox1.Focus();
                }
                else Finish(false);
            }
        }

        private void Finish(bool Folded)
        {
            Time.Stop();
            Program.F.LR.Add(new Results(Program.F.textBox1.Text, Program.F.checkBox1.Checked, Folded, (int)Program.F.numericUpDown1.Value, (int)Program.F.numericUpDown2.Value, (int)Program.F.numericUpDown2.Value - UnNum, Time.Elapsed));
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (i != Program.F.LE.Count() - 1)
            {
                UnNum++;
                i++;
                label1.Text = Program.F.LE[i].TextOfExpr;
                textBox1.Text = string.Empty;
                textBox1.Focus();
            }
            else Finish(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UnNum += (int)Program.F.numericUpDown2.Value - i;
            Finish(true);
        }
    }
}