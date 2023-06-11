using GPT_Web_Api_Lambda.CoreEntity;

namespace GPT_Web_Api_Lambda.GPTProduct
{
    public class GPTGenerateRequestModelDTO
    {
        public string prompt { get; set; }
        public ModelParameters ModelParameters { get; set; }
    }
}
