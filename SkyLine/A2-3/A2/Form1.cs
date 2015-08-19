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
    public partial class Form1 : Form
    {
        public class Ex
        {
            public Ex(int Act, int A, int B)
            {
                switch (Act)
                {
                    case 0:
                        {
                            Answer = A + B;
                            TextOfExpr = string.Format("{0}+{1}", A, B);
                        }break;
                    case 1:
                        {
                            Answer = A - B;
                            TextOfExpr = string.Format("{0}-{1}", A, B);
                        }break;
                    case 2:
                        {
                            Answer = A * B;
                            TextOfExpr = string.Format("{0}*{1}", A, B);
                        }break;
                    default:
                        break;
                }
            }
            public string TextOfExpr { get; set; }
            public long Answer { get; set; }
        }
        public Ex[] LE { get; set; }
        public List<Results> LR { get; set; }
        public Form1()
        {
            InitializeComponent();
            LR = new List<Results>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                int IDAct = 2;
                int IDOper = (int)Math.Pow(10, (double)numericUpDown1.Value);
                if (checkBox1.Checked) IDAct = 3;
                LE = new Ex[(int)numericUpDown2.Value];
                var q = new Random();
                for (int i = 0; i < LE.Count(); i++)
                {
                    LE[i] = new Ex(q.Next(IDAct), q.Next(IDOper - 1), q.Next(IDOper - 1));
                }
                var r = (new HelpForm()).ShowDialog();
                if (r != System.Windows.Forms.DialogResult.OK)
                    return;
                (new BodyForm()).ShowDialog();
                listBox1.Items.Add(LR[LR.Count - 1]);
            }
            else textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(this.Size.Width != 689)
            {
                this.Width = 689;
                button5.Text = "Настройки<<";
                return;
            }
            this.Width = 362;
            button5.Text = "Настройки>>";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var S = new SaveFileDialog()
            {
                Title = "Сохранение",
                Filter = "MathTest's Tabel|*.mtt"
            };
            var res = S.ShowDialog();
            if (res != System.Windows.Forms.DialogResult.OK)
                return;
            var Conv = new System.Xml.Serialization.XmlSerializer(typeof(List<Results>));
            var file = System.IO.File.Create(S.FileName);
            Conv.Serialize(file, LR);
            file.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var O = new OpenFileDialog()
            {
                Title = "Загрузка",
                Filter = "MathTest's Tabel|*.mtt"
            };
            var res = O.ShowDialog();
            if (res != System.Windows.Forms.DialogResult.OK)
                return;
            var conv = new System.Xml.Serialization.XmlSerializer(typeof(List<Results>));
            var file = System.IO.File.OpenRead(O.FileName);
            LR.Clear();
            LR = (List<Results>)conv.Deserialize(file);
            listBox1.Items.Clear();
            foreach (var item in LR)
            {
                listBox1.Items.Add(item);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var R = new XtraReport1();
            R.Filling(LR);
            var RPT = new DevExpress.XtraReports.UI.ReportPrintTool(R);
            RPT.ShowPreview();
        }
    }
}