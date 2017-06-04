using HS.Almacen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Aplicacion.Mapeos
{
  public class StockMapeo : Mapper<Stock, Inventario>, IMapper<Stock, Inventario>
  {
    public StockMapeo(IGenericRepository repository) : base(repository)
    {
      DestinoDto(c => c.Id).Funcion(c => c.Id.Cadena());
      DestinoDto(c => c.Articulo).Funcion(c => c.Articulo.Descripcion);
      DestinoDto(c => c.Cantidad).Funcion(c => c.Lotes.Sum(l => l.Saldo));
      DestinoDto(c => c.CodArticulo).Funcion(c => c.Articulo.Codigo);
      DestinoDto(c => c.PrecioPromedio).Funcion(c => c.Lotes.Sum(l => l.Saldo * l.Precio) / c.Lotes.Sum(l => l.Saldo));
      DestinoDto(c => c.UnidadMedida).Funcion(c => c.Unidad.Codigo);
      DestinoDto(c => c.Valorizacion).Funcion(c => c.Lotes.Sum(l => l.Saldo * l.Precio));
    }
  }
}
