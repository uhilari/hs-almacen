using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HS.Almacen.Dominio.Entidades
{
  public class InventarioTest
  {
    private Mock<Almacen> _almacen;
    private Mock<Articulo> _articulo;
    private Mock<UnidadMedida> _unidadMedida;

    public InventarioTest()
    {
      _almacen = new Mock<Almacen>();
      _articulo = new Mock<Articulo>();
      _unidadMedida = new Mock<UnidadMedida>();
    }

    [Fact]
    public void Constructor_Correcto()
    {
      var existencia = new Inventario(_articulo.Object, _unidadMedida.Object);

      Assert.NotNull(existencia);
    }

    [Fact]
    public void Constructor_ArticuloNull()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        new Inventario(null, _unidadMedida.Object);
      });
    }

    [Fact]
    public void Constructor_UnidadMedidaNull()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        new Inventario(_articulo.Object, null);
      });
    }

    [Fact]
    public void AgregarLote_Correcto()
    {
      var existencia = new Inventario(_articulo.Object, _unidadMedida.Object);
      var linea = new Lote(new Entidades.Documento());
      
      existencia.AgregarLote(linea);
    }

    [Fact]
    public void AgregarLote_LineaMovimientoNull()
    {
      var existencia = new Inventario(_articulo.Object, _unidadMedida.Object);

      Assert.Throws<ArgumentNullException>(() =>
      {
        existencia.AgregarLote(null);
      });
    }
  }
}
