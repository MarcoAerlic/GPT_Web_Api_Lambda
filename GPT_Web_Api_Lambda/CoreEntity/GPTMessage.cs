using Newtonsoft.Json;

namespace GPT_Web_Api_Lambda.CoreEntity
{
    public class GPTMessage
    {
        public GPTMessage(string role, string content)
        {
            this.Role = role;
            this.Content = content;
        }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
