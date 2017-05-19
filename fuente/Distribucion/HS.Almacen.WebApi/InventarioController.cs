using HS.Almacen.Aplicacion.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HS.Almacen.WebApi
{
  [RoutePrefix("inventario")]
  public class InventarioController: BaseController
  {
    public IInventarioService _inventarioService;

    public InventarioController(IInventarioService inventarioService)
    {
      _inventarioService = inventarioService;
    }

    [Route("{idAlmacen}/ingreso"), HttpPost]
    public void RegistrarIngreso(string idAlmacen, [FromBody] IngresoAlmacen ingreso)
    {
      _inventarioService.Registrar(idAlmacen, ingreso);
    }
  }
}
