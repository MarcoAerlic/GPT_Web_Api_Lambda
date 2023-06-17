using GPT_Web_Api_Lambda.Configuration;
using Microsoft.AspNetCore.Builder;

namespace GPT_Web_Api_Lambda.Interfaces
{
    public enum Deployment { Development, Test, Demo, Production, UAT }
    public interface IConfig
    {
        Deployment Deployment { get; }

    }
}
