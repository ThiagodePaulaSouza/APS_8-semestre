using BuscarReciclaveis.Api.Configurations;
using BuscarReciclaveis.Configurations;

namespace BuscarReciclaveis
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
            => Configuration = configuration;
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataBaseConfiguration();
            services.AddControllers();
            services.AddCorsConfiguration();
            services.AddSwaggerConfiguration();
            services.AddServicesScopedConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseAuthorization();
            app.UseSwaggerConfiguration();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            app.Run(async (context) => await context.Response.WriteAsync("Buscar Reciclaveis API funcionando..."));
        }
    }
}
