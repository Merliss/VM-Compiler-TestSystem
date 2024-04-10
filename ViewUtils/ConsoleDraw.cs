using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileAndRunTests.ViewUtils
{
    public class ConsoleDraw
    {

        public static void DrawFrameAroundText(string text, ConsoleColor color)
        {
            var p = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine($"╔{new string('═',text.Length+2)}╗");
            Console.Write("║ ");
            Console.ForegroundColor = p;
            Console.Write($"{text}");
            Console.ForegroundColor = color;
            Console.WriteLine(" ║");
            Console.WriteLine($"╚{new string('═', text.Length+2)}╝");
            Console.ForegroundColor = p;
            
        }

        public static void ResultOfTest(int AllTests, int TestsFailed)
        {
            if (TestsFailed > 0)
            {
                Console.WriteLine();
                var p = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Tests Passed:");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{AllTests - TestsFailed}/{AllTests}");
                Console.ForegroundColor = p;
            }
            else
            {
                var p = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Tests Passed:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{AllTests - TestsFailed}/{AllTests}");
                Console.ForegroundColor = p;
            }
        }
        
    }
}
