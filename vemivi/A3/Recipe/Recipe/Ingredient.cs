using System;
using System.Windows.Forms;

namespace Recipe
{
    public partial class Ingredient : Form
    {
        public Ingredient()
        {
            InitializeComponent();
        }

        public IngrData Spisok { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Spisok = new IngrData
            {
                name = productName.Text,
                weight = weight.Text
            };
        }
    }
}
