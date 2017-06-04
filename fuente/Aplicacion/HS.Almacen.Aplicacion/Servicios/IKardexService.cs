using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Aplicacion.Servicios
{
  public interface IKardexService
  {
    IEnumerable<Stock> StockDeAlmacen(string idAlmacen);
    Stock StockActual(string idAlmacen, string idArticulo, string idUnidadMedida);
    IEnumerable<Stock> StockDeArticulo(string idArticulo);
  }
}
