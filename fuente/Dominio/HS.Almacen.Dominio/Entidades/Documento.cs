using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen.Dominio.Entidades
{
  public class Documento : EntityBase
  {
    public virtual int Serie { get; set; }
    public virtual int Numero { get; set; }
    public virtual DateTime Fecha { get; set; }
    public virtual TipoDocumento Tipo { get; set; }
  }
}
