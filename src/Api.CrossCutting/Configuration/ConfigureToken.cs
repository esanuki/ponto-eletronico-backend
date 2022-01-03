using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Api.CrossCutting.Configuration
{
    public static class ConfigureToken
    {
        public static void AddTokenConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                configuration.GetSection("TokenConfigurations"))
                .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);

            var signingConfigurations = new SigningConfiguration();
            services.AddSingleton(signingConfigurations);
        }
    }
}
