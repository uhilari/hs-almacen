using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace HS.Almacen.Sdk
{
  public class AlmacenClient: IDisposable
  {
    private string _urlBase;

    public AlmacenClient()
    {
      _urlBase = ConfigurationManager.AppSettings["UrlApiAlmacen"];
    }

    public IAlmacenService Almacen(string id = null)
    {
      return new AlmacenService(_urlBase, id);
    }

    public void Dispose()
    {
    }
  }
}
