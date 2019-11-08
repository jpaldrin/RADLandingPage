using Newtonsoft.Json.Serialization;
using Ninject.Web.Mvc;
using System.Web.Http;
using External.RadProApp.Infrastructure;
using System.Net.Http.Headers;

namespace External.RadProApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
    
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
