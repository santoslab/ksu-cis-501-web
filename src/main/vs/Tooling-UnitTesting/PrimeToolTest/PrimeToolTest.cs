using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimeToolTest
{
    [TestClass]
    public class PrimeToolTest
    {
        // test IsPrime(2) directly
        [TestMethod]
        public void Num2Prime()
        {
            Assert.IsTrue(PrimeTool.Program.IsPrime(2));
        }

        // test prime tool console app on 2 using a script without expected output
        [TestMethod]
        public void ConsoleNum2Prime()
        {
            // @"" is a multi-line string
            // the first line is "2" which will be entered for the number to test
            // the second line is "y" which will be entered for exiting the app 
            test(@"2
y
", null);
        }

        // test prime tool console app on 3 using a script with expected output
        // that it is a prime
        // (be careful with white-space for the expected output)
        [TestMethod]
        public void ConsoleNum3Prime()
        {
            test(@"3
y",
                 @"Enter a number: 
3 is a prime!
Do you want to exit (enter y to exit)? 
");
        }

        // test prime tool console app on 4 and 55 using a script with expected output
        // that it is not a prime
        [TestMethod]
        public void ConsoleNum4And55NotPrime()
        {
            test(@"4
n
55
y
",
                 @"Enter a number: 
4 is not a prime!
Do you want to exit (enter y to exit)? 
Enter a number: 
55 is not a prime!
Do you want to exit (enter y to exit)? 
");
        }

        // test utility method to run the prime tool app with 
        // a string script as input
        void test(string script, string expectedOutput)
        {
            // save default Console.Out and Console.In
            TextWriter cout = Console.Out;
            TextReader cin = Console.In;
            
            // redirect Console.Out to a StringWriter (buffer)
            StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // set script as the app Console.In
            StringReader sr = new StringReader(script);
            Console.SetIn(sr);

            // call the console app
            PrimeTool.Program.Main(new string[0]);

            // restore default Console.Out and Console.In
            Console.SetOut(cout);
            Console.SetIn(cin);

            // close resources
            sw.Close();
            sr.Close();

            // get the actual ouput
            // if the expected output is null, 
            //    then the test simply prints out the actual output (for debugging) 
            // otherwise, it asserts that the expected output is equal to the actual ouput
            string actualOutput = sw.ToString();
            if (expectedOutput == null)
            {
                Console.Write(actualOutput);
            }
            else
            {
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
    }
}
