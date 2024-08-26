using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.SystemModels
{
    public class Language
    {
        [JsonProperty("iso639_1")]
        public string Iso639_1 { get; set; }

        [JsonProperty("iso639_2")]
        public string Iso639_2 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nativeName")]
        public string NativeName { get; set; }
    }
}
