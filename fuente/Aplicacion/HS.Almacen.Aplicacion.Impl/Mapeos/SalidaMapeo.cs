using HS.Almacen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Aplicacion.Mapeos
{
  public static class SalidaMapeo
  {
    public static Movimiento CrearMovimiento(this IGenericRepository repositorio, SalidaAlmacen salidaAlmacen)
    {
      var movimiento = new Movimiento
      {
        Documento = new Documento
        {
          Fecha = salidaAlmacen.Fecha,
          Numero = salidaAlmacen.Numero,
          Serie = salidaAlmacen.Serie,
          Tipo = repositorio.Get<TipoDocumento>(salidaAlmacen.TipoDocumento.Guid())
        },
        Fecha = DateTime.Today,
        Tipo = TipoMovimiento.Salida
      };
      movimiento.Lineas = salidaAlmacen.Lineas.Select(c => CrearLineaMovimiento(repositorio, movimiento, c)).ToLista();
      return movimiento;
    }

    private static LineaMovimiento CrearLineaMovimiento(IGenericRepository repositorio, Movimiento movimiento, LineaSalidaAlmacen lineaSalida)
    {
      return new LineaMovimiento
      {
        Articulo = repositorio.Get<Articulo>(lineaSalida.Articulo.Guid()),
        Cantidad = lineaSalida.Cantidad,
        Movimiento = movimiento,
        Unidad = repositorio.Get<UnidadMedida>(lineaSalida.UnidadMedida.Guid())
      };
    }
  }
}
