using GPT_Web_Api_Lambda.CoreEntity;
using GPT_Web_Api_Lambda.GPTProduct;

namespace GPT_Web_Api_Lambda.Interfaces
{
    public interface IGPTAPIService
    {
        Task<List<string>> GenerateContentDaVinciAPI(GPTGenerateRequestModelDTO generateRequestModel);
        Task<List<string>> GenerateContentGptTurboAPI(GPTChatInput generateRequestModel);

        Task<List<string>> GenerateContentGpt4API(GPTChatInput generateRequestModel);
    }
}
