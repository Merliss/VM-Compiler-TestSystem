using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace CompileAndRunTests.TestUtils
{
    [DataContract]
    [JsonObject]
    public class CombinedJson : System.Collections.IEnumerable
    {
        [DataMember]
        public string PathToTests { get; set; }

        [DataMember]
        public Kolekcja IncrementTestsJson { get; set; }

        public System.Collections.IEnumerator GetEnumerator()
        {
            return IncrementTestsJson.GetEnumerator();
        }
    }

    [Newtonsoft.Json.JsonArray]
    public class Kolekcja : List<IncrementTestsJson>
    { }
}
