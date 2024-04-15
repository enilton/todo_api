using Microsoft.Extensions.Configuration;

namespace Enilton.Thunders.Business.Helper
{
    public sealed class ConfigurationHelper
    {
        private ConfigurationHelper() { }
        public static IConfiguration Configuration { get; } = GetConfiguration();
        private static IConfiguration GetConfiguration()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json");           
            return config.Build();
        }
    }
}
