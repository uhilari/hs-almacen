using HS.Almacen.Aplicacion.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HS.Almacen.WebApi
{
  [RoutePrefix("stock")]
  public class StockController: ApiController
  {
    private IKardexService _servicio;

    public StockController(IKardexService servicio)
    {
      _servicio = servicio;
    }

    [Route("almacen/{idAlmacen}"), HttpGet]
    public IEnumerable<Stock> StockAlmacen(string idAlmacen)
    {
      return _servicio.StockDeAlmacen(idAlmacen);
    }

    [Route("almacen/{idAlmacen}/articulo/{idArticulo}"), HttpGet]
    public Stock StockActual(string idAlmacen, string idArticulo, string idUnidadMedida = null)
    {
      return _servicio.StockActual(idAlmacen, idArticulo, idUnidadMedida);
    }

    [Route("articulo/{idArticulo}"), HttpGet]
    public IEnumerable<Stock>  StockArticulo(string idArticulo)
    {
      return _servicio.StockDeArticulo(idArticulo);
    }
  }
}
