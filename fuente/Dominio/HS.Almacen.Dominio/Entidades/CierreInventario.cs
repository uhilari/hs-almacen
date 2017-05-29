using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Dominio.Entidades
{
  public class CierreInventario: EntityBase
  {
    public virtual DateTime Fecha { get; set; }
    public virtual Inventario Inventario { get; set; }
    public virtual decimal Saldo { get; set; }
    public virtual decimal PrecioPromedio { get; set; }
  }
}
