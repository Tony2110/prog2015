using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 top = int.MaxValue, bottom = 0, x = top/2, k = 0;
            Console.WriteLine("Программа угадает загаданное вами число от 0 до "+top+", задав Вам несколько вопросов\nЗагадайте, пожалуйста, число и нажмите любую клавишу");
            Console.ReadKey();
            while (k != 1)
            {
                Console.WriteLine("Ваше число меньше "+x+"? Ответьте y, если да или n, если нет");
                if (Console.ReadLine() == "y")
                {
                    top = x; x /= 2;
                }
                else
                {
                    bottom = x;
                    x = (top+bottom)/2;
                    if (x == bottom)
                    {
                        k = 1;
                    }
                }
                
             } 
            
            Console.WriteLine("Ваше число - "+x);
            Console.ReadKey();
        }
    }
}
