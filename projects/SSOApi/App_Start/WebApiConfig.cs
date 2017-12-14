using System.Web.Http;
using System.Web.Http.Cors;

namespace SSOApi
{
    public static class WebApiConfig
    {
        public static HttpConfiguration Register()
        {
            // Web API configuration and services
            var config = new HttpConfiguration();
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableCors(new EnableCorsAttribute("https://localhost:44300, http://192.168.1.115/jsClient, http://192.168.1.115/mvcClient, http://localhost:21575, http://localhost:37045, http://localhost:5607, http://localhost:37046, https://localhost:44301", "accept, authorization", "GET", "WWW-Authenticate"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}",
                defaults: new { id = RouteParameter.Optional }
            );

            return config;
        }
    }
}