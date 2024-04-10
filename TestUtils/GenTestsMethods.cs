using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPDev.STComp05;
using CPSimulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPSimulation;

namespace CompileAndRunTests.TestUtils
{
    internal class GenTestsMethods
    {
        public static void GenTestRun(System.Threading.AutoResetEvent are, CPTarget cPTarget, string thisMethod, Action<string, CPTarget, EvalInfo?, AssertObject> acn, string path, AssertObject assertObject)
        {
            string message;
            int cycles = 0;

            System.Diagnostics.Debug.WriteLine("#### Test " + path);
            IEvalToken itoken = AddressResolver.PrepareEvalOfTextExpression(path + ".dcp", out message);
            EvalInfo? result = AddressResolver.EvalGlobalAddressOfTextExpression(assertObject.Variable, "", itoken, out message);
            var Load = cPTarget.LoadProgram(path + ".xcp", 0x10000);
            Assert.AreEqual(Load, 0, "Nie załadowano programu dla {0} w {1}", path, thisMethod);



            CPDev.Public.CycleEndEvent cee = () =>
            {
                cycles++;
                if (cycles >= assertObject.Cycles)
                {
                    are.Set();
                    cPTarget.Stop();
                }
            };
            CPDev.Public.StoppedEvent ste = (int r) => are.Set();
            CPDev.Public.CodeErrorEvent cer = (string s) => are.Set();
            cPTarget.OnCycleEnd += cee;
            cPTarget.OnCodeError += cer;
            cPTarget.OnStopped += ste;

            int vm = cPTarget.Run(1);
            are.WaitOne();

            cPTarget.OnCycleEnd -= cee;
            cPTarget.OnStopped -= ste;
            cPTarget.OnCodeError -= cer;
            acn(thisMethod, cPTarget, result, assertObject);
        }



        public static void TestValueEqualByte(CPTarget cPTarget, string thisMethod, EvalInfo? result, AssertObject assertObject)
        {

            byte address = (byte)result.Value.Address;
            var type = result.Value.Type;
            VarTestResolver.RunVariableType(cPTarget, thisMethod, result, assertObject);
     

        }
  
    }

}
