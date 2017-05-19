using HS.Almacen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Persistencia.NHibernate.Mapas
{
  public class MovimientoMapa: MapaEntidad<Movimiento>
  {
    public MovimientoMapa()
    {
      ManyToOne(c => c.Documento, m => m.Column("IdDocumento"));
      Property(c => c.Fecha);
      Lista(c => c.Lineas, "IdMovimiento");
      Property(c => c.Numero);
      Property(c => c.Tipo);
    }
  }
}
