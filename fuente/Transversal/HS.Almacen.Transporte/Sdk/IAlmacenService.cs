using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Sdk
{
  public interface IAlmacenService
  {
    void RegistrarIngreso(IngresoAlmacen ingreso);
  }
}
