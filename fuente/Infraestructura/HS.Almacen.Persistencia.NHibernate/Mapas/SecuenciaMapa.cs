using HS.Comun.Dominio.Entidades;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Persistencia.NHibernate.Mapas
{
  public class SecuenciaMapa: MapaEntidad<Secuencia>
  {
    public SecuenciaMapa()
    {
      Property(c => c.Llave);
      Property(c => c.Longitud);
      Property(c => c.Prefijo);
      Discriminator(a => a.Column("TipoSeq"));
      Lista(c => c.Instancias, "IdDefinicion");
    }
  }

  public class SecuenciaUnicaMapa : SubclassMapping<SecuenciaUnica>
  {
    public SecuenciaUnicaMapa()
    {
      DiscriminatorValue("UNICA");
    }
  }

  public class SecuenciaAnualMapa: SubclassMapping<SecuenciaAnual>
  {
    public SecuenciaAnualMapa()
    {
      DiscriminatorValue("ANUAL");
    }
  }

  public class SecuenciaMensualMapa : SubclassMapping<SecuenciaMensual>
  {
    public SecuenciaMensualMapa()
    {
      DiscriminatorValue("MENSUAL");
    }
  }

  public class SecuenciaDiariaMapa : SubclassMapping<SecuenciaDiaria>
  {
    public SecuenciaDiariaMapa()
    {
      DiscriminatorValue("DIARIO");
    }
  }
}
