using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Dominio.Consultas
{
  public interface IStockActual: IConsulta<IList<Stock>>
  {
    Guid IdAlmacen { get; set; }
  }
}
