using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Dominio.Entidades
{
  public class ArticuloNoEstaEnMovimientoException: BaseException
  {
    public ArticuloNoEstaEnMovimientoException(string codigoArticulo)
    {
      Codigo = 4040;
      Articulo = codigoArticulo;
    }

    public string Articulo { get; set; }

    public override string Message => string.Format("El articulo '{0}' no existe en el movimiento", Articulo);
  }
}
