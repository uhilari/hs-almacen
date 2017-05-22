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
  public class ArticuloCrearCodigo : IManejadorDeEvento<AntesGrabarEntidad<Entidades.Articulo>>
  {
    private IRepository<Secuencia> _repositorio;

    public ArticuloCrearCodigo(IRepository<Secuencia> repositorio)
    {
      _repositorio = repositorio;
    }

    public void Ejecutar(AntesGrabarEntidad<Articulo> evento)
    {
      var seq = _repositorio.BuscarUno(c => c.Llave == Articulo.KeySecuencia);
      evento.Entidad.Codigo = seq[DateTime.Today].Siguiente().Cadena();
    }
  }
}
