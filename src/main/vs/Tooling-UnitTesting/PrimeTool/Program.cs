using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTool
{
    // A simple prime tester console app
    // (make sure the Program class visibility is public)
    public class Program
    {
        // (make sure the main method visibility is public)
        public static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                int n = ReadPositiveInt("Enter a number:");
                Console.WriteLine();

                if (IsPrime(n))
                {
                    Console.WriteLine(n + " is a prime!");
                }
                else
                {
                    Console.WriteLine(n + " is not a prime!");
                }


                Console.Write("Do you want to exit (enter y to exit)? ");
                exit = Console.ReadLine() == "y";
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        // reads a positive int from user input
        public static int ReadPositiveInt(string msg)
        {
            int n = -1;
            while (n < 0) // repeat until positive int input
            {
                Console.Write(msg + " ");
                n = Int32.Parse(Console.ReadLine());
            }
            return n;
        }

        // from http://www.dotnetperls.com/prime
        public static bool IsPrime(int candidate)
        {
            // Test whether the parameter is a prime number.
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            // Note:
            // ... This version was changed to test the square.
            // ... Original version tested against the square root.
            // ... Also we exclude 1 at the end.
            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }
            return candidate != 1;
        }
    }
}
