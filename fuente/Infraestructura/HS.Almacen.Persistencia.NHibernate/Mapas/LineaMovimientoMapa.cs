using HS.Almacen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Persistencia.NHibernate.Mapas
{
  public class LineaMovimientoMapa: MapaEntidad<LineaMovimiento>
  {
    public LineaMovimientoMapa()
    {
      ManyToOne(c => c.Articulo, m => m.Column("IdArticulo"));
      Property(c => c.Cantidad);
      ManyToOne(c => c.Movimiento, m => m.Column("IdMovimiento"));
      Property(c => c.Precio);
      ManyToOne(c => c.Unidad, m => m.Column("IdUnidadMedida"));
    }
  }
}
