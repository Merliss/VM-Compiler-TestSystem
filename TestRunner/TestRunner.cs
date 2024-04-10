using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompileAndRunTests.TestRunner1
{
    public class TestRunner
    {
        public void RunTests(Type testClass)
        {
            var methods = testClass.GetMethods();
            bool fst = true;
            foreach (var method in methods)
            {
                if (Attribute.IsDefined(method, typeof(TestMethodAttribute)))
                {
                    if (!fst)
                        Console.WriteLine("--Next test--");
                    fst = false;
                    var instance = Activator.CreateInstance(testClass);

                    // Execute setup method
                    //InvokeMethodsWithAttribute(testClass, typeof(SetupAttribute), instance);

                    try { 
                        try {
                            // Execute test method
                            method.Invoke(instance, null);
                        }
                        catch (System.Reflection.TargetInvocationException tie)
                        {
                            throw tie.InnerException;
                        } 
                    }
                    catch (AssertionException ex)
                    {
                        var p = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Failure : assertion failed in {method.Name}: Actual value:{ex.Actual}, Expected value:{ex.Expected}");
                        Console.ForegroundColor = p;
                    }
                    catch (AssertFailedException exp)
                    {
                        var p = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Failure : assertion failed in {method.Name}: message:{exp.Message}");
                        Console.ForegroundColor = p;
                    }
                    catch (Exception unhandled)
                    {
                        var p = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Failure : unhandled exception appeared in {method.Name}: Exception: {unhandled.Message}");
                        Console.ForegroundColor = p;
                    }
                    // Execute cleanup method
                    InvokeMethodsWithAttribute(testClass, typeof(TestCleanupAttribute), instance);
                }
            }
        }

        private void InvokeMethodsWithAttribute(Type testClass, Type attributeType, object instance)
        {
            var methods = testClass.GetMethods();

            foreach (var method in methods)
            {
                if (Attribute.IsDefined(method, attributeType))
                {
                    method.Invoke(instance, null);
                }
            }
        }
    }

    /*
    [AttributeUsage(AttributeTargets.Method)]
    public class TestMethodAttribute : Attribute { }
    
    [AttributeUsage(AttributeTargets.Method)]
    public class SetupAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class CleanupAttribute : Attribute { }
    */

}
