using DotNetNuke.Web.Api;

namespace Connect.DNN.Modules.HitchARide.Api
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute("Connect/HitchARide", "HitchARideMap1", "{controller}/{action}", null, null, new[] { "Connect.DNN.Modules.HitchARide.Api" });
            mapRouteManager.MapHttpRoute("Connect/HitchARide", "HitchARideMap2", "{controller}/{action}/{id}", null, new { id = "-?\\d+" }, new[] { "Connect.DNN.Modules.HitchARide.Api" });
        }
    }
}