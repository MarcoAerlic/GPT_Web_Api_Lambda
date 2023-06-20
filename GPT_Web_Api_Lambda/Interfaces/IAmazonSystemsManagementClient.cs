namespace GPT_Web_Api_Lambda.Interfaces
{
    public interface IAmazonSystemsManagementClient
    {
        Task<string> GetParameterAsync(string parameterName);
    }
}
