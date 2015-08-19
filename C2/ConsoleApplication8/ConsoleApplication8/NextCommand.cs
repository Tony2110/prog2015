using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication8
{
    class NextCommand:AbstractCommand
    {
        public override string Key
        {
            get { return "NEXT"; }
        }

        public override void Run(BasicStep command)
        {
            interpreter.Next();
        }
    }
}
