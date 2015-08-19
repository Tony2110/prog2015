using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            string program = @"
10 LET X = 1
20 LET Y = 1000
30 FOR I FROM 1 TO Y
35 PRINT {I}
40 MUL X I
50 NEXT
60 PRINT Factorial is {X} 
60 PRINT Y is {Y} 
";

            var basic = new BasicInterpreter(program);
            basic.Compile();
            basic.Run();
            Console.ReadKey();
        }
    }

    class BasicInterpreter{
        string[] program;
        List<BasicStep> steps = new List<BasicStep>();
        public int CurrentStepNumber { get; set; }
        public Dictionary<string, int> Variables { get; private set; }
        public Dictionary<string, BasicCommand> Commands { get; set; }
        public ForLoop Loop;

        public BasicInterpreter(string program) 
        {
            this.program =
                program.Split
                (new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                ;
            Variables = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            FillCommands();
        }
        void FillCommands()
        {
            Commands = new Dictionary<string, BasicCommand>();
            BasicCommand cmd = new PrintCommand();
            Commands.Add(cmd.Key, cmd);
            cmd = new LetCommand();
            Commands.Add(cmd.Key, cmd);
            cmd = new ForCommand();
            Commands.Add(cmd.Key, cmd);
            cmd = new NextCommand();
            Commands.Add(cmd.Key, cmd);
            cmd = new MulCommand();
            Commands.Add(cmd.Key, cmd);
            foreach (var item in Commands)
            {
                item.Value.Setup(this);
            }
        }

        public void Compile()
        {
            foreach (var item in program)
            {
                var bs = new BasicStep(item);                
                steps.Add(bs);
            }
        }

        public void Run()
        {
            CurrentStepNumber = -1;
            while (CurrentStepNumber < steps.Count)
            {
                CurrentStepNumber++;
                RunCommand(CurrentStepNumber);
            }
        }

        private void RunCommand(int stepIdx)
        {
            if (stepIdx >= steps.Count)
                return;
            var step = steps[stepIdx];
            BasicCommand cmd;
            if(Commands.TryGetValue(step.CommandKey, out cmd))
            {
                cmd.Run(step);
            }
        }

        internal void FinishLoop()
        {
            Next();
            for (; CurrentStepNumber < steps.Count; CurrentStepNumber++)
            {
                if (steps[CurrentStepNumber].CommandKey == "NEXT")
                    break;
            }
        }

        internal void Next()
        {
            for (int i = 0; i < steps.Count; i++)
			{
                var item = steps[i];
                if (item.Number == Loop.stepNumber)
                {
                    CurrentStepNumber = i-1;
                    break;
                }
            }
        }
    }

    class BasicStep
    {
        public BasicStep(string line)
        {
            var lineParts = line.Split(' ');
            Number = int.Parse(lineParts[0]);
            CommandKey = lineParts[1].ToUpper();
            AllTheRest = string.Join(" ", lineParts.Skip(2));
        }
        public int Number { get; set; }
        public string CommandKey { get; set; }
        public string AllTheRest { get; set; }
    }

    interface BasicCommand
    {
        string Key { get; }
        void Setup(BasicInterpreter interpreter);
        void Run(BasicStep command);
    }
}
