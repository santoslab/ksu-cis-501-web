using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClockUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Clock c = new Clock();
            for (int i = 0; i <= 20; i++)
            {
                Console.WriteLine(c.getTime());
                c.tick();
            }
        }
    }
}
