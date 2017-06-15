using HS.Almacen.Dominio.Eventos;
using HS.Comun.Dominio.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HS.Almacen.Dominio.Entidades
{
  public class Almacen: Comun.Dominio.Entidades.Almacen
  {
    public Almacen()
    {
      Movimientos = new Lista<Movimiento>();
      Inventarios = new Lista<Inventario>();
    }

    public virtual ILista<Movimiento> Movimientos { get; protected set; }
    public virtual ILista<Inventario> Inventarios { get; protected set; }

    public virtual void Agregar(Movimiento movimiento)
    {
      movimiento.NoEsNull(nameof(movimiento));

      movimiento.Almacen = this;
      Movimientos.Agregar(movimiento);
    }

    public virtual Inventario Agregar(Inventario inventario)
    {
      inventario.NoEsNull(nameof(inventario));

      inventario.Almacen = this;
      Inventarios.Agregar(inventario);
      return inventario;
    }
  }
}
