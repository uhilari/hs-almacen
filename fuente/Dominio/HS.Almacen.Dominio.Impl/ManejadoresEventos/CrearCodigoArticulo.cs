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
  public class CrearCodigoArticulo : IManejadorDeEvento<AntesGrabarEntidad<Entidades.Articulo>>
  {
    public const string KeySecuencia = "SEQ-ARTICULO";

    private IRepository<Secuencia> _repositorio;

    public CrearCodigoArticulo(IRepository<Secuencia> repositorio)
    {
      _repositorio = repositorio;
    }

    public void Ejecutar(AntesGrabarEntidad<Articulo> evento)
    {
      var secuencia = _repositorio.BuscarUno(c => c.Llave == KeySecuencia)[DateTime.Today];
      evento.Entidad.Codigo = secuencia.Siguiente().Cadena();
    }
  }
}
