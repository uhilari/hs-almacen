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

    public void EfectuarIngreso(string idAlmacen, string idIngreso, IList<LineaIngresoAlmacen> lineas)
    {
      var almacen = Repository.BuscarUno(idAlmacen.Guid());
      var ingreso = almacen.Movimientos.Buscar<Ingreso>(idIngreso.Guid());
      var mapper = MapperFactory.GetMapper<LineaIngresoAlmacen, LineaMovimiento>();
      ingreso.ActualizarLineas(mapper.CrearEntities(lineas));
    }

    private void _registrarMovimiento(string idAlmacen, Movimiento movimiento)
    {
      var almacen = Repository.BuscarUno(idAlmacen.Guid());
      almacen.Agregar(movimiento);
    }

    public void RegistrarIngreso(string idAlmacen, IngresoAlmacen ingresoAlmacen)
    {
      var mapper = MapperFactory.GetMapper<IngresoAlmacen, Ingreso>();
      _registrarMovimiento(idAlmacen, mapper.CrearEntity(ingresoAlmacen));
    }

    public void RegistrarSalida(string idAlmacen, SalidaAlmacen salidaAlmacen)
    {
      var mapper = MapperFactory.GetMapper<SalidaAlmacen, Salida>();
      _registrarMovimiento(idAlmacen, mapper.CrearEntity(salidaAlmacen));
    }
  }
}
