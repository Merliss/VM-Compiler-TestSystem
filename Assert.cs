using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileAndRunTests.Exceptions.CompileAndRunTests;

namespace CompileAndRunTests
{
    public class Assertion
    {
        public static void Assert(object actual, object expected, object thisMethod)
        {
            if (!actual.Equals(expected))
            {
                
                throw new AssertionException(actual, expected);
            }
            else
            {
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Success - Test passed in {thisMethod}: Actual = {actual} is equal Expected = {expected}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void AssertNotEqual(object actual, object unwanted)
        {
            if (actual.Equals(unwanted))
            {
                
                throw new AssertionNotEqualException(actual, unwanted);
            }
            else
            {
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Success - Test passed: Actual = {actual} is differ from Unwanted = {unwanted}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
