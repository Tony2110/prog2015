using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 min = 0, max = int.MaxValue, x = max / 10, f = 0;
            Console.WriteLine("Загадайте число от 0 до " + max + ".\n\n\nДля ответов на вопросы используйте команды ''y'' -да ''n'' -нет.\n");

            while (true)
            {
                Console.WriteLine("\nВаше число меньше " + x + "?\n");
                if (Console.ReadLine()[0] == 'y')
                {
                    max = x;

                    x = x / 10;
                }
                else
                {
                    min = x;
                    f = 1;
                }
                if (f == 1)
                    x = (max + min) / 2;
                if (x == min)
                {
                    break;
                }
            }

            Console.WriteLine("\nВы загадали " + x + "?\n");
            if (Console.ReadLine()[0] == 'y')
            {
                Console.WriteLine("\nMission completed!!!");
            }
            else
            {
                Console.WriteLine("\nНевозможно.");
            }

            Console.ReadKey();
        }
    }
}