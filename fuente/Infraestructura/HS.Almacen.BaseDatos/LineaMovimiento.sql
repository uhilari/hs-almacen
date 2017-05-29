CREATE TABLE [dbo].[LineaMovimiento]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY , 
    [Cantidad] NUMERIC(18, 8) NOT NULL, 
    [Precio] NUMERIC(18, 8) NOT NULL, 
    [IdMovimiento] UNIQUEIDENTIFIER NULL, 
    [IdArticulo] UNIQUEIDENTIFIER NULL, 
    [IdUnidadMedida] UNIQUEIDENTIFIER NULL, 
    [Eliminado] BIT NOT NULL, 
    CONSTRAINT [FK_LineaMovimiento_Movimiento] FOREIGN KEY ([IdMovimiento]) REFERENCES [Movimiento]([Id]), 
    CONSTRAINT [FK_LineaMovimiento_Articulo] FOREIGN KEY ([IdArticulo]) REFERENCES [Articulo]([Id]), 
    CONSTRAINT [FK_LineaMovimiento_UnidadMedida] FOREIGN KEY ([IdUnidadMedida]) REFERENCES [UnidadMedida]([Id])
)
