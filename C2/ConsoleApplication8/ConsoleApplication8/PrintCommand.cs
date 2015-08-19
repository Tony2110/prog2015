using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication8
{
    class PrintCommand : BasicCommand
    {
        public string Key
        {
            get { return "PRINT"; }
        }

        BasicInterpreter interpreter;
        public void Setup(BasicInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void Run(BasicStep command)
        {
            var atr = command.AllTheRest;
            foreach (var item in interpreter.Variables)
            {
                atr = atr.Replace("{" + item.Key + "}", item.Value.ToString());
            }
            Console.WriteLine(atr);
        }
    }
}
