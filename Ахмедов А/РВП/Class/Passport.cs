using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace РВП.Class
{
    [Serializable]
    public class Passport
    {
        public string Name;
        public string Surname;
        public string LastName;
        public DateTime BirthDate;
        public bool Sex;
        public string Citizenship;
        public string Serie;
        public Byte[] Photo;
        public List<Trud> Truds;

        public Passport ()
        {
            Truds = new List<Trud>();
        }
        public static void SaveData(Passport passport,string path)
        {
            FileStream stream = File.Create(path+".personal");
            var myBinaryFormatter = new BinaryFormatter();
            myBinaryFormatter.Serialize(stream, passport);
            stream.Close();

        }
        public static Passport LoadData(string path)
        {
            FileStream stream = File.OpenRead(path);
            var myBinaryFormatter = new BinaryFormatter();
            Passport passport=(Passport) myBinaryFormatter.Deserialize(stream);
            stream.Close();
            return passport;

        }

    }
    [Serializable]
    public class Trud
    {
        public DateTime Start;
        public DateTime End;
        public string Dolj;
        public string Adress;

        public override string ToString()
        
        {
            return string.Format("С: {0}, По: {1}, Должность: {2}, Адрес: {3}", Start, End, Dolj, Adress);
        }

        
    }
}
