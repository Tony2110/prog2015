using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace c4
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();//Таймер для измерения времени создания файла
            
            long totalRAMbytes = 4*1024*1024*1024L;//4Gb
            //(long)new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;//получаем общий объем памяти

            long fileSize = 0;//размер созданного файла
            int testCount = 0;//счётчик для того чтобы тестировать размер не часто
            long actualFileLength = 0;//последний протестированный реальный размер файла
            using(var file = File.Create("BigPhoneBook.txt",1024*1024*128))//создание файала
            {
                using (var sw = new StreamWriter(file))
                {
                    while (actualFileLength < totalRAMbytes)//запись случайного имени и фамилии до первышения целевого размера файла
                    {
                        sw.WriteLine(GetRandomName() + " " + GetRandomPhoneNumber());

                        if (testCount % 1024 == 0)
                        {
                            actualFileLength = file.Length;
                            if (fileSize / (64 * 1024 * 1024) != actualFileLength / (64 * 1024 * 1024))
                                Console.WriteLine("Записано {0}МБ", actualFileLength / (1024 * 1024));

                            fileSize = actualFileLength;
                        }
                        testCount++;
                    }
                }
            }

            stopwatch.Stop();
            Console.WriteLine("Файл размером {0}Кб создан за {1}",fileSize/1024,stopwatch.Elapsed);

            Console.ReadKey();
        }

        private static string GetRandomPhoneNumber()
        {
            var sb = new StringBuilder();

            sb.Append("+7(9");
            sb.Append(rnd.Next(6).ToString());
            sb.Append(rnd.Next(10).ToString());
            sb.Append(")");
            sb.Append(rnd.Next(10).ToString());
            sb.Append(rnd.Next(10).ToString());
            sb.Append(rnd.Next(10).ToString());
            sb.Append("-");
            sb.Append(rnd.Next(10).ToString());
            sb.Append(rnd.Next(10).ToString());
            sb.Append("-");
            sb.Append(rnd.Next(10).ToString());
            sb.Append(rnd.Next(10).ToString());

            return sb.ToString();
        }

        static Random rnd = new Random(1);

        /// <summary>
        /// Словарь имён
        /// </summary>
        /// TODO: Кто-нибудь, добавьте генерацию женских имён
        static string[] names = new[]{
                "Андрей",
                "Иван",
                "Пётр",
                "Серегей",
                "Василий",
                "Фёдор",
                "Евгений",
                "Никита",
                "Денис",
                "Константин",
                "Владимир",
                "Олег",
                "Дмитрий"
            };

        /// <summary>
        /// Словарь отчеств
        /// </summary>
        static string[] patronimics = new[]{
                "Андреевич",
                "Иванович",
                "Пётрович",
                "Серегеевич",
                "Васильевич",
                "Фёдорович",
                "Константинович",
                "Денисович",
                "Никитович",
                "Владимирович",
                "Олегович",
                "Дмитриевич"
            };

        /// <summary>
        /// Словарь согласных букв
        /// </summary>
        static string[] consonants = new[]{
            "в","г","д","ж","з","к","л","м","н","п","р","с","т","ф","х","ц","ч","ш","щ","б"
        };

        /// <summary>
        /// Словарь гласных букв
        /// Частоты подогнаны для правдоподобия фамилий
        /// </summary>
        static string[] vowels = new[]{
            "о","а","у","и","е",
            "о","а","у","и","е",
            "о","а","у","и","е",

            "ы","э","я","ю","ё",
        };

       /// <summary>
       /// окончания фамилий
       /// </summary>
        static string[] endings = new[]{
            "ов","ин","ев","ин"
        };

        /// <summary>
        /// Функция создания сулчайного Имени Отчества и Фамилии
        /// </summary>
        /// <returns></returns>
        private static string GetRandomName()
        {
            var sb = new StringBuilder();


            sb.Append(GetRandomSymbol(names));//добавление имени в строку
            sb.Append(" ");

            sb.Append(GetRandomSymbol(patronimics));//добавление отчества в строку
            sb.Append(" ");

            int bigramCount = rnd.Next(3) + 1;//выбор количества слогов в фамилии (от 1 до 3)

            for (int i = 0; i < bigramCount; i++)
            {
                if (i == 0)
                    sb.Append(GetRandomSymbol(consonants).ToUpper());//Заглавная буква фамилии - большая
                else
                    sb.Append(GetRandomSymbol(consonants));

                sb.Append(GetRandomSymbol(vowels));//добавление гласной буквы слога
            }


            sb.Append(GetRandomSymbol(consonants));//завершающая согласная и окончание
            sb.Append(GetRandomSymbol(endings));


            return sb.ToString();
        }

        /// <summary>
        /// Функция выбора из массива случайного элемента
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static string GetRandomSymbol(string[] array)
        {
            return array[rnd.Next(array.Length)];
        }

        
    }
}
