using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CompileAndRunTests.TestRunner1;
using CompileAndRunTests.Tests;
using CPSimulation;
using CompileAndRunTests.Compilation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using CPDev.STComp05;
using System.Runtime.Serialization.Json;
using CompileAndRunTests.TestUtils;
using Newtonsoft.Json.Linq;
using System.Collections;
using CompileAndRunTests.ViewUtils;

namespace CompileAndRunTests
{

    internal class Program
    {

        public static void Main(string[] args)
        {

            int i = 0;

            Console.WriteLine("Testy kompilatora i VM");
            Console.WriteLine("--------------------------------");

            ConsoleDraw.DrawFrameAroundText("Compilator Tests",ConsoleColor.Green);
            CompilationTests ct = new CompilationTests();
            ct.Test();
            ConsoleDraw.DrawFrameAroundText("VM Tests",ConsoleColor.Green);
            VMTests vt = new VMTests();
            vt.Test();

            Console.WriteLine();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            
            



        }
    }
}


  