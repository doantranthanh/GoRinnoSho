using System.Web.Http;
using JET.Services.Implementations.WebClient;
using JET.Services.Interfaces.WebClient;
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
