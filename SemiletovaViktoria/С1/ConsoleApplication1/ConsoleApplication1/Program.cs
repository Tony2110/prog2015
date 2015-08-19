﻿using System;
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
            Int64 min = 0, max = int.MaxValue, x=max/10, f=0;
            Console.WriteLine("Загадайте число от 0 до "+max+"\nДля ответов на вопросы используйте команды y-да n-нет");
            
            while (true)
            {
                Console.WriteLine("Ваше число меньше " + x + "?");
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
                if (x==min)
                {
                    break;
                }
            }

            Console.WriteLine("Вы загадали " + x + "?");
            if (Console.ReadLine()[0] == 'y')
            {
                Console.WriteLine("Ура!");
            }
            else
            {
                Console.WriteLine("Не возможно");
            }
            
            Console.ReadKey();
        }
    }
}
