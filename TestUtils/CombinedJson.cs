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
    public class CombinedJson
    {
        [JsonProperty("PathToTests")]
        public string PathToTests { get; set; }

        [JsonProperty("GroupOfTestsJson")]
        public Dictionary<string, List<SingleTest>> GroupOfTestsJson { get; set; }
    }
    }
