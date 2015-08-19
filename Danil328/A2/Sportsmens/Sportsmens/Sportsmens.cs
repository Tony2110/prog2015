using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sportsmens
{
    public class Sportsmens
    {
        public Sportsmens()
        {
            Dost = new List<DostData>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimyc { get; set; }

        public Gender Gender { get; set; }
        public string razryad { get; set; }
        public DateTime DateofBithday { get; set; }
        public string team { get; set; }
        public List<DostData> Dost { get; set; }

    }

    public class DostData
    {
        public DateTime Date { get; set; }
        public string Start { get; set; }
        public string finish { get; set; }
        public string Distantion { get; set; }

        public override string ToString()
        {
            return string.Format("Название старта: {0}, Дата: {1}, Дистанция: {2}, Место: {3}", Start, Date, Distantion, finish);
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
