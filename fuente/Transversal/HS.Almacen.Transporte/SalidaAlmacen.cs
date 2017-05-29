using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen
{
  public class SalidaAlmacen
  {
    public DateTime Fecha { get; set; }
    public string TipoDocumento { get; set; }
    public int Serie { get; set; }
    public int Numero { get; set; }
    public IList<LineaSalidaAlmacen> Lineas { get; set; }
  }

  public class LineaSalidaAlmacen
  {
    public string Articulo { get; set; }
    public string UnidadMedida { get; set; }
    public decimal Cantidad { get; set; }
  }
}
