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
  public class Almacen: EntityBase
  {
    public Almacen()
    {
      Movimientos = new Lista<Movimiento>();
      Inventarios = new Lista<Inventario>();
    }

    public virtual string Codigo { get; set; }
    public virtual string Nombre { get; set; }
    public virtual ILista<Movimiento> Movimientos { get; protected set; }
    public virtual ILista<Inventario> Inventarios { get; protected set; }

    private void _agregarMovimiento(Movimiento movimiento, TipoMovimiento tipo, Action<LineaMovimiento> accionLinea)
    {
      movimiento.NoEsNull(nameof(movimiento));
      if (movimiento.Tipo != tipo)
        throw new InvalidOperationException();

      movimiento.Almacen = this;
      Movimientos.Agregar(movimiento);

      foreach (var linea in movimiento.Lineas)
      {
        accionLinea(linea);
      }
    }

    public virtual void AgregarIngreso(Movimiento ingreso)
    {
      _agregarMovimiento(ingreso, TipoMovimiento.Ingreso, l =>
      {
        GestorEventos.LanzarEvento(new ArticuloIngresado(this, l));
      });
    }

    public virtual void AgregarSalida(Movimiento salida)
    {
      _agregarMovimiento(salida, TipoMovimiento.Salida, l => 
      {
        var inventario = Inventarios.Buscar(c => c.Articulo == l.Articulo);
        l.Precio = inventario.GetPrecioPromedio();
        GestorEventos.LanzarEvento(new ArticuloRetirado(inventario, l.Cantidad));
      });
    }

    public virtual void AgregarInventario(Inventario inventario)
    {
      inventario.NoEsNull(nameof(inventario));

      inventario.Almacen = this;
      Inventarios.Agregar(inventario);
    }
  }
}
