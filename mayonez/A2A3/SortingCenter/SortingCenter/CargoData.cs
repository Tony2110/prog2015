using System;
using System.Collections.Generic;

namespace SortingCenter
{
    public class CargoData
    {

        public CargoData()
        {
            Meow = new List<InsideData>();
        }
        public string Worker { get; set; }

        public DateTime Arriving { get; set; }

        public string Number { get; set; }

        public string Postman { get; set; }

        public List<InsideData> Meow { get; set; }
    }

    public class InsideData
    {
        public string Name { get; set; }
        public string Weight { get; set; }
        public string Words { get; set; }

    public override string ToString()
    {    
       return string.Format("Получено: {0}, Вес: {1}, Комментарий: {2}", Name, Weight, Words);
    }
   
    }
}
