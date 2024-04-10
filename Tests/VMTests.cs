using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CompileAndRunTests.Exceptions.CompileAndRunTests;
using CompileAndRunTests.TestRunner1;
using CPSimulation;
using static System.Collections.Specialized.BitVector32;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompileAndRunTests.Compilation;
using CPDev.STComp05;
using CompileAndRunTests.TestUtils;
using System.Runtime.Serialization.Json;
using CompileAndRunTests.ViewUtils;

namespace CompileAndRunTests.Tests
{
    [TestClass]
    public class VMTests
    {
        private static JsonUtils _jsonUtils;
        private static CPDev.STComp05.FileNameConvert _fnconvert;


        public VMTests()
        {
            _jsonUtils = new JsonUtils();
            _fnconvert = new CPDev.STComp05.FileNameConvert();
        }

#if never
        // [TestMethod]
        public void Test_Value_Increment_By_1()
        {
            
            var thisMethod = MethodBase.GetCurrentMethod().Name;
            GenTestsMethods.GenTestRun(are,cPTarget, thisMethod, Increment_Value_By_1, @"D:\Studia\MGR\Praca Magisterska\kompilator_repo\stcomp05\CompileAndRunTests\files\start_stop", "WYNIK2",18);
        }

        public void Increment_Value_By_1(string thisMethod, uint addr, byte expected)
        {
            GenTestsMethods.TestValueEqualByte(cPTarget, addr, expected, thisMethod);
        }


       // [TestMethod]
        public void Test_Value_Multiply_By_5()
        {
            GenTestsMethods.GenTestRun(are, cPTarget,MethodBase.GetCurrentMethod().Name, Value_Multiply_By_5, @"D:\Studia\MGR\Praca Magisterska\kompilator_repo\stcomp05\CompileAndRunTests\files\start_stop_two", "WYNIK2",19);
        }

        public void Value_Multiply_By_5(string thisMethod, uint addr,byte expected)
        {
            GenTestsMethods.TestValueEqualByte(cPTarget,addr, expected, thisMethod);
        }
#endif

      

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

                    var p = Console.ForegroundColor;
                    ConsoleDraw.DrawFrameAroundText($"Group: {group.Key}",ConsoleColor.Blue);

                    foreach (var test in group.Value)
                    {
                        foreach (var assertObject in test.AssertObjects)
                        {


                            try
                            {
                                RunTest(test, combo, assertObject);
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

        public void RunTest(SingleTest test, CombinedJson combo, AssertObject assertObject)
        {
            string CPDevTestsPath = _fnconvert.UnfoldEnvironmentVariable(combo.PathToTests);
            var methodName = $"Test_{test.Filename}";
            AutoResetEvent are = new AutoResetEvent(false);
            CPTarget cPTarget = new CPTarget();
            GenTestsMethods.GenTestRun(are, cPTarget, methodName, RunTest_helper, System.IO.Path.Combine(CPDevTestsPath, test.Filename), assertObject);
            are.Reset();
            are = null;
        }

        public void RunTest_helper(string thisMethod,CPTarget cPTarget, EvalInfo? result, AssertObject assertObject)
        {
            GenTestsMethods.TestValueEqualByte(cPTarget,thisMethod,result, assertObject);
        }


        [TestCleanup]
        public void Cleanup()
        {
        }

        
    }
}
