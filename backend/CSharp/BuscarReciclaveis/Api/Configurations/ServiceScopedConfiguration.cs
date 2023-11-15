using BuscarReciclaveis.Domain.Interfaces.Repository;
using BuscarReciclaveis.Domain.UnitOfWork;
using BuscarReciclaveis.Infra.Repository;
using BuscarReciclaveis.Infra.UnitOfWork;

namespace BuscarReciclaveis.Api.Configurations
{
    public static class ServiceScopedConfiguration
    {
        public static void AddServicesScopedConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IItemsReciclaveisRepository, ItemsReciclaveisRepository>();
            services.AddScoped<ICategoriasReciclaveisRepository, CategoriasReciclaveisRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}