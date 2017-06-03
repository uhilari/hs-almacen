using HS.Almacen.Aplicacion.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HS.Almacen.WebApi
{
  [RoutePrefix("almacen")]
  public class AlmacenController : CrudController<AlmacenDto>
  {
    private IAlmacenService _service;

    public AlmacenController(IAlmacenService service) : base(service)
    {
      _service = service;
    }

    [Route("{idAlmacen}/ingreso"), HttpPost]
    public void RegistrarIngreso(string idAlmacen, [FromBody] IngresoAlmacen ingreso)
    {
      _service.RegistrarIngreso(idAlmacen, ingreso);
    }

    [Route("{idAlmacen}/salida"), HttpPost]
    public void RegistrarSalida(string idAlmacen, [FromBody] SalidaAlmacen salida)
    {
      _service.RegistrarSalida(idAlmacen, salida);
    }
  }
}
