using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen
{
  public class Kardex
  {
    public string Id { get; set; }
    public int Mes { get; set; }
    public int Año { get; set; }
    public string Articulo { get; set; }
    public string UnidadMedida { get; set; }
    public decimal StockActual { get; set; }
    public decimal PrecioPromedio { get; set; }
    public IList<LineaKardex> Lineas { get; set; }
  }

  public class LineaKardex
  {
    public DateTime Fecha { get; set; }
    public string Documento { get; set; }
    public Valorizacion Ingreso { get; set; }
    public Valorizacion Salida { get; set; }
    public Valorizacion Saldo { get; set; }
  }
}
