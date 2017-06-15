using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Dominio.Entidades
{
  public class MovimientoEfectuadoException: BaseException
  {
    public MovimientoEfectuadoException()
    {
      Codigo = 4030;
    }

    public override string Message => "El movimiento ya ha sido efectuado";
  }
}
