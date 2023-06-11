using GPT_Web_Api_Lambda.CoreEntity;
using GPT_Web_Api_Lambda.GPTProduct;
using GPT_Web_Api_Lambda.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GPT_Web_Api_Lambda.Controllers
{
    [Route("api/[controller]")]
    public class GptController : ControllerBase
    {
        private readonly IGPTProductService _adProduct;
        public GptController(IGPTProductService adProduct)
        {
            _adProduct = adProduct;
        }

        [HttpPost("ExtractDataGptTurbo")]
        public async Task<ActionResult<GPTProductResponseModel>> GenerateContentGptTurbo([FromBody] GPTChatInput aDGenerateRequestModel)
        {
            try
            {

                var response = await _adProduct.GenerateContentGptTurbo(aDGenerateRequestModel);

                return response;
            }
            catch (System.Exception ex)
            {

                return null;
            }

        }

        [HttpPost("ExtractDataGpt4")]
        public async Task<ActionResult<GPTProductResponseModel>> GenerateContentGpt4([FromBody] GPTChatInput aDGenerateRequestModel)
        {
            try
            {

                var response = await _adProduct.GenerateContentGpt4(aDGenerateRequestModel);

                return response;
            }
            catch (System.Exception ex)
            {

                return null;
            }

        }

        [HttpPost("ExtractDataDavinci")]
        public async Task<ActionResult<GPTProductResponseModel>> GenerateContentDaVinci([FromBody] CustomerRequestModel aDGenerateRequestModel)
        {
            try
            {

                var response = await _adProduct.GenerateContentDaVinci(aDGenerateRequestModel);

                return response;
            }
            catch (System.Exception ex)
            {

                return null;
            }

        }
    }
}
