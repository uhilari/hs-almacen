using HS.Almacen.Aplicacion.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HS.Almacen.WebApi
{
  [RoutePrefix("kardex")]
  public class KardexController: ApiController
  {
    private IKardexService _servicio;

    public KardexController(IKardexService servicio)
    {
      _servicio = servicio;
    }

    [Route("sa/{idAlmacen}"), HttpGet]
    public IEnumerable<Stock> StockActual(string idAlmacen)
    {
      return _servicio.StockActual(idAlmacen);
    }

    [Route("lt/{idAlmacen}/{año}/{mes}/"), HttpGet]
    public IEnumerable<Kardex> Lista(string idAlmacen, int año, int mes)
    {
      return _servicio.Lista(idAlmacen, año, mes);
    }

    [Route("un/{idInventario}/{año}/{mes}"), HttpGet]
    public Kardex Ver(string idInventario, int año, int mes)
    {
      return _servicio.Uno(idInventario, año, mes);
    }

    [Route("un/{idAlmacen}/{idArticulo}/{año}/{mes}"), HttpGet]
    public Kardex Ver(string idAlmacen, string idArticulo, int año, int mes)
    {
      return _servicio.Uno(idAlmacen, idArticulo, año, mes);
    }
  }
}
