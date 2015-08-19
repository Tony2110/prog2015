using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GuessGame_v0._1
{
    class Program
    {
        private static void Main(string[] args)
        {
            string answer;
            var x = 1;
            var range = new int[100]; //для изменения диапазона достаточно изменить размер массива
            int i;

            for (i = 0; i <= range.Length - 1; i++)
            {
                range[i] = x;
                x++;
            }

            var left = range[0] - 1;
            var right = range.Length;
            var mid = left + (right - left) / 2;

            Console.WriteLine("Загадайте число в диапазоне от 0 до " + range.Length);
            Console.WriteLine("Отвечайте на вопросы 'да' или 'нет'");

            while (true)
            {
                mid = left + (right - left)/2;
                Console.WriteLine("Вы загадали число " + mid + " ?");
                answer = Console.ReadLine();
                if (answer == "да")
                {
                    Console.WriteLine("Я победил");
                    break;
                }
                Console.WriteLine("Ваше число меньше " + mid + " ?");
                answer = Console.ReadLine();

                if (answer == "да")
                    right = mid;
                else
                {
                    left = mid + 1;
                }
            }
            Console.ReadKey();
        }
    }
}


