using HS.Almacen.Dominio.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HS.Almacen.Dominio.Entidades
{
  public class Inventario: EntityBase
  {
    public const string KeySecuencia = "SEQ-INVENTARIO";

    protected Inventario() { }

    public Inventario(Articulo articulo, UnidadMedida unidad)
    {
      Maximo = 0;
      Minimo = 0;
      Articulo = articulo.NoEsNull(nameof(articulo));
      Unidad = unidad.NoEsNull(nameof(unidad));
      Lotes = new Lista<Lote>();
      Cierres = new Lista<CierreInventario>();
    }

    public virtual string Codigo { get; set; }
    public virtual decimal? Maximo { get; set; }
    public virtual decimal? Minimo { get; set; }
    public virtual Almacen Almacen { get; internal protected set; }
    public virtual Articulo Articulo { get; protected set; }
    public virtual UnidadMedida Unidad { get; protected set; }
    public virtual ILista<Lote> Lotes { get; protected set; }
    public virtual ILista<CierreInventario> Cierres { get; protected set; }

    public virtual void AgregarLote(Lote lote)
    {
      lote.NoEsNull(nameof(lote));
      lote.Inventario = this;
      Lotes.Add(lote);
    }

    public virtual decimal GetPrecioPromedio()
    {
      var lotesActivos = Lotes.Filtrar(c => c.Saldo > 0);
      var totalCantidad = lotesActivos.Sum(c => c.Saldo);
      var totalMonto = lotesActivos.Sum(c => c.Saldo * c.Precio);
      return totalMonto / totalCantidad;
    }
  }
}
