using Microsoft.Extensions.Configuration;
using System.IO;
using TooSeguros.Domain.Util;

namespace TooSeguros.Infra.Data.Util
{
    public static class Configuration
    {
        private static readonly IConfiguration _configuration;

        static Configuration() 
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            _configuration = builder.Build();
        }

        public static TokenConfigurations GetTokenConfigurations()
        {
            IConfigurationSection section = _configuration.GetSection("TokenConfigurations");
            return new TokenConfigurations()
            {
                Secret = section["Secret"]
            };
        }

        public static ConnectionsConfigurations GetConnection()
        {
            IConfigurationSection section = _configuration.GetSection("Connections");
            return new ConnectionsConfigurations()
            {
                ConnectionString = section["ConnectionString"]
            };
        }
    }
}
