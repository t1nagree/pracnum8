using ConsoleApp27;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp27
{
    internal class body
    { 
        static public string path = "C:\\Users\\User\\Desktop\\1.json";
        private static int sec;
        private static int id = 1;
        private static string Name;
        private static List<records> result_tables = new List<records>();
        public static void nachalo()
        {

            Console.Clear();
            Console.WriteLine("Результаты: ");
            List<records> result = JsonConvert.DeserializeObject<List<records>>(File.ReadAllText(path));
            foreach (var el in result)
            {
                Console.WriteLine(el.Name);
                Console.WriteLine(el.SymbolsAtMin + " символов в минуту");
                Console.WriteLine(el.SymbolsAtSecond + " символов в секунду");
                Console.WriteLine("-----------------");
                Console.WriteLine($"\nЧтобы добавить новый результат нажмите  кнопку Tab. \nДля выхода из программы нажмите ESC. ");
            }
            static void ser()
            {
                File.WriteAllText("C:\\Users\\User\\Desktop\\1.json", JsonConvert.SerializeObject(result_tables));
            }
        }

        private static void potok()
        {
            sec = -1;
            int i = 60;

            while (i != 0)
            {
                if (id != 0)
                {
                    Console.SetCursorPosition(5, 10);
                    if (i == 60)
                    {
                        Console.WriteLine("1:00");
                    }
                    if (i < 60)
                    {
                        Console.WriteLine($"0:{i}");
                    }
                    i = i - 1;
                    sec++;
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(5, 10);
                    Console.WriteLine(" ");
                }
            }
            id = 0;
            Console.SetCursorPosition(5, 10);
            Console.WriteLine("0:0");
            Thread.Sleep(400);
            Console.SetCursorPosition(5, 10);
            Console.WriteLine("Чтобы продолжить - нажмите любую клавишу...");
        }

        private static void pechatanie()
        {

            string txt = "В баскетбол играют две команды, каждая из которых состоит из пяти полевых игроков. Цель каждой команды забросить мяч в кольцо с сеткой соперника и помешать другой команде завладеть мячом и забросить его в свою корзину. Корзина находится на высоте 3,05 м от паркета.";
            char[] text = txt.ToCharArray();
            int i = 0;
            int position = 0;
            int sop = 0;
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine(txt);
                Console.WriteLine("\nЧтобы начать нажмите Enter\nДля выхода в любой момент нажмите ESC");
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Enter);
            Console.Clear();
            Console.WriteLine(txt);
            Thread po = new Thread(potok);
            po.Start();
            do
            {
                Console.SetCursorPosition(sop, position);
                key = Console.ReadKey(true);
                if (key.KeyChar == text[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(sop, position);
                    Console.WriteLine(text[i]);
                    i++;
                    sop++;
                    if (sop == 120)
                    {
                        sop = 0;
                        position++;
                    }
                    Console.ResetColor();
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Работа программы завершена! (Вы принудительно завершили работу по нажатию клавиши ESC");
                    Environment.Exit(0);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(sop, position);
                    Console.WriteLine(text[i]);
                    Console.ResetColor();
                }
            } while (id != 0 && i != text.Length);
            id = 0;
            records h = new records();
            h.Name = Name;
            h.SymbolsAtMin = i * 60 / sec;
            h.SymbolsAtSecond = (float)i / sec;
            result_tables.Add(h);
        }

        static public void perehod()
        {
            Console.Clear();
            Console.WriteLine("Введите имя\n");
            Name = Console.ReadLine();
            Console.Clear();
            pechatanie();
            id = 1;
        }
    }
}
