using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen.Aplicacion.Servicios
{
  public interface IInventarioService
  {
    void RegistrarIngreso(string idAlmacen, IngresoAlmacen ingresoAlmacen);
    void RegistrarSalida(string idAlmacen, SalidaAlmacen salidaAlmacen);
  }
}
