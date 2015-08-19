using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS
{
    class Cryp
    {
        private List<char> Buffer { get; set; }
        public string En(string InPut)
        {
            Buffer = new List<char>();
            var tmp = InPut.ToCharArray();
            foreach (var item in tmp)
            {
                Buffer.Add((char)((int)(float.Parse(item) * 2));
                Buffer.Add(' ');
            }
            return Buffer.ToString();
        }
        public string De(List<string> InPut)
        {
            Buffer = new List<string>();
            foreach (var item in InPut)
            {
                if (item != " ")
                {
                    char X = (char)((int)(float.Parse(item) * 2));
                    Buffer.Add(X);
                }
            }
        }
    }
}
