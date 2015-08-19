using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS
{
    public class Item
    {
        public string Name { get; set; }
        public List<Item> Next { get; set; }
        public string Description { get; set; }
        public ItemRule Rule { get; set; }
        public override string ToString()
        {
            return string.Format("{0}.{1}",Name, Rule.ToString());
        }

    }
}

public enum ItemRule
{
    Text,
    Dir
}