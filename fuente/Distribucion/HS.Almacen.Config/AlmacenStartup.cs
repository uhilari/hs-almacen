using Castle.MicroKernel.Registration;
using HS.Almacen.WebApi;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace HS.Almacen.Config
{
  public class AlmacenStartup
  {
    public void Configuration(IAppBuilder app)
    {
      app.UseHs((k, h) =>
      {
        k.Register(Component.For<IExceptionLogger>().ImplementedBy<ExceptionLoggerConsole>());
        k.AlmacenStack();
        h.RouteAlmacen();
      });
    }
  }
}
