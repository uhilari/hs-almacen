using HS.Almacen.Dominio.Entidades;
using HS.Comun.Dominio.Entidades;
using HS.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.Dominio.ManejadoresEventos
{
  public class CrearNumeroMovimiento : IManejadorDeEvento<AntesGrabarEntidad<Movimiento>>
  {
    public const string KeySecuencia = "SEQ-MOVIMIENTO";

    private IRepository<Secuencia> _repositorio;

    public CrearNumeroMovimiento(IRepository<Secuencia> repositorio)
    {
      _repositorio = repositorio;
    }

    public void Ejecutar(AntesGrabarEntidad<Movimiento> evento)
    {
      var secuencia = _repositorio.BuscarUno(c => c.Llave == KeySecuencia)[DateTime.Today];
      evento.Entidad.Numero = secuencia.Siguiente().Valor;
    }
  }
}
