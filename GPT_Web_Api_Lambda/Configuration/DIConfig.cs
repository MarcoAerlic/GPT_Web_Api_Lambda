using GPT_Web_Api_Lambda.Interfaces;

namespace GPT_Web_Api_Lambda.Configuration
{
    public static class DIConfig
    {
        public static IServiceCollection AddConfig(this IServiceCollection services, Deployment deployment)
        {
            return services
                .AddTransient<IConfig, Config>((serviceProvider) => new Config(deployment));

        }
    }
}
