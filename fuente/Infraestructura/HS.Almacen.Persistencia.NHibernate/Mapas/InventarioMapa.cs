using HS.Almacen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Persistencia.NHibernate.Mapas
{
  public class InventarioMapa: MapaEntidad<Inventario>
  {
    public InventarioMapa()
    {
      ManyToOne(c => c.Articulo, m => m.Column("IdArticulo"));
      Property(c => c.Codigo);
      Lista(c => c.Lotes, "IdInventario");
      Property(c => c.Maximo);
      Property(c => c.Minimo);
      ManyToOne(c => c.Almacen, m => m.Column("IdAlmacen"));
      ManyToOne(c => c.Unidad, m => m.Column("IdUnidadMedida"));
      Lista(c => c.Cierres, "IdInventario");
    }
  }
}
