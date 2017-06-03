using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HS.Almacen.Dominio.Entidades;
using HS.Comun.Dominio.Servicios;
using HS.Comun.Dominio.Entidades;

namespace HS.Almacen.Dominio.Servicios
{
  public class InventarioFactory : IInventarioFactory
  {
    public const string KeyInventario = "SEQ-INVENTARIO";
    public const string KeyLote = "SEQ-LOTE";

    private IRepository<Secuencia> _repositorio;

    public InventarioFactory(IRepository<Secuencia> repositorio)
    {
      _repositorio = repositorio;
    }

    public Inventario CrearInventario(LineaMovimiento linea)
    {
      linea.NoEsNull(nameof(linea));
      var secuencia = _repositorio.BuscarUno(c => c.Llave == KeyInventario)[linea.Movimiento.Fecha];
      return new Inventario(linea.Articulo, linea.Unidad)
      {
        Codigo = secuencia.Siguiente().Cadena()
      };
    }

    public Lote CrearLote(LineaMovimiento linea)
    {
      linea.NoEsNull(nameof(linea));
      var secuencia = _repositorio.BuscarUno(c => c.Llave == KeyLote)[linea.Movimiento.Fecha];
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
