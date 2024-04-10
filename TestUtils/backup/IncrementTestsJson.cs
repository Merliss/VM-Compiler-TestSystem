using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace CompileAndRunTests.TestUtils
{
    [DataContract]
    public class IncrementTestsJson
    {
        [DataMember]
        public string Filename { get; set; }
        [DataMember]
        public byte ExpectedValue { get; set; }
        [DataMember]
        public string Address { get; set; }
    }

}
