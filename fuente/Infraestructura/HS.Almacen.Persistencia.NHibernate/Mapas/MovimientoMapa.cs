using HS.Almacen.Dominio.Entidades;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;
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
      Discriminator(m =>
      {
        m.Column("Tipo");
        m.Type<EnumStringType<TipoMovimiento>>();
      });
      DiscriminatorValue(TipoMovimiento.Ingreso);
      ManyToOne(c => c.Documento, m => {
        m.Column("IdDocumento");
        m.Cascade(Cascade.All);
      });
      Property(c => c.Fecha);
      Lista(c => c.Lineas, "IdMovimiento");
      Property(c => c.Numero);
      Enumerado(c => c.Estado);
      ManyToOne(c => c.Almacen, m => m.Column("IdAlmacen"));
    }
  }

  public class IngresoMapa : SubclassMapping<Ingreso>
  {
    public IngresoMapa()
    {
      DiscriminatorValue(TipoMovimiento.Ingreso);
    }
  }

  public class SalidaMapa: SubclassMapping<Salida>
  {
    public SalidaMapa()
    {
      DiscriminatorValue(TipoMovimiento.Salida);
    }
  }
}
