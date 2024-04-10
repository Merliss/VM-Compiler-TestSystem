using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CompileAndRunTests.TestUtils
{
    [DataContract]
    public class SingleTest
    {
        [DataMember]
        public string Filename { get; set; }

        [DataMember]

        public CompObject CompObj { get; set; }

        [DataMember]
        public List<AssertObject> AssertObjects { get; set; }
       
    }
}
