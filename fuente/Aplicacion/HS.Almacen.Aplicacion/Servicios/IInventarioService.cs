using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen.Aplicacion.Servicios
{
  public interface IInventarioService
  {
    void Registrar(string idAlmacen, IngresoAlmacen ingresoAlmacen);
  }
}
