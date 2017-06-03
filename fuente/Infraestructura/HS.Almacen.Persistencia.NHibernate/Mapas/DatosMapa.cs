using HS.Almacen.Dominio.Entidades;
using HS.Comun.Dominio.Entidades;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Persistencia.NHibernate.Mapas
{
  public class DatosMapa: MapaEntidad<Datos>
  {
    public DatosMapa()
    {
      Property(c => c.Codigo);
      Property(c => c.Descripcion);
      Discriminator(m => m.Column("TipoDato"));
    }
  }

  public class TipoDocumentoMapa: SubclassMapping<TipoDocumento>
  {
    public TipoDocumentoMapa()
    {
      DiscriminatorValue("TIPO-DOCUMENTO");
    }
  }
}
