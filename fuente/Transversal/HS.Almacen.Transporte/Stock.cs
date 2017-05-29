using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen
{
  public class Stock
  {
    public string Id { get; set; }
    public string CodArticulo { get; set; }
    public string Articulo { get; set; }
    public string UnidadMedida { get; set; }
    public decimal Cantidad { get; set; }
    public decimal PrecioPromedio { get; set; }
    public decimal Valorizacion { get; set; }
  }
}
