using HS.Comun.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Persistencia.NHibernate.Mapas
{
  public class InstanciaSecuenciaMapa: MapaEntidad<InstanciaSecuencia>
  {
    public InstanciaSecuenciaMapa()
    {
      Property(c => c.Llave);
      Property(c => c.Valor);
      ManyToOne(c => c.Definicion, m => m.Column("IdDefinicion"));
    }
  }
}
