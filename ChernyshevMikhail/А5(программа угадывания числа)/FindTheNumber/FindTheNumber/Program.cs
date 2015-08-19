using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindTheNumber
{
    internal class Program
    {
        private static int z;
        private static int n;
        private static int k;
        private static string ans;
        private static Boolean flag;

    static void Main(string[] args)
        {
            k = 1000;
            n = 0;
            flag = false;
            Console.WriteLine("Задумайте число от 0 до 1000");
            Console.WriteLine("Ответы: да-y, нет-n");
            Console.WriteLine();
            //---------------------------------------------------------------------
            start:
            z = (k + n) / 2;
            Console.WriteLine("Ваше число равно {0}?", z);
            ans = Console.ReadLine();
            if (ans == "y")
              {
                  flag = true;
                  goto finish;
              }
            Console.WriteLine("Может быть оно больше {0}?", z);
            ans = Console.ReadLine();
            if (ans == "y")
            {
                n = z;
                if (k - n == 2)
                {
                    Console.WriteLine("Ваше число = {0}",k-1);
                    flag = true;
                }
            }
            if (ans=="n")
            {
                k = z;
                if (k - n == 2)
                {
                    Console.WriteLine("Ваше число = {0}", k-1);
                    flag = true;
                }
            }
            if (flag == false) goto start;
            finish:
            Console.WriteLine("Число угадано, нажмите Enter для окончания...");
            Console.ReadKey();
        }
    }
}
