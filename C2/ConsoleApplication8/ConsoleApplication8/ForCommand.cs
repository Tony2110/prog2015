using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication8
{
    class ForCommand:AbstractCommand
    {
        public override string Key
        {
            get { return "FOR"; }
        }

        public override void Run(BasicStep command)
        {
            var atr = command.AllTheRest;
            var ptrs = atr.Split(new []{"FROM"},StringSplitOptions.RemoveEmptyEntries);
            atr = ptrs[1];
            var varName = ptrs[0].Trim();
            ptrs = atr.Split(new[] { "TO" }, StringSplitOptions.RemoveEmptyEntries);
            var start = int.Parse( ptrs[0].Trim());
            var endName = ptrs[1].Trim();
            int end;

            if (!interpreter.Variables.TryGetValue(endName, out end))
            {
                end = int.Parse(endName);
            }
            
            if(interpreter.Loop == null){
                interpreter.Loop = new ForLoop
                {
                    from = start,
                    to = end,
                    stepNumber = command.Number,
                    VarName = varName
                };
                interpreter.Variables[varName] = start;
            }
            else
            {
                var varVal = interpreter.Variables[varName];
                varVal++;
                interpreter.Variables[varName] = varVal;
                if (varVal > end)
                    interpreter.FinishLoop();
            }
        }
    }
}
