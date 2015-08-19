using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zayvka
{
    public partial class ComicForm : Form
    {
        public ComicForm()
        {
            InitializeComponent();
        }
        public ComicData Data { get; set; }

       
        private void Ok_Click(object sender, EventArgs e)
        {
            Data = new ComicData();
            TryToParse(number.Text);
            Data.publishing = publishing.Text;
            Data.names = names.Text;
            
            
        }
        private void TryToParse(string value)
        {
            int number;    
            bool result = Int32.TryParse(value, out number);
            if (result)
            {
                Data.number = number;
            }
            else
            {
                if (value == null)
                {
                    value = "";
                    var box = new MessageBox();
                    box.ShowDialog(this);
                    return;
                }
                
            }
        }
    }
}
