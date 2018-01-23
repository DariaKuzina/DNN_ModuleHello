using DotNetNuke.Web.Api;

namespace Christoc.Modules.MyFirstModule.Models
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("MyFirstModule", "default", "{controller}/{action}", new[] { "Christoc.Modules.MyFirstModule.Models" });
        }
    }
}
