using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CompileAndRunTests.TestUtils
{
    [DataContract]
    public class AssertObject
    {

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Variable {  get; set; }

        [DataMember]
        public double Expected {  get; set; }

        [DataMember]
        public double Delta { get; set; }

        [DataMember]
        public int Cycles { get; set; }                                                                                                        




    }
}
