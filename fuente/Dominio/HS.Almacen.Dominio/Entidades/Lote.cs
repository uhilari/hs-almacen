using HS.Comun.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen.Dominio.Entidades
{
  public class Lote : EntityBase
  {
    protected Lote() { }

    public Lote(Documento documento)
    {
      Documento = documento.NoEsNull(nameof(documento));
    }

    public virtual Inventario Inventario { get; internal protected set; }
    public virtual int Numero { get; set; }
    public virtual DateTime Fecha { get; set; }
    public virtual decimal Cantidad { get; set; }
    public virtual decimal Saldo { get; set; }
    public virtual decimal Precio { get; set; }
    public virtual Documento Documento { get; protected set; }
  }
}
