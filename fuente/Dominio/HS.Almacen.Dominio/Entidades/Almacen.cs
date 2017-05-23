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

    public virtual void AgregarIngreso(Movimiento ingreso)
    {
      ingreso.NoEsNull(nameof(ingreso));
      if (ingreso.Tipo != TipoMovimiento.Ingreso)
        throw new InvalidOperationException();

      ingreso.Numero = GestorSecuencias.Obtener(Movimiento.KeySecuencia, ingreso.Fecha).Siguiente().Valor;
      Movimientos.Agregar(ingreso);

      foreach (var l in ingreso.Lineas)
      {
        GestorEventos.LanzarEvento(new ArticuloIngresado(this, l));
      }
    }

    public virtual void AgregarInventario(Inventario inventario)
    {
      inventario.NoEsNull(nameof(inventario));

      Inventarios.Agregar(inventario);
    }
  }
}
