using Amazon;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using GPT_Web_Api_Lambda.Interfaces;

namespace GPT_Web_Api_Lambda.AWSSSM
{
    public class AmazonSystemsManagementClient : IAmazonSystemsManagementClient
    {
        private static AmazonSimpleSystemsManagementClient _amazonSimpleSystemsManagementClient;
        private static readonly RegionEndpoint BucketRegion = RegionEndpoint.APSoutheast2;

        public AmazonSystemsManagementClient()
        {
            _amazonSimpleSystemsManagementClient = new AmazonSimpleSystemsManagementClient(BucketRegion);
        }

        /// <summary>
        /// Get value from AWS SSM by key
        /// </summary>
        /// <param name="parameterName">parameter key name</param>
        /// <returns>Value of parameter</returns>
        public async Task<string> GetParameterAsync(string parameterName)
        {

            var request = new GetParameterRequest()
            {
                Name = parameterName,
                WithDecryption = true,
            };
            var response = await _amazonSimpleSystemsManagementClient.GetParameterAsync(request);
            var value = response.Parameter.Value;

            if (value != null)
            {
                return value;
            }

            return string.Empty;
        }
    }
}
