using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration
{
    public class RegestrationData
    {
        public RegestrationData()
        {
            Concerts = new List<ConcertData>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimyc { get; set; }

        public Gender Gender { get; set; }

        public List<ConcertData> Concerts { get; set; }

        public byte[] Photo { get; set; }
    }

    public class ConcertData
    {
        public DateTime Start { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return string.Format("Дата участия: {0}, Концерт: {1}, Место проведения: {2}", Start, Name, Address);
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
