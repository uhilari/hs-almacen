using HS.Almacen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Persistencia.NHibernate.Mapas
{
  public class DocumentoMapa: MapaEntidad<Documento>
  {
    public DocumentoMapa()
    {
      Property(c => c.Fecha);
      Property(c => c.Numero);
      Property(c => c.Serie);
      ManyToOne(c => c.Tipo, m => m.Column("IdTipoDocumento"));
    }
  }
}
