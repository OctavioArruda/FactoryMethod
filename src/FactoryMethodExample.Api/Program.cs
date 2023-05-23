using FactoryMethodExample.Controllers;
using Microsoft.OpenApi.Models;

namespace FactoryMethodExample;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        
        // Registering the API controller
        services.AddMvc().AddApplicationPart(typeof(PaymentController).Assembly);

        // Configure Swagger
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Factory Method API", Version = "v1" });
        });
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Factory Method API v1");
            c.RoutePrefix = string.Empty; // Serve Swagger UI at the root URL
        });
    }
}