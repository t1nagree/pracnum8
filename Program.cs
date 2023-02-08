using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp27
{

    class Program : body
    {
        static void Main()
        {
            ConsoleKeyInfo start;

            while (true)
            {
                nachalo();
                start = Console.ReadKey();
                if (start.Key == ConsoleKey.Tab)
                    perehod();
                else if (start.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}