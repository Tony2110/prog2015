using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_C1
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 min=0, max=int.MaxValue,av;
            av = ((min + max) / 2);
            while (true)
            {
                Console.WriteLine("Ваше число меньше "+av+"?");
                if (Console.ReadLine()[0] == 'y')
                    max = av;
                else
                    min = av;
                av = ((min + max) / 2);
                if (av == min)
                {
                    break;
                }
            }
            Console.WriteLine("Это число "+min+"?");
            if (Console.ReadLine()[0] == 'y')
            {
                Console.WriteLine("Кошерно");
            }
            else
            {
                Console.WriteLine("Ложь!");
            }
            Console.ReadKey();
        }
    }
}
