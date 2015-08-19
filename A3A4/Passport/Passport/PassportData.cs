using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Passport
{
    public class PassportData
    {
        public PassportData()
        {
            Employments = new List<EmploymentData>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimyc { get; set; }

        public Gender Gender { get; set; }

        public List<EmploymentData> Employments { get; set; }

        public byte[] Photo { get; set; }

        [XmlIgnore]
        public bool IsMale
        {
            get { return Gender == Gender.Male; }
        }
        [XmlIgnore]
        public bool IsFemale
        {
            get { return Gender == Gender.Female; }
        }

        public string RandomNumber
        {
            get { return new Random().Next().ToString(); }
        }

        public string GenderInRussian
        {
            get
            {
                if (IsMale)
                {
                    return "М";
                }
                return "Ж";
            }
        }
    }

    public class EmploymentData
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format("С: {0}, По: {1}, Место: {2}, Адрес: {3}", Start, End, Name, Address);
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
