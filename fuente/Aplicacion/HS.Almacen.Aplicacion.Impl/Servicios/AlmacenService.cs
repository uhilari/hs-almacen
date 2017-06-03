using HS.Almacen.Aplicacion.Mapeos;
using HS.Almacen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Aplicacion.Servicios
{
  public class AlmacenService : CrudService<AlmacenDto, Dominio.Entidades.Almacen>, IAlmacenService
  {
    public AlmacenService(IRepository<Dominio.Entidades.Almacen> repository, IMapperFactory mapperFactory) 
      : base(repository, mapperFactory)
    {
    }

    public void RegistrarIngreso(string idAlmacen, IngresoAlmacen ingresoAlmacen)
    {
      var mapper = MapperFactory.GetMapper<IngresoAlmacen, Movimiento>();
      var almacen = Repository.BuscarUno(idAlmacen.Guid());
      almacen.AgregarIngreso(mapper.CrearEntity(ingresoAlmacen));
    }

    public void RegistrarSalida(string idAlmacen, SalidaAlmacen salidaAlmacen)
    {
      //var almacen = Repository.BuscarUno(idAlmacen.Guid());
      //almacen.AgregarSalida(_genericRepository.CrearMovimiento(salidaAlmacen));
    }
  }
}
