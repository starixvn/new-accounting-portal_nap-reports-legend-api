using Newtonsoft.Json.Serialization;
using Olympus.WebApi.Attributes;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Legend.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            configuration.EnableCors(cors);
            configuration.MapHttpAttributeRoutes();
            var defaultOption = new
            {
                id = RouteParameter.Optional
            };
            configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: defaultOption);

            configuration.Formatters.Clear();
            configuration.Formatters.Add(new JsonMediaTypeFormatter());
            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            configuration.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            GlobalConfiguration.Configuration.Filters.Add(new LogExceptionFilterAttribute());
        }
    }
}
