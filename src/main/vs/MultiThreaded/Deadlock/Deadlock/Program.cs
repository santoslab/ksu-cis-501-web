using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Deadlock
{
    class Fork
    {
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fork fork1 = new Fork();
            Fork fork2 = new Fork();
            new Thread(() => Run("Red", fork1, fork2)).Start();
            new Thread(() => Run("Blue", fork2, fork1)).Start();
            Console.ReadLine();
        }

        static void Run(String id, Fork left, Fork right)
        {
            Thread.Sleep(new Random().Next(0, 11));
            Console.WriteLine(id + " takes left fork");
            lock (left)
            {
                Thread.Sleep(new Random().Next(0, 11));
                Console.WriteLine(id + " takes right fork");
                lock (right)
                {
                    Thread.Sleep(new Random().Next(0, 11));
                    Console.WriteLine(id + " thinks/eats");
                }
                Console.WriteLine(id + " puts down right fork");
                Thread.Sleep(new Random().Next(0, 11));
            }
            Console.WriteLine(id + " puts down left fork");
        }
    }
}
