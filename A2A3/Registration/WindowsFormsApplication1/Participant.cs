using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WindowsFormsApplication1
{

    public class Participant1
    {
        public Participant1()
        {
            Part = new List<Participant>();
        }

        public string TeamName { get; set; }
        public string Town { get; set; }
        public string FI { get; set; }

        public Gender Gender { get; set; }
        public int Size { get; set; }
        public string Email { get; set; }
        public string TelNumber { get; set; }
        public TeamAge TeamAge { get; set; }
        public List<Participant> Part { get; set; }
        
    }
    
    public class Participant
    {
        public string Name { get; set; }
        public string Age { get; set; }

        public override string ToString()
        {
            return  Name +" ("+Age+")";
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
    public enum TeamAge
    {
        Junior,
        Varsity,
        Adult
    }
}
