using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_Scheduler
{
    public partial class TaskForm : Form
    {
        public TaskForm()
        {
            InitializeComponent();
        }

        public TaskData Data { get; set; }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TaskForm_Load(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Data = new TaskData();
            Data.Date = dateTimePicker1.Value;
            Data.TextofTask = textBox1.Text;
            if (LowPriorityRadioButton.Checked == true) Data.Priority = "Низкий";
            else
            {
                if (NormPriorityRadioButton.Checked == true) Data.Priority = "Нормальный";
                else Data.Priority = "Высокий";
            }
        }
    }
}
