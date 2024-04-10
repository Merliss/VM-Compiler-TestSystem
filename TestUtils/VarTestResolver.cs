using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CPDev.STComp05;
using CPSimulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompileAndRunTests.TestUtils
{
    public static class VarTestResolver
    {
       
        public static void RunVariableType(CPTarget cPTarget, string thisMethod, EvalInfo? result, AssertObject assertObject)
        {
            byte address = (byte)result.Value.Address;
            var type = result.Value.Type;

            switch (type)
            {
                case "$DEFAULT.SINT":
                    switch (assertObject.Type)
                    {
                        case "isEqual":
                            Assert.AreEqual(assertObject.Expected, cPTarget.GetDataByte(address), $"Actual value of {type} ({assertObject.Variable}) not equal expected in {thisMethod}\n");
                            //VarTestResolver.RunVariableType(cPTarget, thisMethod, result, assertObject);
                            break;
                        case "notEqual":
                            Assert.AreNotEqual(assertObject.Expected, cPTarget.GetDataByte(address), $"Actual value of ({assertObject.Variable}) equal expected in {thisMethod}\n");
                            break;
                        case "isTrue":
                            Assert.IsTrue(cPTarget.GetDataByte(address) != 0, $"Actual value of ({assertObject.Variable}) is not True in {thisMethod}\n");
                            break;
                        case "isFalse":
                            Assert.IsFalse(cPTarget.GetDataByte(address) == 0, $"Actual value of  ({assertObject.Variable}) is not False in {thisMethod}\n");
                            break;
                        default:
                            throw new ArgumentException($"Invalid type of assertion in {thisMethod}", $"{assertObject.Type}\n");
                    }
                    break;
                case "$DEFAULT.BYTE":
                    switch (assertObject.Type)
                    {
                        case "isEqual":
                            Assert.AreEqual(assertObject.Expected, cPTarget.GetDataByte(address), $"Actual value of {type} ({assertObject.Variable}) not equal expected in {thisMethod}\n");
                            //VarTestResolver.RunVariableType(cPTarget, thisMethod, result, assertObject);
                            break;
                        case "notEqual":
                            Assert.AreNotEqual(assertObject.Expected, cPTarget.GetDataByte(address), $"Actual value of ({assertObject.Variable}) equal expected in {thisMethod}\n");
                            break;
                        case "isTrue":
                            Assert.IsTrue(cPTarget.GetDataByte(address) != 0, $"Actual value of ({assertObject.Variable}) is not True in {thisMethod}\n");
                            break;
                        case "isFalse":
                            Assert.IsFalse(cPTarget.GetDataByte(address) == 0, $"Actual value of  ({assertObject.Variable}) is not False in {thisMethod}\n");
                            break;
                        default:
                            throw new ArgumentException($"Invalid type of assertion in {thisMethod}", $"{assertObject.Type}\n");
                    }
                    break;
                case "$DEFAULT.INT":
                    switch (assertObject.Type)
                    {
                        case "isEqual":
                            Assert.AreEqual(assertObject.Expected, cPTarget.GetDataWord(address), $"Actual value of {type} ({assertObject.Variable}) not equal expected in {thisMethod}\n");
                            //VarTestResolver.RunVariableType(cPTarget, thisMethod, result, assertObject);
                            break;
                        case "notEqual":
                            Assert.AreNotEqual(assertObject.Expected, cPTarget.GetDataWord(address), $"Actual value of ({assertObject.Variable}) equal expected in {thisMethod}\n");
                            break;
                        case "isTrue":
                            Assert.IsTrue(cPTarget.GetDataWord(address) != 0, $"Actual value of ({assertObject.Variable}) is not True in {thisMethod}\n");
                            break;
                        case "isFalse":
                            Assert.IsFalse(cPTarget.GetDataWord(address) == 0, $"Actual value of  ({assertObject.Variable}) is not False in {thisMethod}\n");
                            break;
                        default:
                            throw new ArgumentException($"Invalid type of assertion in {thisMethod}", $"{assertObject.Type}\n");
                    }
                    break;
                case "$DEFAULT.LINT":
                    switch (assertObject.Type)
                    {
                        case "isEqual":
                            Assert.AreEqual(assertObject.Expected, cPTarget.GetDataLWord(address), $"Actual value of {type} ({assertObject.Variable}) not equal expected in {thisMethod}\n");
                            //VarTestResolver.RunVariableType(cPTarget, thisMethod, result, assertObject);
                            break;
                        case "notEqual":
                            Assert.AreNotEqual(assertObject.Expected, cPTarget.GetDataLWord(address), $"Actual value of ({assertObject.Variable}) equal expected in {thisMethod}\n");
                            break;
                        case "isTrue":
                            Assert.IsTrue(cPTarget.GetDataLWord(address) != 0, $"Actual value of ({assertObject.Variable}) is not True in {thisMethod}\n");
                            break;
                        case "isFalse":
                            Assert.IsFalse(cPTarget.GetDataLWord(address) == 0, $"Actual value of  ({assertObject.Variable}) is not False in {thisMethod}\n");
                            break;
                        default:
                            throw new ArgumentException($"Invalid type of assertion in {thisMethod}", $"{assertObject.Type}\n");
                    }
                    break;
                case "$DEFAULT.REAL":
                    switch (assertObject.Type)
                    {
                        case "isEqual":
                            Assert.AreEqual(assertObject.Expected, cPTarget.GetDataReal(address), $"Actual value of {type} ({assertObject.Variable}) not equal expected in {thisMethod}\n");
                            //VarTestResolver.RunVariableType(cPTarget, thisMethod, result, assertObject);
                            break;
                        case "notEqual":
                            Assert.AreNotEqual(assertObject.Expected, cPTarget.GetDataReal(address), $"Actual value of ({assertObject.Variable}) equal expected in {thisMethod}\n");
                            break;
                        case "isTrue":
                            Assert.IsTrue(cPTarget.GetDataReal(address) != 0, $"Actual value of ({assertObject.Variable}) is not True in {thisMethod}\n");
                            break;
                        case "isFalse":
                            Assert.IsFalse(cPTarget.GetDataReal(address) == 0, $"Actual value of  ({assertObject.Variable}) is not False in {thisMethod}\n");
                            break;
                        default:
                            throw new ArgumentException($"Invalid type of assertion in {thisMethod}", $"{assertObject.Type}\n");
                    }
                    break;
                case "$DEFAULT.LREAL":
                    switch (assertObject.Type)
                    {
                        case "isEqual":
                            Assert.AreEqual(assertObject.Expected, cPTarget.GetDataLReal(address), $"Actual value of {type} ({assertObject.Variable}) not equal expected in {thisMethod}\n");
                            //VarTestResolver.RunVariableType(cPTarget, thisMethod, result, assertObject);
                            break;
                        case "notEqual":
                            Assert.AreNotEqual(assertObject.Expected, cPTarget.GetDataLReal(address), $"Actual value of ({assertObject.Variable}) equal expected in {thisMethod}\n");
                            break;
                        case "isTrue":
                            Assert.IsTrue(cPTarget.GetDataLReal(address) != 0, $"Actual value of ({assertObject.Variable}) is not True in {thisMethod}\n");
                            break;
                        case "isFalse":
                            Assert.IsFalse(cPTarget.GetDataLReal(address) == 0, $"Actual value of  ({assertObject.Variable}) is not False in {thisMethod}\n");
                            break;
                        default:
                            throw new ArgumentException($"Invalid type of assertion in {thisMethod}", $"{assertObject.Type}\n");
                    }
                    break;
                case "$DEFAULT.STRING":                 
                    switch (assertObject.Type)
                    {
                        case "isEqual":
                            Assert.AreEqual(assertObject.Expected, cPTarget.GetDataString(address), $"Actual value of {type} ({assertObject.Variable}) not equal expected in {thisMethod}\n");
                            //VarTestResolver.RunVariableType(cPTarget, thisMethod, result, assertObject);
                            break;
                        case "notEqual":
                            Assert.AreNotEqual(assertObject.Expected, cPTarget.GetDataString(address), $"Actual value of ({assertObject.Variable}) equal expected in {thisMethod}\n");
                            break;
                        case "isNull":
                            Assert.IsNull(cPTarget.GetDataByte(address), $"Actual value of ({assertObject.Variable}) is not Null in {thisMethod}\n");
                            break;
                        case "notNull":
                            Assert.IsNotNull(cPTarget.GetDataByte(address), $"Actual value of ({assertObject.Variable}) is Null in {thisMethod}\n");
                            break;
                        default:
                            throw new ArgumentException($"Invalid type of assertion in {thisMethod}", $"{assertObject.Type}\n");
                    }
                    break;

                case null:
                    throw new ArgumentException("Nienznaleziono typu danych");
            }

        }
    }
}
