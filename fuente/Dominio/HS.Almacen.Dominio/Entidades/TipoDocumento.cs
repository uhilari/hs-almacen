﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen.Dominio.Entidades
{
  public class TipoDocumento: EntityBase
  {
    public virtual string Codigo { get; set; }
    public virtual string Descripcion { get; set; }
  }
}
