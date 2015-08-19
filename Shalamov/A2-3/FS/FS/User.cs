using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS
{
    public class User
    {
        public string Login { get; set; }
        public string Pass { get; set; }
        public Rule UserRule { get; set; }
        public override string ToString()
        {
            return string.Format("{0}({1})",Login, UserRule.ToString());
        }
    }
}

public enum Rule
{
    Admin,
    User,
    Banned,
    Moder,
    New
} 