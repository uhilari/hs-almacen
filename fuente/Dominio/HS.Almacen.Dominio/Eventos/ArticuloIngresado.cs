using HS.Almacen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen.Dominio.Eventos
{
  public class ArticuloIngresado : IDomainEvent
  {
    public ArticuloIngresado(Entidades.Almacen almacen, LineaMovimiento linea)
    {
      LineaIngreso = linea.NoEsNull(nameof(linea));
      Almacen = almacen.NoEsNull(nameof(almacen));
    }

    public Entidades.Almacen Almacen { get; }
    public LineaMovimiento LineaIngreso { get; }
  }
}
