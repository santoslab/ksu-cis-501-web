using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static void Main()
    {
        // place unit tests here:
        testClock();
    }

    public static void testClock()
    {
        Clock c = new Clock();
        for (int i = 0; i <= 20; i++)
        {
            Console.WriteLine(c.getTime());
            c.tick();
        }
    }
}
