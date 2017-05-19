using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HS.Almacen.Dominio.ManejadoresEventos
{
  public class CrearLotePorIngresoTest
  {
    private Mock<Servicios.IInventarioFactory> _factory;
    private Mocks.AlmacenMock _almacen;
    private Eventos.ArticuloIngresado _evento;
    private CrearLotePorIngreso _manejador;

    public CrearLotePorIngresoTest()
    {
      _factory = new Mock<Servicios.IInventarioFactory>();
      var ingreso = Mocks.Fabrica.CrearIngreso();
      _almacen = new Mocks.AlmacenMock();
      _evento = new Eventos.ArticuloIngresado(_almacen, ingreso.Lineas[0]);
      _manejador = new CrearLotePorIngreso(_factory.Object);
    }

    [Fact]
    public void Creado()
    {
      Assert.NotNull(_manejador);
    }

    [Fact]
    public void Ejecutar_AgregarLote()
    {
      var existencia = Mocks.Fabrica.CrearExistencia(_evento.Almacen);
      ((Mocks.AlmacenMock)_evento.Almacen).SetExistenciaReturn(existencia);
      var lote = new Entidades.Lote(new Entidades.Documento());
      _factory.Setup(c => c.CrearLote(_evento.LineaIngreso))
        .Returns(lote);

      _manejador.Ejecutar(_evento);

      Assert.NotEmpty(existencia.Lotes);
    }

    [Fact]
    public void Ejecutar_AgregarExistencia()
    {
      var existencia = Mocks.Fabrica.CrearExistencia(_evento.Almacen);
      ((Mocks.AlmacenMock)_evento.Almacen).SetExistenciaReturn(null);
      _factory.Setup(c => c.CrearInventario(_evento.LineaIngreso))
        .Returns(existencia);
      var lote = new Entidades.Lote(new Entidades.Documento());
      _factory.Setup(c => c.CrearLote(_evento.LineaIngreso))
        .Returns(lote);

      _manejador.Ejecutar(_evento);

      ((Mocks.AlmacenMock)_evento.Almacen).ValidaSiExistenciaNoEsVacio();
      Assert.NotEmpty(existencia.Lotes);
    }

    [Fact]
    public void Ejecutar_NotNull()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        _manejador.Ejecutar(null);
      });
    }
  }
}
