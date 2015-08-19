using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assessment
{
    public class EnrolleeData
    {
        public EnrolleeData()
        {
            Exams = new List<ExamsData>();
            Documents = new List<byte[]>();
        }
        
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string Institute { get; set; }

        public string Direction { get; set; }

        public DateTime Birth { get; set; }

        public Gender Gender { get; set; }

        public List<ExamsData> Exams { get; set; }

        public byte[] Photo { get; set; }

        public List<byte[]> Documents { get; set; }
        
    }
        public class ExamsData
        {
            public string Exam { get; set; }
            public string Scores { get; set; }
        }        
    public enum Gender
    {
        Male,
        Female
    }
}
