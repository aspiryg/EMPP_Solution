using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.SystemModels
{
    public class CountryDTO
    {
        public CountryNameDTO? Name { get; set; }

        [JsonProperty("languages")]
        public Dictionary<string, string> Languages { get; set; }
    }
}
