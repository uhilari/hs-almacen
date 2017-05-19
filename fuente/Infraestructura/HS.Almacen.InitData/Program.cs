﻿using HS.Almacen.Dominio.Entidades;
using HS.Comun.Dominio.Entidades;
using NHibernate;
using NHibernate.Cfg;
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
      IniciarDatos(sessionFactory);
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

          session.Save(new SecuenciaUnica(Inventario.KeySecuencia) { Longitud = 10, Prefijo = "I" });
          session.Save(new SecuenciaMensual(Movimiento.KeySecuencia));
          session.Save(new SecuenciaDiaria(Lote.KeySecuencia));

          tran.Commit();
        }
      }
    }

    static void DatosDePrueba(ISessionFactory factory)
    {
      Console.WriteLine("Generando datos de prueba...");
      using (var session = factory.OpenSession())
      {
        session.Save(new Articulo { Codigo = "000001", Descripcion = "Articulo Uno" });
        session.Save(new Articulo { Codigo = "000002", Descripcion = "Articulo Dos" });
        session.Save(new Articulo { Codigo = "000003", Descripcion = "Articulo Tres" });
        session.Save(new Articulo { Codigo = "000004", Descripcion = "Articulo Cuatro" });

        session.Flush();
      }
    }
  }
}
