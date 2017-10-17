namespace Legend.API
{
    using System;
    using System.Web.Http;
    using App_Start;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FanexData.Register();
            FanexLogging.Register();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            FanexLogging.HandleApplicationError(Server);
        }
    }
}