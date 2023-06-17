using GPT_Web_Api_Lambda.CoreEntity;
using GPT_Web_Api_Lambda.GPTProduct;
using GPT_Web_Api_Lambda.Interfaces;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

namespace GPT_Web_Api_Lambda.Network
{
    public class GPTAPIService : IGPTAPIService
    {
        private readonly IConfig _config;
        public GPTAPIService(IConfig config)
        {
            _config = config;
        }

        public async Task<List<string>> GenerateContentDaVinciAPI(GPTGenerateRequestModelDTO generateRequestModel)
        {
            //If you are testing locally replace with the test Open Ai api key value.
            //You will be able to get it from the evironment variable section of 
            //the gpt test lambda function page/ui.
            var apiKey = Environment.GetEnvironmentVariable("Open_Ai_Api_Key");

            List<string> rq = new List<string>();
            string rs = "";
            OpenAIAPI api = new OpenAIAPI(new APIAuthentication(apiKey));

            var completionRequest = new OpenAI_API.Completions.CompletionRequest()
            {
                Prompt = generateRequestModel.prompt,
                Model = Model.DavinciText,
                Temperature = 0.5,
                MaxTokens = 500,
                TopP = 1.0,
                FrequencyPenalty = 0.0,
                PresencePenalty = 0.0,

            };

            var result = await api.Completions.CreateCompletionsAsync(completionRequest);
            foreach (var choice in result.Completions)
            {
                rq.Add(choice.Text);
                rq.Distinct();
            }

            return rq;
        }

        public async Task<List<string>> GenerateContentGptTurboAPI(GPTChatInput generateRequestModel)
        {
            //If you are testing locally replace with the test Open Ai api key value.
            //You will be able to get it from the evironment variable section of 
            //the gpt test lambda function page/ui.
            var apiKey = Environment.GetEnvironmentVariable("Open_Ai_Api_Key");

            List<string> rq = new List<string>();
            OpenAIAPI api = new OpenAIAPI(new APIAuthentication(apiKey));

            //GPT models use a different strusture when formatting the request (in comparison to davinci model)
            //because of this our input, and the way we query the model changes.
            List<ChatMessage> messages = new List<ChatMessage>();

            foreach (var gptm in generateRequestModel.GptMessages)
            {
                messages.Add(new ChatMessage(InternalConsistencyCheck(gptm.Role), gptm.Content));
            }

            var chatRequest = new ChatRequest()
            {
                Messages = messages,
                Model = Model.ChatGPTTurbo,
                Temperature = generateRequestModel.ModelParameters.Temperature != 0.0 ? generateRequestModel.ModelParameters.Temperature : 0.5,
                MaxTokens = generateRequestModel.ModelParameters.MaxTokens != 0 ? generateRequestModel.ModelParameters.MaxTokens : 250,
                TopP = generateRequestModel.ModelParameters.TopP != 0.0 ? generateRequestModel.ModelParameters.TopP : 1.0,
                FrequencyPenalty = 0.0,
                PresencePenalty = 0.0,

            };

            var result = await api.Chat.CreateChatCompletionAsync(chatRequest);

            foreach (var choice in result.Choices)
            {
                rq.Add(choice.Message.Content);
                rq.Distinct();
            }

            return rq;
        }

        public async Task<List<string>> GenerateContentGpt4API(GPTChatInput generateRequestModel)
        {
            //If you are testing locally replace with the test Open Ai api key value.
            //You will be able to get it from the evironment variable section of 
            //the gpt test lambda function page/ui.
            var apiKey = Environment.GetEnvironmentVariable("Open_Ai_Api_Key");

            List<string> rq = new List<string>();
            OpenAIAPI api = new OpenAIAPI(new APIAuthentication(apiKey));

            //GPT models use a different strusture when formatting the request (in comparison to davinci model)
            //because of this our input, and the way we query the model changes.
            List<ChatMessage> messages = new List<ChatMessage>();

            foreach (var gptm in generateRequestModel.GptMessages)
            {
                messages.Add(new ChatMessage(InternalConsistencyCheck(gptm.Role), gptm.Content));
            }

            var chatRequest = new ChatRequest()
            {
                Messages = messages,
                Model = Model.GPT4,
                Temperature = generateRequestModel.ModelParameters.Temperature != 0.0 ? generateRequestModel.ModelParameters.Temperature : 0.5,
                MaxTokens = generateRequestModel.ModelParameters.MaxTokens != 0 ? generateRequestModel.ModelParameters.MaxTokens : 250,
                TopP = generateRequestModel.ModelParameters.TopP != 0.0 ? generateRequestModel.ModelParameters.TopP : 1.0,
                FrequencyPenalty = 0.0,
                PresencePenalty = 0.0,

            };

            var result = await api.Chat.CreateChatCompletionAsync(chatRequest);

            foreach (var choice in result.Choices)
            {
                rq.Add(choice.Message.Content);
                rq.Distinct();
            }

            return rq;
        }

        private ChatMessageRole InternalConsistencyCheck(string roleName)
        {
            switch (roleName)
            {
                case "system":
                    return ChatMessageRole.System;
                case "user":
                    return ChatMessageRole.User;
                case "assistant":
                    return ChatMessageRole.Assistant;
                default:
                    return ChatMessageRole.User;
            }
        }
    }
}
