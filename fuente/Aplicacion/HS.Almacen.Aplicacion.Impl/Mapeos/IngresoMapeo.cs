using HS.Almacen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HS.Almacen.Aplicacion.Mapeos
{
  public static class IngresoMapeo
  {
    public static Movimiento CrearMovimiento(this IGenericRepository repositorio, IngresoAlmacen ingresoAlmacen)
    {
      var movimiento = new Movimiento
      {
        Documento = new Documento
        {
          Fecha = ingresoAlmacen.Fecha,
          Numero = ingresoAlmacen.Numero,
          Serie = ingresoAlmacen.Serie,
          Tipo = repositorio.Get<TipoDocumento>(ingresoAlmacen.TipoDocumento.Guid())
        },
        Fecha = DateTime.Today,
        Tipo = TipoMovimiento.Ingreso
      };
      movimiento.Lineas = ingresoAlmacen.Lineas.Select(c => CrearLineaMovimiento(repositorio, movimiento, c)).ToLista();
      return movimiento;
    }

    private static LineaMovimiento CrearLineaMovimiento(IGenericRepository repositorio, Movimiento movimiento, LineaIngresoAlmacen lineaIngreso)
    {
      return new LineaMovimiento
      {
        Articulo = repositorio.Get<Articulo>(lineaIngreso.Articulo.Guid()),
        Cantidad = lineaIngreso.Cantidad,
        Movimiento = movimiento,
        Precio = lineaIngreso.Precio,
        Unidad = repositorio.Get<UnidadMedida>(lineaIngreso.UnidadMedida.Guid())
      };
    }
  }
}
