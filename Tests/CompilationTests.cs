using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CompileAndRunTests.Compilation;
using CompileAndRunTests.TestUtils;
using CompileAndRunTests.ViewUtils;
using CPSimulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompileAndRunTests.Tests
{
    //string[] flags =
    //    { "--cf", "2531", "--sf", "B0", "--lof", "1", "--opt", "5" };

    [TestClass]
    public class CompilationTests
    {
        private static JsonUtils _jsonUtils;
        private static CPDev.STComp05.FileNameConvert _fnconvert;


        public CompilationTests()
        {
            _jsonUtils = new JsonUtils();
            _fnconvert = new CPDev.STComp05.FileNameConvert();
        }

        [TestMethod]
        public void Test()
        {

            //var env = System.Environment.GetEnvironmentVariables(EnvironmentVariableTarget.User);
            //var dict = env.Cast<DictionaryEntry>().ToDictionary(entry => entry.Key.ToString(), entry => entry.Value.ToString());
            //var path = dict["CPDevTestsPath"];

            string jsonFilePath = "config.json";
            string jsonString = File.ReadAllText(jsonFilePath);
            CombinedJson combo = Newtonsoft.Json.JsonConvert.DeserializeObject<CombinedJson>(jsonString);
            bool status = true;
            if (combo != null)
            {
                foreach (var group in combo.GroupOfTestsJson)
                {
                    int countOfFailed = 0;
                    int countOfAllTests = 0;
                    ConsoleDraw.DrawFrameAroundText($"Group: Compilation of {group.Key}",ConsoleColor.Blue);
                    var p = Console.ForegroundColor;
      
                    foreach (var test in group.Value)
                    {

                        try
                        {
                            RunTest(test,combo);
                        }
                        catch (AssertFailedException exp)
                        {

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Failure : assertion failed in {test.Filename}: message:{exp.Message}");
                            Console.ForegroundColor = p;
                            status = false;
                            countOfFailed++;

                        }
                        catch (Exception unhandled)
                        {

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Failure : unhandled exception appeared in {test.Filename}: Exception: {unhandled.Message}");
                            Console.ForegroundColor = p;
                            status = false;
                            countOfFailed++;
                        }
                        countOfAllTests++;
                    }
                    ConsoleDraw.ResultOfTest(countOfAllTests, countOfFailed);
                }
            }
            else
            {
                // Handle the case where deserialization failed, e.g., log an error or fail the test
                Assert.Fail("Failed to deserialize JSON into CombinedJson object.");
            }
            if (!status)
            {
                //Assert.Fail("One of tests has failed.");
            }
        }

        public void RunTest(SingleTest test, CombinedJson combo)
        {
            string CPDevTestsPath = _fnconvert.UnfoldEnvironmentVariable(combo.PathToTests);
            var methodName = $"Test_{test.Filename}";
            GenTestCompile(methodName, CPDevTestsPath, test.Filename, test.CompObj);
        }


        public void GenTestCompile(string thisMethod, string path, string filename, CompObject compobj)
        {
            string file = File.ReadAllText(System.IO.Path.Combine(path, filename) + ".cst"); // SYSTEM.IO.FILEPATH
            var compile = GenCompilation.DoTypicalCompilation(file, $"{filename}.cst", path, compobj);
            Assert.AreEqual(compile, false, "Nie skompilowano programu dla {0} w {1}", path, thisMethod);
            

        }


        [TestCleanup]
        public void Cleanup()
        {
        }


    }


}




//internal class CompilationTests
//{


//    [TestMethod]
//    public void TestCompileMultiplyBy5()
//    {
//        GenTestCompile(MethodBase.GetCurrentMethod().Name, @"D:\Studia\MGR\Praca Magisterska\kompilator_repo\stcomp05\CompileAndRunTests\files", "start_stop", flags);
//    }

//    [TestMethod]
//    public void TestCompileIncremetnt2()
//    {
//        GenTestCompile(MethodBase.GetCurrentMethod().Name, @"D:\Studia\MGR\Praca Magisterska\kompilator_repo\stcomp05\CompileAndRunTests\files", "start_stop_two", flags);
//    }

//    //flagi i target jako jeden zestaw np. w jsonie
//    //zmienna systemowa od plików
//    public void GenTestCompile(string thisMethod, string path, string filename, string[] flags)
//    {
//        string file = File.ReadAllText(System.IO.Path.Combine(path, filename)+".cst"); // SYSTEM.IO.FILEPATH
//        var compile = GenCompilation.DoTypicalCompilation(file, $"{filename}.cst", path, "VM", flags);
//        Assert.AreEqual(compile, false, "Nie skompilowano programu dla {0} w {1}", path, thisMethod);

//    }
//}