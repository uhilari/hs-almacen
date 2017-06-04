using HS.Almacen.Dominio.Entidades;
using HS.Almacen.Dominio.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Aplicacion.Servicios
{
  public class KardexService : IKardexService
  {
    private IGestorStock _gestorStock;
    private IGenericRepository _repository;

    public KardexService(IGestorStock gestorStock, IGenericRepository repository)
    {
      _gestorStock = gestorStock.NoEsNull(nameof(gestorStock));
      _repository = repository;
    }

    public IEnumerable<Stock> StockDeAlmacen(string idAlmacen)
    {
      return _gestorStock.ListaStockDeAlmacen(idAlmacen.Guid());
    }

    public Stock StockActual(string idAlmacen, string idArticulo, string idUnidadMedida)
    {
      return _gestorStock.StockActual(_repository.Get<Dominio.Entidades.Almacen>(idAlmacen.NoEsNull(nameof(idAlmacen)).Guid()),
        _repository.Get<Articulo>(idArticulo.NoEsNull(nameof(idArticulo)).Guid()),
        _repository.Get<UnidadMedida>(idUnidadMedida.GuidONull()));
    }

    public IEnumerable<Stock> StockDeArticulo(string idArticulo)
    {
      return _gestorStock.ListaStockDeArticulo(idArticulo.Guid());
    }
  }
}
