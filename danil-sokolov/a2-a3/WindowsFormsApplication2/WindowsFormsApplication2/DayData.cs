using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    public class DayData
    {
        public DayData()
        {
            Employments = new List<EmploymentData>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimyc { get; set; }

        public Gender Gender { get; set; }

        public List<EmploymentData> Employments { get; set; }

        public byte[] Photo { get; set; }
    }
        public class EmploymentData
        {
            public DateTime Start { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return string.Format("С: {0}, Место: {1}", Start, Name);
            }
        }
        public enum Gender
        {
            Male,
            Female
        }
    }