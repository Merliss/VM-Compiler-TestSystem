using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileAndRunTests
{
    internal class AssertionException : Exception
    {
        public object Actual { get; }
        public object Expected { get; }
        public AssertionException(object actual, object expected)
        {
            Actual = actual;
            Expected = expected;
            
        }
    }
}
