using GPT_Web_Api_Lambda.CoreEntity;
using GPT_Web_Api_Lambda.GPTProduct;

namespace GPT_Web_Api_Lambda.Interfaces
{
    public interface IGPTProductService
    {
        Task<GPTProductResponseModel> GenerateContentDaVinci(CustomerRequestModel gptGenerateRequestModel);
        Task<GPTProductResponseModel> GenerateContentGptTurbo(GPTChatInput gptGenerateRequestModel);
        Task<GPTProductResponseModel> GenerateContentGpt4(GPTChatInput gptGenerateRequestModel);
    }
}
