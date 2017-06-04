using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Dominio.Servicios
{
  public interface IGestorStock
  {
    IEnumerable<Stock> ListaStockDeAlmacen(Guid idAlmacen);
    Stock StockActual(Entidades.Almacen almacen, Entidades.Articulo articulo, Entidades.UnidadMedida unidad);
    IEnumerable<Stock> ListaStockDeArticulo(Guid idAlmacen);
  }
}
