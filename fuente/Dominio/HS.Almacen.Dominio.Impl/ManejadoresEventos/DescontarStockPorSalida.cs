using HS.Almacen.Dominio.Entidades;
using HS.Almacen.Dominio.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Dominio.ManejadoresEventos
{
  public class DescontarStockPorSalida : IManejadorDeEvento<ArticuloRetirado>
  {
    private IRepository<Inventario> _repositorioInventario;

    public DescontarStockPorSalida(IRepository<Inventario> repositorioInventario)
    {
      _repositorioInventario = repositorioInventario;
    }

    public void Ejecutar(ArticuloRetirado evento)
    {
      var cantidadSalida = evento.Cantidad;
      var lotes = evento.Inventario.Lotes.Filtrar(c => c.Saldo > 0).OrderBy(c => c.Fecha).ThenBy(c => c.Numero);

      foreach (var item in lotes)
      {
        decimal cantidad = Math.Min(item.Saldo, cantidadSalida);
        item.Saldo -= cantidad;
        cantidadSalida -= cantidad;
        if (cantidadSalida == 0)
          break;
      }
    }
  }
}
