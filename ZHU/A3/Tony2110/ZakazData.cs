using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tony2110
{
    public class ZakazData
    {
        public ZakazData()
        {
            Services = new List<ServiceData>();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronimyc { get; set; }
        public Gender Gender { get; set; }
        public string Mark {get; set; }
        public string Model {get; set; }
        public int Year {get; set; }
        public int Mileage {get; set; }
        public List<ServiceData> Services { get; set; }

    }
    public class ServiceData
    {
        public string Service { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Price { get; set; }

     

        public override string ToString()
        {
            return string.Format("Услуга: {0}, Автомобиль доставлен: {1}, Автомобиль отправлен: {2}, Цена: {3}", Service, Start, End, Price);
        }
    }
    public enum Gender
    {
        Male,
        Female
    }
}

