using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Tony2110
{
    public partial class Print : DevExpress.XtraReports.UI.XtraReport
    {
        public Print()
        {
            InitializeComponent();
        }
        private void xrLabel5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel20_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLabel20.Text = new Random().Next().ToString();
        }
    }
}
