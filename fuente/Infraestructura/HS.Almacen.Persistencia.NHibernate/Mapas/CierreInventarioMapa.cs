using HS.Almacen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Persistencia.NHibernate.Mapas
{
  public class CierreInventarioMapa: MapaEntidad<CierreInventario>
  {
    public CierreInventarioMapa()
    {
      Property(c => c.Fecha);
      ManyToOne(c => c.Inventario, m => m.Column("IdInventario"));
      Property(c => c.Saldo);
      Property(c => c.PrecioPromedio);
    }
  }
}
