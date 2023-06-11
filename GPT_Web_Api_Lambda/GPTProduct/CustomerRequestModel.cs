using GPT_Web_Api_Lambda.CoreEntity;

namespace GPT_Web_Api_Lambda.GPTProduct
{
    public class CustomerRequestModel
    {
        public string Message { get; set; }

        public ModelParameters ModelParameters { get; set; }
    }
}
