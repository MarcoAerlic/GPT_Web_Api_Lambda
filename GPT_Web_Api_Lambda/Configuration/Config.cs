using GPT_Web_Api_Lambda.Interfaces;
using Microsoft.AspNetCore.Builder;

namespace GPT_Web_Api_Lambda.Configuration
{
    public class Config : IConfig
    {
        private readonly IConfiguration _configuration;
        private readonly Deployment _deployment;

        public Config(Deployment deployment)
        {
            var builder = new ConfigurationBuilder();

            builder.AddJsonFile($"appsettings.{deployment}.json", optional: true);

            _deployment = deployment;
            _configuration = builder.Build();
        }

        public Deployment Deployment => _deployment;

        public string GetConfig(string[] args) => _configuration[$"{string.Join(":", args)}"];

    }
}
