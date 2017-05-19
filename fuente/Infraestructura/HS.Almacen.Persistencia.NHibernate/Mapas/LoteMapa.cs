using HS.Almacen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Persistencia.NHibernate.Mapas
{
  public class LoteMapa: MapaEntidad<Lote>
  {
    public LoteMapa()
    {
      Property(c => c.Cantidad);
      Property(c => c.Numero);
      ManyToOne(c => c.Documento, m => m.Column("IdDocumento"));
      ManyToOne(c => c.Inventario, m => m.Column("IdInventario"));
      Property(c => c.Fecha);
      Property(c => c.Precio);
      Property(c => c.Saldo);
    }
  }
}
