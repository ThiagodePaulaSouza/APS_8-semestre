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
            var uriString = Constants.ConnectionString;
            var uri = new Uri(uriString);
            var db = uri.AbsolutePath.Trim('/');
            var user = uri.UserInfo.Split(':')[0];
            var passwd = uri.UserInfo.Split(':')[1];
            var port = uri.Port > 0 ? uri.Port : 5432;
            var connStr = string.Format($"Server={uri.Host};Database={db};User Id={user};Password={passwd};Port={port}");

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(connStr));
        }
    }
}