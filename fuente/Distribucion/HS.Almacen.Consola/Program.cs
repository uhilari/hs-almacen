using HS.Almacen.Config;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Consola
{
  class Program
  {
    static void Main(string[] args)
    {
      string url = "http://localhost:8050";
      using (WebApp.Start<AlmacenStartup>(url))
      {
        Console.WriteLine(string.Format("Se ha iniciado el servidor de Almacen en '{0}'", url));
        Console.WriteLine("Presione ENTER para terminar");
        Console.ReadLine();
      }
    }
  }
}
