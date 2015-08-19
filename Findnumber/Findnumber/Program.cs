using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 secret = 0, max = 10000, ans;
            Console.WriteLine("Загадайте число от 0 до " + max);
            Console.WriteLine("Для ответов вводите Да/Нет");
            while (true)
            {
                ans = (secret + max) / 2;
                if (max - secret >= 2)
                {
                    Console.WriteLine("Ваше число >= " + ans + "?");
                    if (Console.ReadLine().ToLower() == "да") { secret = ans; }
                    else { max = ans; }
                }
                else
                {
                    Console.WriteLine("Ваше число - " + secret + "?");
                    if (Console.ReadLine().ToLower() == "да") { Console.WriteLine("Тадам!!!"); break; }
                    else { Console.WriteLine("Увы:("); break; }
                }
            }
            Console.WriteLine("Нажмите клавишу для завершения..."); Console.ReadLine();
        }
    }
}