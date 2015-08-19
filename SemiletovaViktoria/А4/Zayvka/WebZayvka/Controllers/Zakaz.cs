using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Zayvka
{
   public class Zakaz
    {

       public Zakaz()
        {
            Comic = new List<ComicData>();
        }

        public string name { get; set; }
        public string surname { get; set; }
        public string place { get; set; }
        public DateTime time { get; set; }

        public List<ComicData> Comic { get; set; }

    }

   public class ComicData
    {
       public string publishing { get; set; }
       public string names { get; set; }
       public int number { get; set; }

        public override string ToString()
        {
            return string.Format("Издательство: {0}, Название комикса: {1}, Количество штук: {2}, ", publishing, names, number);
        }
    }

   }
  