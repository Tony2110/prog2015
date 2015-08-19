using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Каталог_недвижимости
{
    public class AllData
    {
        public AllData()
        {
            TBoxes = new SerializableDictionary<string, string>();
            CBoxes = new SerializableDictionary<string, bool>();
        }

        public SerializableDictionary<string, string> TBoxes { get; set; }
        public SerializableDictionary<string, bool> CBoxes { get; set; }
    }
}
