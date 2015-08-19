using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Passport
{
    public partial class PassportReport : DevExpress.XtraReports.UI.XtraReport
    {
        public PassportReport()
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
