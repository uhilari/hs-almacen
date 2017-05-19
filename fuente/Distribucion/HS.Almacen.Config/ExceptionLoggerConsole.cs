using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace HS.Almacen.Config
{
  class ExceptionLoggerConsole: ExceptionLogger, IExceptionLogger
  {
    public override void Log(ExceptionLoggerContext context)
    {
      Console.WriteLine(context.Exception.Message);
      Console.WriteLine(context.Exception.StackTrace);
      Console.WriteLine();
    }

    public override Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
    {
      return Task.Run(() => {
        Console.WriteLine(context.Exception.Message);
        Console.WriteLine(context.Exception.StackTrace);
        Console.WriteLine();
      });
    }
  }
}
