using HS.Almacen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Persistencia.NHibernate.Mapas
{
  public class AlmacenMapa: MapaEntidad<Dominio.Entidades.Almacen>
  {
    public AlmacenMapa()
    {
      Property(c => c.Codigo);
      Property(c => c.Nombre);
      Lista(c => c.Movimientos, "IdAlmacen");
      Lista(c => c.Inventarios, "IdAlmacen");
    }
  }
}
