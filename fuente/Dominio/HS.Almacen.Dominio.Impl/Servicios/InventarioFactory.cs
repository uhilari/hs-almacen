using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HS.Almacen.Dominio.Entidades;
using HS.Comun.Dominio.Servicios;

namespace HS.Almacen.Dominio.Servicios
{
  public class InventarioFactory : IInventarioFactory
  {
    public InventarioFactory()
    {
    }

    public Inventario CrearInventario(LineaMovimiento linea)
    {
      linea.NoEsNull(nameof(linea));
      var secuencia = GestorSecuencias.Obtener(Inventario.KeySecuencia, linea.Movimiento.Fecha);
      return new Inventario(linea.Articulo, linea.Unidad)
      {
        Codigo = secuencia.Siguiente().Cadena()
      };
    }

    public Lote CrearLote(LineaMovimiento linea)
    {
      linea.NoEsNull(nameof(linea));
      var secuencia = GestorSecuencias.Obtener(Lote.KeySecuencia, linea.Movimiento.Fecha);
      return new Lote(linea.Movimiento.Documento)
      {
        Numero = secuencia.Siguiente().Valor,
        Fecha = linea.Movimiento.Fecha,
        Cantidad = linea.Cantidad,
        Precio = linea.Precio,
        Saldo = linea.Cantidad
      };
    }
  }
}
