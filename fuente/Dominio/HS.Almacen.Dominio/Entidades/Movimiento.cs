using HS.Almacen.Dominio.Eventos;
using HS.Comun.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen.Dominio.Entidades
{
  public abstract class Movimiento: EntityBase
  {
    public Movimiento()
    {
      Estado = EstadoMovimiento.Programado;
      Lineas = new Lista<LineaMovimiento>();
    }

    public virtual int Numero { get; set; }
    public virtual TipoMovimiento Tipo { get; protected set; }
    public virtual EstadoMovimiento Estado { get; protected set; }
    public virtual DateTime Fecha { get; set; }
    public virtual Almacen Almacen { get; internal protected set; }
    public virtual Documento Documento { get; set; }
    public virtual ILista<LineaMovimiento> Lineas { get; set; }

    public virtual void ActualizarLineas(IEnumerable<LineaMovimiento> lineas)
    {
      lineas.NoEsNull(nameof(lineas));
      foreach (var linea in lineas)
      {
        ActualizarLinea(linea.Articulo, linea.Cantidad, linea.Unidad);
      }
    }

    public virtual void ActualizarLinea(Articulo articulo, decimal cantidad, UnidadMedida unidad = null)
    {
      articulo.NoEsNull(nameof(articulo));
      if (Estado == EstadoMovimiento.Efectuado)
        throw new MovimientoEfectuadoException();
      var linea = Lineas.Buscar(c => c.Articulo == articulo);
      if (linea == null)
        throw new ArticuloNoEstaEnMovimientoException(articulo.Codigo);
      linea.ActualizaCantidad(cantidad, unidad);
    }

    protected abstract void EfectuarInterno(LineaMovimiento linea);

    public virtual void Efectuar()
    {
      if (Estado == EstadoMovimiento.Efectuado)
        throw new MovimientoEfectuadoException();
      foreach (var linea in Lineas)
      {
        EfectuarInterno(linea);
      }
      Estado = EstadoMovimiento.Efectuado;
    }
  }

  public class Ingreso: Movimiento
  {
    public Ingreso(){ Tipo = TipoMovimiento.Ingreso; }

    protected override void EfectuarInterno(LineaMovimiento linea)
    {
      if (linea.Cantidad > 0)
      {
        GestorEventos.LanzarEvento(new ArticuloIngresado(Almacen, linea));
      }
    }
  }

  public class Salida: Movimiento
  {
    public Salida() { Tipo = TipoMovimiento.Salida; }

    protected override void EfectuarInterno(LineaMovimiento linea)
    {
      var inventario = Almacen.Inventarios.Buscar(c => c.Articulo == linea.Articulo);
      linea.Precio = inventario.PrecioPromedio;
      GestorEventos.LanzarEvento(new ArticuloRetirado(inventario, linea.Cantidad));
    }
  }

  public enum TipoMovimiento
  {
    Ingreso,
    Salida
  }

  public enum EstadoMovimiento
  {
    Programado,
    Efectuado
  }
}
