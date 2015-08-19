using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEK
{
    public class Info
    {
        public Info()
        {
            Counters = new List<Counter>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Adress { get; set; }

        public DateTime Date { get; set; }
        public List<Counter> Counters { get; set; }
    }

    public class Counter
    {
        public water water { get; set; }
        public string id { get; set; }
        public string val { get; set; }
        public override string ToString()
        {
            return string.Format("Вода: {0}, №Счётчика: {1}, Показания: {2}", water==water.Cold?"Холодная":"Горячая", id, val);
        }
    }

    public enum water
    {
        [Description("Горячая")]
        Hot,
        Cold
    }
}
