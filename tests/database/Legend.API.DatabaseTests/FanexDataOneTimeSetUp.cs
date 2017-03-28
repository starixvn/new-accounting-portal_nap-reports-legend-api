using Fanex.Data;
using Fanex.Data.OldConnectionStringProvider;
using NUnit.Framework;

[SetUpFixture]
public class FanexDataOneTimeSetUp
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        DbSettingProviderManager
       .StartNewSession()
       .Use(new OldConnectionStringProvider())
       .UseDefaultDbSettingProvider(
         "~/App_Data/LOCAL",
         false,
         true)
       .Run();
    }
}