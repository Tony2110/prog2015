using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Погода
{
    public class City
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Call { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
