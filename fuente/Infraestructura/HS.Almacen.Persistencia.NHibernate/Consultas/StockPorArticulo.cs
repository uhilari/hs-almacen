using HS.Almacen.Dominio.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace HS.Almacen.Persistencia.NHibernate.Consultas
{
  public class StockPorArticulo : ConsultaHqlLista<Stock>, IStockPorArticulo
  {
    public StockPorArticulo(ISessionFactory factory) : base(factory)
    {
      ResultTransformer = new DtoTransform<Stock>();
    }

    public Guid IdArticulo { get; set; }

    protected override string GetCadenaConsulta()
    {
      return @"
  Select i.Id as Id, i.Almacen.Codigo as Almacen, i.Articulo.Codigo as CodArticulo, i.Articulo.Descripcion as Articulo, 
    i.Unidad.Codigo as UnidadMedida, sum(l.Saldo) as Cantidad, (sum(l.Saldo * l.Precio) / sum(l.Saldo)) as PrecioPromedio, 
    sum(l.Saldo * l.Precio) as Valorizacion
  From Inventario as i
    join i.Lotes as l
  Where i.Articulo.Id = :idArticulo
  Group By i.Id, i.Almacen.Codigo, i.Articulo.Codigo, i.Articulo.Descripcion, i.Unidad.Codigo
      ";
    }

    protected override void SetParametros(IQuery query)
    {
      query.SetGuid("idArticulo", IdArticulo);
    }
  }
}
