using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using JET.WebApi.Filter;
using Microsoft.Practices.Unity;

namespace JET.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Dependency Resolver
            var container = new UnityContainer();
            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services
            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();


            // Force HTTPS on entire API
            config.Filters.Add(new RequireHttpsAttributeCustomize());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
