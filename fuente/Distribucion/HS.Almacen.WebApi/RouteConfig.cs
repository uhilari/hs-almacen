using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HS.Almacen.WebApi
{
  public static class RouteConfig
  {
    public static void RouteAlmacen(this HttpConfiguration cfg)
    {
      cfg.MapHttpAttributeRoutes(new HsDirectRouteProvider());
    }
  }
}
