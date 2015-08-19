using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Event
    {
       

            public Event()
            {
                Form2 = new List<People>();
            }

            public DateTime dateTimePicker1 { get; set; }
            public string Time { get; set; }
            public string textBox6 { get; set; }
            public string textBox5 { get; set; }
            public string textBox4 { get; set; }
            public string textBox3 { get; set; }
            public List<People> Form2 { get; set; }
        }

        public class People
        {
            public string textBox1 { get; set; }
            public string textBox2 { get; set; }

            public override string ToString()
            {
                return string.Format("Фимилия ИО: {0}; Контактный телефон: {1}", textBox1, textBox2);
            }
        }
}
