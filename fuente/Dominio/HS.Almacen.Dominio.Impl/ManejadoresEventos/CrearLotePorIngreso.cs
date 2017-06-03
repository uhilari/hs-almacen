using HS.Almacen.Dominio.Eventos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Dominio.ManejadoresEventos
{
  public class CrearLotePorIngreso : IManejadorDeEvento<ArticuloIngresado>
  {
    private Servicios.IInventarioFactory _existenciaFactory;

    public CrearLotePorIngreso(Servicios.IInventarioFactory existenciaFactory)
    {
      _existenciaFactory = existenciaFactory;
    }

    public void Ejecutar(ArticuloIngresado e)
    {
      e.NoEsNull(nameof(e));

      var existencia = e.Almacen.Inventarios.Buscar(c => c.Articulo == e.LineaIngreso.Articulo);
      if (existencia == null)
      {
        existencia = e.Almacen.AgregarInventario(_existenciaFactory.CrearInventario(e.LineaIngreso));
      }
      existencia.AgregarLote(_existenciaFactory.CrearLote(e.LineaIngreso));
    }
  }
}
