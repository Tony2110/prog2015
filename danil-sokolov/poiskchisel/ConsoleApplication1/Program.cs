using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private static int z;
        private static int n;
        private static string otv;

        static void Main(string[] args)
        {
            z=0;
            n=100;
            Console.WriteLine("Загадайте число от 0 до 1000");
            Console.WriteLine("Отвечай да-y и нет-n ");
            cht1:
            Console.WriteLine("Ваша число между {0} {1}?", z, n);
            otv = Console.ReadLine();
            if(otv=="n")
            {
                z = z + 100;
                n = n + 100;
                goto cht1;
            }

            if(otv=="y")
            {
            cht2:
                Console.WriteLine("число наодится между {0} и {1}?", z, n-50);
                otv = Console.ReadLine();
                if (otv == "y")
                {
                    n = n-50;
                    goto cht2;
                }           
                
            }

            z = z + 50;
            n = n - 40;
            cht3:
            Console.WriteLine("число наодится между {0} и {1}?", z, n);
            otv = Console.ReadLine();
            if (otv == "n")
            {
                z=z+10;
                n = n + 10;
                goto cht3;
            }

            Console.WriteLine("Число четное?");
            otv = Console.ReadLine();
            if (otv == "n")
            {
                Console.WriteLine("Число нечетное?");
                otv = Console.ReadLine();
                if(otv=="n")
                {
                    Console.WriteLine("Ваше число = 0");
                }
                else
                {
                    Console.WriteLine("Число <={0}?",n-5);
                    otv = Console.ReadLine();
                    if(otv=="y")
                    {
                        Console.WriteLine("{0}<Число<{1}?",z+1, n - 5);
                        otv = Console.ReadLine();
                        if(otv=="y")
                        {
                            Console.WriteLine("Ваше число={0}",n-7);
                        }
                        else
                        {
                            Console.WriteLine("Ваше число>{0}?",z+1);
                            otv = Console.ReadLine();
                            if(otv=="y")
                            {
                                Console.WriteLine("Ваше число={0}",n-5);
                            }
                            else
                            {
                                Console.WriteLine("Ваше число={0}",z+1);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0}<Число<{1}?",z+5, n-1);
                        otv = Console.ReadLine();
                        if(otv=="y")
                        {
                            Console.WriteLine("Ваше число={0}",z+7);
                        }
                        else
                        {
                            Console.WriteLine("Ваше число>{0}?",z+5);
                            otv = Console.ReadLine();
                            if(otv=="y")
                            {
                                Console.WriteLine("Ваше число={0}",n-1);
                            }
                            else
                            {
                                Console.WriteLine("Ваше число={0}",z+5);
                            }
                        }
                    }
                }
            }
            else
            {
                    Console.WriteLine("Число <={0}?", n - 4);
                    otv = Console.ReadLine();
                    if (otv == "y")
                    {
                        Console.WriteLine("{0}<Число<{1}?", z, n - 4);
                        otv = Console.ReadLine();
                        if (otv == "y")
                        {
                            Console.WriteLine("Число<{0}?",n - 6);
                            otv = Console.ReadLine();
                            if(otv=="y")
                            {
                                Console.WriteLine("Число={0}",n - 8);
                            }
                            else
                            {
                                Console.WriteLine("Число={0}",n - 6);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ваше число>{0}?",z);
                            otv = Console.ReadLine();
                            if (otv == "y")
                            {
                                Console.WriteLine("Ваше число={0}", n-4);
                            }
                            else
                            {
                                Console.WriteLine("Ваше число={0}", z);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0}<Число<{1}?", z+6, n);
                        otv = Console.ReadLine();
                        if (otv == "y")
                        {
                           Console.WriteLine("Число={0}",z+8);
                        }
                        else
                        {
                            Console.WriteLine("Ваше число>{0}?",z+6);
                            otv = Console.ReadLine();
                            if (otv == "y")
                            {
                                Console.WriteLine("Ваше число={0}", n);
                            }
                            else
                            {
                                Console.WriteLine("Ваше число={0}", z+6);
                            }
                        }
                    }
                }
            Console.ReadKey();
            }
    }
    }
          
