using HS.Almacen.Dominio.Entidades;
using HS.Comun.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Aplicacion.Mapeos
{
  public class SalidaMapeo: Mapper<SalidaAlmacen, Salida>, IMapper<SalidaAlmacen, Salida>
  {
    public SalidaMapeo(IGenericRepository repository, IMapperFactory mapperFactory) 
      : base(repository)
    {
      DestinoDto(c => c.Fecha).Funcion(c => c.Documento.Fecha);
      DestinoDto(c => c.Numero).Funcion(c => c.Documento.Numero);
      DestinoDto(c => c.Serie).Funcion(c => c.Documento.Serie);
      DestinoDto(c => c.TipoDocumento).Funcion(c => c.Documento.Tipo.Id.Cadena());

      DestinoEntity(c => c.Documento).Funcion(c => new Documento
      {
        Fecha = c.Fecha,
        Numero = c.Numero,
        Serie = c.Serie,
        Tipo = repository.Get<TipoDocumento>(c.TipoDocumento.Guid())
      });
      DestinoEntity(c => c.Fecha).Constante(DateTime.Today);
      DestinoEntity(c => c.Tipo).Constante(TipoMovimiento.Salida);
      DestinoEntityLista(c => c.Lineas).Funcion(c => c.Lineas).Mapper(mapperFactory.GetMapper<LineaSalidaAlmacen, LineaMovimiento>());
      AfterMakeEntity(m => m.Lineas.ForEach(l => l.Movimiento = m));
    }
  }
}
