using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuscarReciclaveis.Domain.Helpers;
using BuscarReciclaveis.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace BuscarReciclaveis.Api.Configurations
{
    public static class DataBaseConfiguration
    {
        public static void AddDataBaseConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(Constants.ConnectionString));
        }
    }
}