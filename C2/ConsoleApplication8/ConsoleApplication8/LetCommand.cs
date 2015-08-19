using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication8
{
    abstract class AbstractCommand:BasicCommand
    {
        protected BasicInterpreter interpreter;
        public void Setup(BasicInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public abstract string Key
        {
            get;
        }

        public abstract void Run(BasicStep command);
    }
    class LetCommand : AbstractCommand
    {
        public override string Key
        {
            get { return "LET"; }
        }

        public override void Run(BasicStep command)
        {
            var parts = command.AllTheRest.Split('=');
            var variableName = parts[0].Trim();
            var valueOfVar = int.Parse(parts[1].Trim());
            interpreter.Variables[variableName] = valueOfVar;
        }
    }
}
