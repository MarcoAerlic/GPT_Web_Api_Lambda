using Newtonsoft.Json;

namespace GPT_Web_Api_Lambda.CoreEntity
{
    public class GPTChatInput
    {
        public GPTChatInput(List<GPTMessage> gptMessages, ModelParameters modelParameters)
        {
            this.GptMessages = gptMessages;
            this.ModelParameters = modelParameters;
        }

        [JsonProperty("chatmessages")]
        public List<GPTMessage> GptMessages { get; set; }

        [JsonProperty("modelparameters")]
        public ModelParameters ModelParameters { get; set; }
    }
}
