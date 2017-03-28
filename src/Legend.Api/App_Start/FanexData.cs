using Fanex.Data;
using Fanex.Data.OldConnectionStringProvider;
using System.Configuration;

namespace Legend.API
{
    public static class FanexData
    {
        public static void Register()
        {
            var environment = ConfigurationManager.AppSettings["Environment"];
            DbSettingProviderManager
             .StartNewSession()
             .Use(new OldConnectionStringProvider())
             .UseDefaultDbSettingProvider(
               resourcePath: $"~/App_Data/{environment}",
               ignoreRedundantParameters: false,
               enableWatching: true)
             .Run();
        }
    }
}