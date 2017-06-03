using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen
{
  public class IngresoAlmacen
  {
    public DateTime Fecha { get; set; }
    public string IdTipoDocumento { get; set; }
    public int Serie { get; set; }
    public int Numero { get; set; }
    public IList<LineaIngresoAlmacen> Lineas { get; set; }
  }

  public class LineaIngresoAlmacen
  {
    public string IdArticulo { get; set; }
    public string IdUnidad { get; set; }
    public decimal Cantidad { get; set; }
    public decimal Precio { get; set; }
  }
}
