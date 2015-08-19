using System;
using System.Collections.Generic;


namespace MatCen
{
    public class MatCenData
    {
            public MatCenData()
        {
            Mat = new List<MatData>();
        }

        public string NazvOrg { get; set; }
        public DateTime GiveDate { get; set; }
        public DateTime LongDate { get; set; }
        public string NaimAdress { get; set; }
        public string CountNumber { get; set; }
        public string Bank { get; set; }
        public string Job { get; set; }
        public string SurName { get; set; }
        public string Name1 { get; set; }
        public string PatronimicName { get; set; }
        public string PassSer { get; set; }
        public string PassNumber { get; set; }
        public string PassGive { get; set; }
        public DateTime PassGiveDate { get; set; }
        public string DillerName { get; set; }
        public string NaimNumberDocum { get; set; }
        public DateTime DateDocum { get; set; }




        public List<MatData> Mat { get; set; }

        }
     

        public class MatData
        {
            public string Naim { get; set; }
            public string Kolvo { get; set; }
            public string EdIzm { get; set; }

            public override string ToString()
            {
                return string.Format("Наименование: {0}, Количество: {1}, Единица измерения: {2}", Naim, Kolvo, EdIzm);
            }
        }
    }

