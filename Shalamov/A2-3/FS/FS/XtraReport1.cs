using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using DevExpress.XtraReports.UI;

namespace FS
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();
        }
        public void AddLabel(List<string> bindingMember, Rectangle bounds)
        {
            
            foreach (var item in bindingMember)
            {
            XRLabel label = new XRLabel();
            Detail.Controls.Add(label);
            label.Location = bounds.Location;
            label.Size = bounds.Size;
            label.Borders = DevExpress.XtraPrinting.BorderSide.All;
            label.Text = item;
            bounds.Y += 23;
            }
        }
    }
}
