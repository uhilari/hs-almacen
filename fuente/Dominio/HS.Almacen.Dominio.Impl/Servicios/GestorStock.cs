using HS.Almacen.Dominio.Consultas;
using HS.Almacen.Dominio.Entidades;
using HS.Comun.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Dominio.Servicios
{
  public class GestorStock : IGestorStock
  {
    private IConsultaFactory _factory;
    private IMapper<Stock, Inventario> _mapper;

    public GestorStock(IConsultaFactory factory, IMapper<Stock, Inventario> mapper)
    {
      _factory = factory;
      _mapper = mapper;
    }

    public IEnumerable<Stock> ListaStockDeAlmacen(Guid idAlmacen)
    {
      var consulta = _factory.CrearConsulta<IStockPorAlmacen>();
      consulta.IdAlmacen = idAlmacen;
      return consulta.Ejecutar();
    }

    public IEnumerable<Stock> ListaStockDeArticulo(Guid idArticulo)
    {
      var consulta = _factory.CrearConsulta<IStockPorArticulo>();
      consulta.IdArticulo = idArticulo;
      return consulta.Ejecutar();
    }

    public Stock StockActual(Entidades.Almacen almacen, Articulo articulo, UnidadMedida unidad)
    {
      var inventario = almacen.Inventarios.Buscar(c => c.Articulo == articulo);
      var stock = _mapper.CrearDto(inventario);
      if (unidad != null)
      {
        stock.Cantidad = unidad.Convertir(inventario.Unidad, stock.Cantidad);
        stock.UnidadMedida = unidad.Codigo;
      }
      stock.PrecioPromedio = stock.Valorizacion / stock.Cantidad;
      return stock;
    }
  }
}
