﻿using HS.Almacen.Dominio.Eventos;
using HS.Comun.Dominio.Entidades;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HS.Almacen.Dominio.Entidades
{
  public class AlmacenTest
  {
    private Almacen _almacen;

    public AlmacenTest()
    {
      _almacen = new Almacen
      {
        Codigo = "001",
        Nombre = "Principal"
      };
    }

    [Fact]
    public void AgregarIngreso_Correcto()
    {
      _almacen.Agregar(Mocks.Fabrica.CrearIngreso());

      Assert.Equal(_almacen.Movimientos.Count, 1);
    }

    [Fact]
    public void AgregarIngreso_IngresoNoNull()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        _almacen.Agregar((Movimiento)null);
      });
    }

    [Fact]
    public void AgregarIngreso_NoIngreso()
    {
      Assert.Throws<InvalidOperationException>(() =>
      {
        _almacen.Agregar(Mocks.Fabrica.CrearSalida());
      });
    }

    [Fact]
    public void AgregarIngreso_LanzandoExistenciaCreada()
    {
      var mockActivadorDeEventos = new Mock<IActivadorDeEventos>();

      bool eventoActivo = false;
      //GestorEventos.Activador = mockActivadorDeEventos.Object;
      mockActivadorDeEventos.Setup(c => c.Activar(It.IsAny<ArticuloIngresado>()))
        .Callback(() => eventoActivo = true);
      _almacen.Agregar(Mocks.Fabrica.CrearIngreso());

      Assert.True(eventoActivo);
    }

    [Fact]
    public void AgregarExistencia_Correcto()
    {
      _almacen.Agregar(new Inventario(new Articulo(), new UnidadMedida()));

      Assert.NotEmpty(_almacen.Inventarios);
    }

    [Fact]
    public void AgregarExistencia_NoNull()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        _almacen.Agregar((Movimiento)null);
      });
    }
  }
}
