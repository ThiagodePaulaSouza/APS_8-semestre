using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Gateway;
public class Startup
{
    private readonly IConfiguration _configuration;
    
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureService(IServiceCollection services)
    {
        services.AddOcelot(_configuration);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.Map("/", async context =>
            {
                await context.Response.WriteAsync("Api Gateway Funcionando...");
            });
        });

        app.UseOcelot().Wait();
    }
}