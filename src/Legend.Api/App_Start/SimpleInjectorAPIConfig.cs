using Fanex.Caching;
using Fanex.Data.Repository;
using Fanex.NAP.Core.Service.Impl;
using Fanex.NAP.Core.Service.Interface;
using Legend.API;
using Legend.API.Controllers;
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
            container.Register<ISiteService, SiteService>();
            container.Register<CacheService>(() => new CacheServiceImpl());
            container.Register<LegendService, LegendServiceImp>();

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
