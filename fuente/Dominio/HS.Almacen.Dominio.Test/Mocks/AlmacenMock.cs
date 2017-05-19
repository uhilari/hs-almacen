using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HS.Almacen.Dominio.Mocks
{
  public class AlmacenMock: Entidades.Almacen
  {
    private ILista<Entidades.Inventario> _internalExistencias;

    public AlmacenMock()
    {
      _internalExistencias = base.Inventarios;
      MockExistencias = new Mock<ILista<Entidades.Inventario>>();
      MockExistencias.Setup(c => c.Add(It.IsAny<Entidades.Inventario>()))
        .Callback<Entidades.Inventario>(e =>
        {
          _internalExistencias.Add(e);
        });
      base.Inventarios = MockExistencias.Object;
    }

    public Mock<ILista<Entidades.Inventario>> MockExistencias { get; }

    public void SetExistenciaReturn(Entidades.Inventario existencia)
    {
      MockExistencias.Setup(c => c.Buscar(It.IsAny<Expression<Func<Entidades.Inventario, bool>>>()))
        .Returns(existencia);
    }

    public void ValidaSiExistenciaNoEsVacio()
    {
      Assert.NotEmpty(_internalExistencias);
    }
  }
}
