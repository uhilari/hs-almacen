using HS.Comun.Dominio.Servicios;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HS.Almacen.Dominio.Servicios
{
  public class InventarioFactoryTest
  {
    private IInventarioFactory _factory = null;

    public InventarioFactoryTest()
    {
      //_factory = new InventarioFactory();
    }

    public class CrearExistencia: InventarioFactoryTest
    {
      public CrearExistencia()
      {
      }

      [Fact]
      public void LineaNoNull()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          _factory.CrearInventario(null);
        });
      }

      [Fact]
      public void NoNull()
      {
        var ingreso = Mocks.Fabrica.CrearIngreso();

        var existencia = _factory.CrearInventario(ingreso.Lineas[0]);
        Assert.NotNull(existencia);
      }

      [Fact]
      public void CodigoNoNull()
      {
        var ingreso = Mocks.Fabrica.CrearIngreso();

        var existencia = _factory.CrearInventario(ingreso.Lineas[0]);

        Assert.Equal("5", existencia.Codigo);
      }
    }

    public class CrearLote: InventarioFactoryTest
    {
      public CrearLote()
      {
      }

      [Fact]
      public void LineaNoNull()
      {
        Assert.Throws<ArgumentNullException>(() =>
        {
          _factory.CrearLote(null);
        });
      }

      [Fact]
      public void NoNull()
      {
        var ingreso = Mocks.Fabrica.CrearIngreso();

        var lote = _factory.CrearLote(ingreso.Lineas[0]);

        Assert.NotNull(lote);
      }

      [Fact]
      public void ConDatos()
      {
        var ingreso = Mocks.Fabrica.CrearIngreso();

        var lote = _factory.CrearLote(ingreso.Lineas[0]);

        Assert.Equal(1300, lote.Cantidad);
        Assert.Equal(9.14m, lote.Precio);
        Assert.Equal(1300, lote.Saldo);
      }

      [Fact]
      public void CodigoNoNull()
      {
        var ingreso = Mocks.Fabrica.CrearIngreso();

        var lote = _factory.CrearLote(ingreso.Lineas[0]);

        Assert.Equal(15, lote.Numero);
      }
    }
  }
}
