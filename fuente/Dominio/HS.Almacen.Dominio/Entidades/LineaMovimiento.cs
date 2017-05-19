using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen.Dominio.Entidades
{
  public class LineaMovimiento : EntityBase
  {
    public virtual Movimiento Movimiento { get; set; }
    public virtual Articulo Articulo { get; set; }
    public virtual decimal Cantidad { get; set; }
    public virtual decimal Precio { get; set; }
    public virtual UnidadMedida Unidad { get; set; }
  }
}
