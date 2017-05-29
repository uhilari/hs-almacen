using HS.Almacen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Dominio.Eventos
{
  public class ArticuloRetirado: IDomainEvent
  {
    public ArticuloRetirado(Inventario inventario, decimal cantidad)
    {
      Inventario = inventario.NoEsNull(nameof(inventario));
      Cantidad = cantidad;
    }

    public Inventario Inventario { get; }
    public decimal Cantidad { get; }
  }
}
