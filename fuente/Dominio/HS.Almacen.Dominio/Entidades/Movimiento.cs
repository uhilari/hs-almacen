using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen.Dominio.Entidades
{
  public class Movimiento: EntityBase
  {
    public const string KeySecuencia = "SEQ-MOVIMIENTO";

    public Movimiento()
    {
      Lineas = new Lista<LineaMovimiento>();
    }

    public virtual int Numero { get; set; }
    public virtual TipoMovimiento Tipo { get; set; }
    public virtual DateTime Fecha { get; set; }
    public virtual Documento Documento { get; set; }
    public virtual ILista<LineaMovimiento> Lineas { get; set; }
  }

  public enum TipoMovimiento
  {
    Ingreso,
    Salida
  }
}
