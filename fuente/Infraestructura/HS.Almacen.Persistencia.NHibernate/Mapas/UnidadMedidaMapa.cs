using HS.Comun.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Persistencia.NHibernate.Mapas
{
  public class UnidadMedidaMapa: MapaEntidad<UnidadMedida>
  {
    public UnidadMedidaMapa()
    {
      Property(c => c.Codigo);
      Property(c => c.Nombre);
    }
  }
}
