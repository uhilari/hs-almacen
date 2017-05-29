using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Dominio.Consultas
{
  public interface IKardexMensual: IConsulta<Kardex>
  {
    int Año { get; set; }
    int Mes { get; set; }
    Guid? IdInventario { get; set; }
    Guid? IdAlmacen { get; set; }
    Guid? IdArticulo { get; set; }
  }
}
