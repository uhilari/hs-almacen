using HS.Almacen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen.Dominio.Mocks
{
  public class Fabrica
  {
    internal static Movimiento CrearIngreso()
    {
      var ingreso = new Movimiento
      {
        Fecha = DateTime.Today,
        Numero = 145,
        Tipo = TipoMovimiento.Ingreso,
        Documento = new Documento
        {
          Fecha = DateTime.Today.AddDays(-3),
          Tipo = new TipoDocumento { Codigo = "FA", Descripcion = "Factura" },
          Serie = 1,
          Numero = 213
        }
      };

      ingreso.Lineas = new Lista<LineaMovimiento>
        {
          new LineaMovimiento{
            Articulo = new Articulo{ Codigo = "00000001", Descripcion = "Articulo 1" },
            Unidad = new UnidadMedida{ Codigo = "UN", Nombre = "Unidad" },
            Cantidad = 1300,
            Precio = 9.14m,
            Movimiento = ingreso
          },
          new LineaMovimiento{
            Articulo = new Articulo{ Codigo = "00000002", Descripcion = "Articulo 2" },
            Unidad = new UnidadMedida{ Codigo = "UN", Nombre = "Unidad" },
            Cantidad = 800,
            Precio = 24.12m,
            Movimiento = ingreso
          },
          new LineaMovimiento{
            Articulo = new Articulo{ Codigo = "00000003", Descripcion = "Articulo 3" },
            Unidad = new UnidadMedida{ Codigo = "UN", Nombre = "Unidad" },
            Cantidad = 2600,
            Precio = 4.27m,
            Movimiento = ingreso
          },
          new LineaMovimiento{
            Articulo = new Articulo{ Codigo = "00000004", Descripcion = "Articulo 4" },
            Unidad = new UnidadMedida{ Codigo = "UN", Nombre = "Unidad" },
            Cantidad = 300,
            Precio = 48.56m,
            Movimiento = ingreso
          }
        };

      return ingreso;
    }

    internal static Movimiento CrearSalida()
    {
      return new Movimiento
      {
        Fecha = DateTime.Today,
        Numero = 445,
        Tipo = TipoMovimiento.Salida,
        Documento = new Documento
        {
          Fecha = DateTime.Today.AddDays(-3),
          Tipo = new TipoDocumento { Codigo = "FA", Descripcion = "Factura" },
          Serie = 1,
          Numero = 213
        },
        Lineas = new Lista<LineaMovimiento>
        {
          new LineaMovimiento{
            Articulo = new Articulo{ Codigo = "00000002", Descripcion = "Articulo 2" },
            Unidad = new UnidadMedida{ Codigo = "UN", Nombre = "Unidad" },
            Cantidad = 400,
            Precio = 24.12m
          },
          new LineaMovimiento{
            Articulo = new Articulo{ Codigo = "00000003", Descripcion = "Articulo 3" },
            Unidad = new UnidadMedida{ Codigo = "UN", Nombre = "Unidad" },
            Cantidad = 2100,
            Precio = 4.27m
          }
        }
      };
    }

    internal static Inventario CrearExistencia(Entidades.Almacen almacen)
    {
      var existencia = new Inventario(new Articulo(), new UnidadMedida());
      return existencia;
    }
  }
}
