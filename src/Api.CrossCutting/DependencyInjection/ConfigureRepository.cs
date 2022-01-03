using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Configuration;
using Api.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Api.CrossCutting.DependencyInjection
{
    public static class ConfigureRepository
    {
        public static void AddConfigureRepository(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = new ConnectionStringConfiguration();
            new ConfigureFromConfigurationOptions<ConnectionStringConfiguration>(
                configuration.GetSection("ConnectionStringConfiguration"))
                    .Configure(connectionString);

            services.AddDbContext<PontoEletronicoContext>(
                options => options.UseSqlServer(connectionString.ConnectionString));


            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        }
    }
}
