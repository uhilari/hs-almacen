using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Sdk
{
  class AlmacenService: IAlmacenService
  {
    private string _url;

    public AlmacenService(string urlBase, string id)
    {
      _url = $"{urlBase}/almacen";
      if (!string.IsNullOrEmpty(id))
        _url += $"/{id}";
    }

    public void RegistrarIngreso(IngresoAlmacen ingreso)
    {
      var client = new HttpClient();
      client.BaseAddress = new Uri(_url);
      var task = client.PostAsJsonAsync("ingreso", ingreso);
      task.Wait();
    }
  }
}
