using HS.Almacen.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen.Dominio.Mocks
{
  public class TipoDocumentoMock: TipoDocumento
  {
    public new Guid Id
    {
      get
      {
        return base.Id;
      }
      set
      {
        base.Id = value;
      }
    }
  }
}
