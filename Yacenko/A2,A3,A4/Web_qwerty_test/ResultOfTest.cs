using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_qwerty_test
{
    public class ResultOfTest
    {
        public string Name { get; set; }
        public DateTime Date_Time { get; set; }
        public string Test_Time { get; set; }
        public int Score_Test { get; set; }
        public int Lenght { get; set; }
        public string Lang { get; set; }
        public override string ToString()
        {
            return string.Format("ФИО:{0} Дата и время:{1} Язык:{5} Длительность:{2} Верно:{3} из {4}", Name, Date_Time, Test_Time, Score_Test, Lenght, Lang);
        }
    }
}