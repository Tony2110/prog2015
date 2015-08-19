using System;
using System.Windows.Forms;

namespace SortingCenter
{
    public partial class CargoInfo : Form
    {
        public CargoInfo()
        {
            InitializeComponent();
        }

        public InsideData Meow { get; set; }

      private void button1_Click(object sender, EventArgs e)
        {
          Meow = new InsideData {Name = textbox1.Text, Weight = textbox2.Text, Words = textbox3.Text};
        }

      private void button2_Click(object sender, EventArgs e)
      {
          Close();
      }


    }
}
