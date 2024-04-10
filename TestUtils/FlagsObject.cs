using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CompileAndRunTests.TestUtils
{
    [DataContract]
    public class CompObject
    {
        [DataMember]
        public string SF_Flags { get; set; }

        [DataMember]
        public string CF_Flags { get; set; }

        [DataMember]
        public string LOF_Flags { get; set; }

        [DataMember]
        public string OPT_Flags { get; set; }

        [DataMember]
        public string VMSpec { get; set; }

        [DataMember]
        public string DCP_OUT_Flags { get; set; }

    }
}
