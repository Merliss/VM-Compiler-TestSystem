using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompileAndRunTests.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace CompileAndRunTests
    {
        internal class AssertionNotEqualException : Exception
        {
            public object Actual { get; }
            public object Unwanted { get; }
            public AssertionNotEqualException(object actual, object unwanted)
            {
                Actual = actual;
                Unwanted = unwanted;

            }
        }
    }

}
