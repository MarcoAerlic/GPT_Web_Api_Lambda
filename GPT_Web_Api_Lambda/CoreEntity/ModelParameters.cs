using Newtonsoft.Json;

namespace GPT_Web_Api_Lambda.CoreEntity
{
    public class ModelParameters
    {
        [JsonProperty("temperature")]
        public double? Temperature { get; set; }

        [JsonProperty("maxtokens")]
        public int? MaxTokens { get; set; }

        [JsonProperty("topp")]
        public double? TopP { get; set; }
    }
}
