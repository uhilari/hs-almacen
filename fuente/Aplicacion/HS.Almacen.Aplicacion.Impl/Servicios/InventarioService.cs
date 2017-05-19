using System;
using HS.Almacen.Aplicacion.Mapper;

namespace HS.Almacen.Aplicacion.Servicios
{
  public class InventarioService : IInventarioService
  {
    private IGenericRepository _repositorio;

    public InventarioService(IGenericRepository repositorio)
    {
      _repositorio = repositorio;
    }

    public void Registrar(string idAlmacen, IngresoAlmacen ingresoAlmacen)
    {
      var almacen = _repositorio.Get<Dominio.Entidades.Almacen>(idAlmacen.Guid());
      almacen.AgregarIngreso(_repositorio.CrearMovimiento(ingresoAlmacen));
    }
  }
}
