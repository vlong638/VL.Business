using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int value = 1;
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Console.WriteLine(value);
                    value++;
                    Thread.Sleep(100);
                }
            });
            Console.ReadLine();
        }
    }
}
