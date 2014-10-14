using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RaceCondition
{
    class Token
    {
        public int x = 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Token t = new Token();
            new Thread(() => Run(t, 1)).Start();
            new Thread(() => Run(t, 2)).Start();
            Console.WriteLine("t.x = " + t.x);
            Console.ReadLine();
        }

        static void Run(Token t, int id)
        {
            int temp = t.x + 1;
            t.x = temp;
        }
    }
}
