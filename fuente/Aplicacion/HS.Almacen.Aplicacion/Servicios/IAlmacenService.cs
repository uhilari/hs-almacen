using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Aplicacion.Servicios
{
  public interface IAlmacenService: ICrudService<AlmacenDto>
  {
    void RegistrarIngreso(string idAlmacen, IngresoAlmacen ingresoAlmacen);
    void RegistrarSalida(string idAlmacen, SalidaAlmacen salidaAlmacen);
  }
}
