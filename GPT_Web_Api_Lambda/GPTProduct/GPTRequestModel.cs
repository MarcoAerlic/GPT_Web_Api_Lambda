using GPT_Web_Api_Lambda.CoreEntity;

namespace GPT_Web_Api_Lambda.GPTProduct
{
    public class GPTRequestModel
    {
        public string Message { get; set; }

        public ModelParameters ModelParameters { get; set; }
    }
}
