using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Almacen.Dominio.Servicios
{
  public interface IInventarioFactory
  {
    Entidades.Inventario CrearInventario(Entidades.LineaMovimiento linea);
    Entidades.Lote CrearLote(Entidades.LineaMovimiento linea);
  }
}
