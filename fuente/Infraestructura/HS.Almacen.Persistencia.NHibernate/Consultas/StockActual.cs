using HS.Almacen.Dominio.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Transform;

namespace HS.Almacen.Persistencia.NHibernate.Consultas
{
  public class StockActual : ConsultaHqlLista<Stock>, IStockActual
  {
    public StockActual(ISessionFactory factory) : base(factory)
    {
      ResultTransformer = new DtoTransform<Stock>();
    }

    public Guid IdAlmacen { get; set; }

    protected override string GetCadenaConsulta()
    {
      return @"
Select i.Id as Id, i.Articulo.Codigo as CodArticulo, i.Articulo.Descripcion as Articulo, i.Unidad.Codigo as UnidadMedida,
    sum(l.Saldo) as Cantidad, (sum(l.Saldo * l.Precio) / sum(l.Saldo)) as PrecioPromedio, sum(l.Saldo * l.Precio) as Valorizacion
  From Inventario as i
    join i.Lotes as l
  Where i.Almacen.Id = :idAlmacen
  Group By i.Id, i.Articulo.Codigo, i.Articulo.Descripcion, i.Unidad.Codigo
      ";
    }

    protected override void SetParametros(IQuery query)
    {
      query.SetGuid("idAlmacen", IdAlmacen);
    }
  }
}
