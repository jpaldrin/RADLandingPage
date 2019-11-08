using System.Web.Mvc;
using System.Web.Routing;

namespace External.RadProApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}", new { controller = "Home", action = "Index", id = UrlParameter.Optional }, new[] { "URLsAndRoutes.AdditionalControllers" });

            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}