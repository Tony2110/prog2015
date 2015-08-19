using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tony

{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Random rand = new Random();
            int temp = rand.Next(100);
            string s;
            int count = 0;
            float del;
            Console.Write("Добро Пожаловать:-)\nДля ответа вводите <<да>> или <<нет>>\n");
            Console.Write("Загадайте число от 1 до 100\n");
            do
            {
                Console.Write("Загадали?\n");
                s = Console.ReadLine();
            } while (s == "нет");
            Console.Write("Ваше число: " + temp + '?' + '\n');
            s = Console.ReadLine();
            if (s == "да")
            {
                Console.Write("\nУра!!! Я выиграл!");
                Console.ReadKey();
                return;
            }
            Console.Write("Ваше число делится на 2?\n");
            s = Console.ReadLine();
            if (s == "да")
            {
                Console.Write("Ваше число делится на 5?\n");
                if (Console.ReadLine() == "да")
                {
                    do
                    {
                        Console.Write("\nВаше число: " + rand.Next(5)*5 + '?' + '\n');
                        s = Console.ReadLine();
                        count++;
                        if (s == "да")
                        {
                            Console.Write("\nУра!!! Я выиграл!");
                            Console.ReadKey();
                            return;
                        }
                    } while (count < 10);

                    Console.Write("\nВаше чило делится на 3?\n");
                    s = Console.ReadLine();
                    if (s == "да")
                    {
                        for (int i = 6; i < 100; i++)
                        {
                            if (i%2 == 0 && i%3 == 0 && i%5 == 0)
                            {
                                Console.Write("\nВаше число: " + i + '?' + '\n');
                                s = Console.ReadLine();
                                if (s == "да")
                                {
                                    Console.Write("\nУра!!! Я выиграл!");
                                    Console.ReadKey();
                                    return;
                                }
                                else Console.Write("\nПопробую ещё раз");
                            }
                        }
                    }
                }
                else
                {
                    Console.Write("\nВаше чило делится на 3?\n");
                    s = Console.ReadLine();
                    if (s == "да")
                    {
                        for (int i = 6; i < 100; i++)
                        {
                            if (i%2 == 0 && i%3 == 0 && i%5 != 0)
                            {
                                Console.Write("\nВаше число: " + i + '?' + '\n');
                                s = Console.ReadLine();
                                if (s == "да")
                                {
                                    Console.Write("\nУра!!! Я выиграл!");
                                    Console.ReadKey();
                                    return;
                                }
                                else Console.Write("\nПопробую ещё раз");
                            }
                        }
                    }
                    if (s == "нет")
                    {
                        for (int i = 2; i < 100; i = i + 1)
                        {
                            if (i%2 == 0 && i%3 != 0 && i%5 != 0)
                            {
                                Console.Write("\nВаше число: " + i + '?' + '\n');
                                s = Console.ReadLine();
                                if (s == "да")
                                {
                                    Console.Write("\nУра!!! Я выиграл!");
                                    Console.ReadKey();
                                    return;
                                }
                                else Console.Write("Попробую ещё раз");
                            }
                        }
                    }

                }
            }
            if (s == "нет")
            {
                Console.Write("\nВаше чило делится на 3?\n");
                s = Console.ReadLine();
                if (s == "да")
                {
                    for (int i = 1; i < 100; i++)
                    {
                        if (i%3 == 0 && i%2 != 0)
                        {

                            Console.Write("\nВаше число: " + i + '\n');
                            s = Console.ReadLine();
                            if (s == "да")
                            {
                                Console.Write("\nУра!!! Я выиграл!");
                                Console.ReadKey();
                                return;
                            }
                            if (s == "нет") Console.Write("Попробуем ещё раз");
                        }
                    }
                }
                if (s == "нет")
                {
                    Console.Write("Ваше чило больше 50?\n");
                    s = Console.ReadLine();
                    if (s == "да")
                    {
                        for (int i = 50; i < 100; i++)
                        {
                            for (int j = i; j >= 1; j--)
                            {
                                del = i%j;
                                if (del == 0)
                                    count++;
                            }
                            if (count == 2)
                            {
                                Console.Write("\nВаше число: " + i + '?' + '\n');
                                s = Console.ReadLine();
                                if (s == "да")
                                {
                                    Console.Write("\nУра!!! Я выиграл!");
                                    Console.ReadKey();
                                    return;
                                }
                                else Console.Write("Попробую ещё раз");
                            }
                            count = 0;
                        }

                    }
                    else
                    {
                        for (int i = 47; i >1; i--)
                        {
                            for (int j = i; j >= 1; j--)
                            {
                                del = i%j;
                                if (del == 0)
                                    count++;
                            }
                            if (count == 2)
                            {
                                Console.Write("\nВаше число: " + i + '?' + '\n');
                                s = Console.ReadLine();
                                if (s == "да")
                                {
                                    Console.Write("\nУра!!! Я выиграл!");
                                    Console.ReadKey();
                                    return;
                                }
                                else Console.Write("Попробую ещё раз");
                            }
                            count = 0;
                        }
                    }
                }
                Console.ReadKey();
            }
        }
    }
}

