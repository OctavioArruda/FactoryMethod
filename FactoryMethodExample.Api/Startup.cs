using FactoryMethodExample.Application.Implementations.Factories;
using FactoryMethodExample.Application.Implementations.Services;
using FactoryMethodExample.Controllers;
using FactoryMethodExample.Domain.Contracts.Interfaces;
using Microsoft.OpenApi.Models;

namespace FactoryMethodExample;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddScoped<IPaymentServiceFactory, PaymentServiceFactory>();
        services.AddScoped<IPaymentService, PaymentService>();

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
            //c.RoutePrefix = string.Empty; // Serve Swagger UI at the root URL
        });

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
