using HS.Almacen.Dominio.Entidades;
using HS.Comun.Dominio.Entidades;
using HS.Comun.Dominio.Servicios;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HS.Almacen.InitData
{
  class Program
  {
    static void Main(string[] args)
    {
      var sessionFactory = BuildFactory();
      //IniciarDatos(sessionFactory);
      DatosDePrueba(sessionFactory);
      Console.WriteLine("Terminado");
      Console.ReadLine();
    }

    static ISessionFactory BuildFactory()
    {
      var cfg = new Configuration();
      cfg.DataBaseIntegration(db =>
        {
          db.ConnectionStringName = "BDAlmacen";
          db.Dialect<MsSql2012Dialect>();
        });

      var mapper = new ModelMapper();
      mapper.AddMappings(Assembly.Load("HS.Almacen.Persistencia.NHibernate").ExportedTypes.Where(c => c.Name.EndsWith("Mapa")).ToArray());
      var mappings = mapper.CompileMappingForAllExplicitlyAddedEntities();
      cfg.AddMapping(mappings);

      return cfg.BuildSessionFactory();
    }

    static void IniciarDatos(ISessionFactory factory)
    {
      Console.WriteLine("Generando data base...");
      using (var session = factory.OpenSession())
      {
        using (var tran = session.BeginTransaction())
        {
          session.Save(new Dominio.Entidades.Almacen { Codigo = "01", Nombre = "Principal" });

          session.Save(new TipoDocumento { Codigo = "GR", Descripcion = "Guia de Remisión" });
          session.Save(new TipoDocumento { Codigo = "FA", Descripcion = "Factura" });

          session.Save(new UnidadMedida { Codigo = "UN", Nombre = "Unidad" });
          session.Save(new UnidadMedida { Codigo = "DE", Nombre = "Decena" });
          session.Save(new UnidadMedida { Codigo = "DO", Nombre = "Docena" });

          session.Save(new SecuenciaUnica(Dominio.ManejadoresEventos.CrearCodigoArticulo.KeySecuencia) { Longitud = 7, Prefijo = "A" });
          session.Save(new SecuenciaUnica(Dominio.Servicios.InventarioFactory.KeyInventario) { Longitud = 10, Prefijo = "I" });
          session.Save(new SecuenciaMensual(Dominio.ManejadoresEventos.CrearNumeroMovimiento.KeySecuencia));
          session.Save(new SecuenciaDiaria(Dominio.Servicios.InventarioFactory.KeyLote));

          tran.Commit();
        }
      }
    }

    static void DatosDePrueba(ISessionFactory factory)
    {
      Console.WriteLine("Generando datos de prueba...");
      using (var session = factory.OpenSession())
      {
        var secuencia = session.CreateCriteria<SecuenciaUnica>()
          .Add(Restrictions.Where<SecuenciaUnica>(c => c.Llave == Dominio.ManejadoresEventos.CrearCodigoArticulo.KeySecuencia))
          .UniqueResult<SecuenciaUnica>();

        var instanciaSeq = secuencia[DateTime.Today];

        session.Save(new Articulo { Codigo = instanciaSeq.Siguiente().Cadena(), Descripcion = "Articulo Uno" });
        session.Save(new Articulo { Codigo = instanciaSeq.Siguiente().Cadena(), Descripcion = "Articulo Dos" });
        session.Save(new Articulo { Codigo = instanciaSeq.Siguiente().Cadena(), Descripcion = "Articulo Tres" });
        session.Save(new Articulo { Codigo = instanciaSeq.Siguiente().Cadena(), Descripcion = "Articulo Cuatro" });
        session.Save(new Articulo { Codigo = instanciaSeq.Siguiente().Cadena(), Descripcion = "Articulo Quinto" });

        session.Flush();
      }
    }
  }
}
