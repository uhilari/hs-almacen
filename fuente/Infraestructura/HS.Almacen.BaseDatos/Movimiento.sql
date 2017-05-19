CREATE TABLE [dbo].[Movimiento]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY , 
    [Numero] INT NOT NULL, 
    [TipoMovimiento] SMALLINT NOT NULL, 
    [Fecha] DATE NOT NULL, 
    [IdDocumento] UNIQUEIDENTIFIER NOT NULL, 
	[IdAlmacen] UNIQUEIDENTIFIER NOT NULL,
    [Eliminado] BIT NULL, 
    CONSTRAINT [FK_Movimiento_Documento] FOREIGN KEY ([IdDocumento]) REFERENCES [Documento]([Id]), 
    CONSTRAINT [FK_Movimiento_Almacen] FOREIGN KEY ([IdAlmacen]) REFERENCES [Almacen]([Id])
)
