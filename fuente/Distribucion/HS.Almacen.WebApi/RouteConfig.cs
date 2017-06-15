using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace HS.Almacen.WebApi
{
  public static class RouteConfig
  {
    public static void RouteAlmacen(this HttpConfiguration cfg)
    {
      cfg.Services.Replace(typeof(IExceptionHandler), new CustomErrorHandler());
      cfg.MapHttpAttributeRoutes(new HsDirectRouteProvider());
    }
  }
}
