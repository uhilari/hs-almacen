using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Aplicacion.Servicios
{
  public interface IKardexService
  {
    IEnumerable<Stock> StockActual(string idAlmacen);
    IEnumerable<Kardex> Lista(string idAlmacen, int año, int mes);
    Kardex Uno(string idInventario, int año, int mes);
    Kardex Uno(string idAlmacen, string idArticulo, int año, int mes);
  }
}
