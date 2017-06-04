using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen.Dominio.Entidades
{
  public class UnidadMedida : EntityBase
  {
    public virtual string Codigo { get; set; }
    public virtual string Nombre { get; set; }
    public virtual decimal Cantidad { get; set; }

    public virtual decimal Convertir(UnidadMedida origen, decimal cantidad)
    {
      return (cantidad * origen.Cantidad) / this.Cantidad;
    }
  }
}
