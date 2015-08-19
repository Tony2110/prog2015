using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication8
{
    class MulCommand:AbstractCommand
    {
        public override string Key
        {
            get { return "MUL"; }
        }

        public override void Run(BasicStep command)
        {
            var parts = command.AllTheRest.Split(' ');
            var x = parts[0];
            var y = parts[1];

            var xv = interpreter.Variables[x];
            xv *= interpreter.Variables[y];
            interpreter.Variables[x] = xv;
        }
    }
}
