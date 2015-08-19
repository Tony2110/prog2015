using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recipe
{
    public class ProductData
    {
        public string description { get; set; }


        public ProductData()
        {
            Spisok = new List<IngrData>();
        }

        public List<IngrData> Spisok {get; set; } 
    }

    public class IngrData
    {
        public string name { get; set; }
        public string weight { get; set; }

        public override string ToString()
        {
            return string.Format("Наименование: {0}, Вес/количество: {1}", name, weight);
        }
    }
}
