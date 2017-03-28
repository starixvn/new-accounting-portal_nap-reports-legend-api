using Fanex.Data.Repository;
using Legend.API;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(SimpleInjectorApiConfig), "Initialize")]

namespace Legend.API
{
    public class SimpleInjectorApiConfig
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register<IDynamicRepository, DynamicRepository>();

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
