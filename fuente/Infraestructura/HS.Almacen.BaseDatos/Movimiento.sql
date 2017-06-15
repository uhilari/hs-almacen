CREATE TABLE [dbo].[Movimiento]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY , 
    [Numero] INT NOT NULL, 
    [Fecha] DATE NOT NULL, 
    [IdDocumento] UNIQUEIDENTIFIER NULL, 
	[IdAlmacen] UNIQUEIDENTIFIER NULL,
	[Tipo] VARCHAR(20) not null,
	[Estado] VARCHAR(20) not null,
    [Eliminado] BIT NULL, 
    CONSTRAINT [FK_Movimiento_Documento] FOREIGN KEY ([IdDocumento]) REFERENCES [Documento]([Id]), 
    CONSTRAINT [FK_Movimiento_Almacen] FOREIGN KEY ([IdAlmacen]) REFERENCES [Almacen]([Id])
)
