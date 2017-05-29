using System;
using System.Linq;
using HS.Almacen.Aplicacion.Mapeos;

namespace HS.Almacen.Aplicacion.Servicios
{
  public class InventarioService : IInventarioService
  {
    private IGenericRepository _repositorio;

    public InventarioService(IGenericRepository repositorio)
    {
      _repositorio = repositorio;
    }

    public void RegistrarIngreso(string idAlmacen, IngresoAlmacen ingresoAlmacen)
    {
      var almacen = _repositorio.Get<Dominio.Entidades.Almacen>(idAlmacen.Guid());
      almacen.AgregarIngreso(_repositorio.CrearMovimiento(ingresoAlmacen));
    }

    public void RegistrarSalida(string idAlmacen, SalidaAlmacen salidaAlmacen)
    {
      var almacen = _repositorio.Get<Dominio.Entidades.Almacen>(idAlmacen.Guid());
      almacen.AgregarSalida(_repositorio.CrearMovimiento(salidaAlmacen));
    }
  }
}
