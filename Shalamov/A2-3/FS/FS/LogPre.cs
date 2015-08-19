using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;

namespace FS
{
    public partial class LogPre : Form
    {
        public LogPre()
        {
            InitializeComponent();
        }

        private void LogPre_Load(object sender, EventArgs e)
        {
            foreach (var item in Program.SessionLog)
            {
                listBox1.Items.Add(item);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var Buf = new List<string>();
            foreach (string item in listBox1.Items)
            {
                Buf.Add(item);
            }
            var r = new XtraReport1();
            r.AddLabel(Buf, new Rectangle(0,0,630,23));
            var printTool = new ReportPrintTool(r);
            printTool.ShowPreview();
        }
    }
}
