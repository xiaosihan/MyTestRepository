using System.Web.Http;
using System.Web.Http.OData.Extensions;
using System.Net.Http.Formatting;

namespace GitTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 路由
            config.MapHttpAttributeRoutes();

            // Odata配置
            config.Formatters.JsonFormatter.AddQueryStringMapping("$format", "json", "application/json");
            config.Formatters.JsonFormatter.AddQueryStringMapping("$format", "xml", "application/xml");

            //允许使用Odata查询
            config.AddODataQueryFilter();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
