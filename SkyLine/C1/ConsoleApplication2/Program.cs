using System;

namespace ConsoleApplication2
{
    class Program
    {
        static int max = 1000000;
        private static int maxlimit=max;
        static int minlimit=0;
        static int find = max / 2;
        static bool success = false;
        static void Main(string[] args)
        {
            bool need = false;
            Console.WriteLine("Загадайте число от 0 до {0}",max);
            while (!need)
            {
                Console.WriteLine("Загадали?");
                if (Console.ReadLine().ToLower() == "да")
                    need = true;
            }
            while (!success)
            {
                Vopros();
                Computer();
            }
        }
        private static void Computer()
        {
            find = (int)((maxlimit + minlimit)/2);
        }

        private static void Vopros()
        {
            Console.WriteLine("Ваше число " + find.ToString() + "?");
            if (Console.ReadLine().ToLower() == "да")
            {
                success = true;               
            }     
            else
            {
                Console.WriteLine("Ваше число больше чем "+find.ToString()+"?");
                if (Console.ReadLine().ToLower() == "да")
                {
                    minlimit = find;                   
                }
                else maxlimit=find;

            }
        }
    }
}
