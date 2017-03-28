namespace Legend.API
{
    using System.Web.Http;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FanexData.Register();
        }
    }
}