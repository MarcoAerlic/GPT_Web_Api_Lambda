using GPT_Web_Api_Lambda.GPTProduct;
using GPT_Web_Api_Lambda.Interfaces;
using GPT_Web_Api_Lambda.Network;
using GPT_Web_Api_Lambda.Configuration;

namespace GPT_Web_Api_Lambda
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            var deployment = Enum.Parse<Deployment>(_env.EnvironmentName, true);
            var config = new Config(deployment);
            services.AddControllers();
            services.AddTransient<IGPTProductService, GPTProductService>();
            services.AddTransient<IGPTAPIService, GPTAPIService>();
            services.AddSwaggerGen();
            services.AddConfig(deployment);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger().UseSwaggerUI(setup =>
            {
                string swaggerJsonBasePath = string.IsNullOrEmpty(setup.RoutePrefix) ? "." : "..";
                setup.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Version 1.0");
                setup.OAuthAppName("Gpt API");
                setup.OAuthScopeSeparator(" ");
                setup.OAuthUsePkce();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
                });
            });
        }
    }
}