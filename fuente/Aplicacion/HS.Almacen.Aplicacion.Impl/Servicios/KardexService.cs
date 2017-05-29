using HS.Almacen.Dominio.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Aplicacion.Servicios
{
  public class KardexService : IKardexService
  {
    private IConsultaFactory _factory;

    public KardexService(IConsultaFactory factory)
    {
      _factory = factory;
    }

    public IEnumerable<Kardex> Lista(string idAlmacen, int año, int mes)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Stock> StockActual(string idAlmacen)
    {
      var consulta = _factory.CrearConsulta<IStockActual>();
      consulta.IdAlmacen = idAlmacen.Guid();
      return consulta.Ejecutar();
    }

    public Kardex Uno(string idInventario, int año, int mes)
    {
      var consulta = _factory.CrearConsulta<IKardexMensual>();
      consulta.Año = año;
      consulta.Mes = mes;
      consulta.IdInventario = idInventario.Guid();
      return consulta.Ejecutar();
    }

    public Kardex Uno(string idAlmacen, string idArticulo, int año, int mes)
    {
      var consulta = _factory.CrearConsulta<IKardexMensual>();
      consulta.Año = año;
      consulta.Mes = mes;
      consulta.IdAlmacen = idAlmacen.Guid();
      consulta.IdArticulo = idArticulo.Guid();
      return consulta.Ejecutar();
    }
  }
}
