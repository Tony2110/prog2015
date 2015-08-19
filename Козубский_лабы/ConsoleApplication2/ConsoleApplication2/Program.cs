using System;

namespace ConsoleApplication2
{
    class Program
    {
        static int max = 1000000;
        private static int maxlimit=max;
        static int minlimit=0;
        static int dogadka = max / 2;
        static bool otgadal = false;
        static void Main(string[] args)
        {
            bool zagadali = false;
            Console.WriteLine("Загадайте число от 0 до {0}",max);
            while (!zagadali)
            {
                Console.WriteLine("Загадали?");
                if (Console.ReadLine().ToLower() == "да")
                    zagadali = true;
            }
            while (!otgadal)
            {
                Vopros();
                Computer();
            }
        }
        private static void Computer()
        {
            dogadka = (int)((maxlimit + minlimit)/2);
        }

        private static void Vopros()
        {
            Console.WriteLine("Ваше число" + dogadka.ToString() + "?");
            if (Console.ReadLine().ToLower() == "да")
            {
                otgadal = true;               
            }     
            else
            {
                Console.WriteLine("Ваше число больше чем"+dogadka.ToString()+"?");
                if (Console.ReadLine().ToLower() == "да")
                {
                    minlimit = dogadka;                   
                }
                else maxlimit=dogadka;

            }
        }
    }
}
