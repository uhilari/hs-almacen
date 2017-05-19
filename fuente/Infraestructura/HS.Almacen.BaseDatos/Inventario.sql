CREATE TABLE [dbo].[Inventario]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY , 
    [Codigo] CHAR(10) NOT NULL, 
    [Maximo] NUMERIC(18, 8) NOT NULL, 
    [Minimo] NUMERIC(18, 8) NOT NULL, 
	[IdAlmacen] UNIQUEIDENTIFIER NOT NULL, 
    [IdArticulo] UNIQUEIDENTIFIER NOT NULL, 
    [IdUnidadMedida] UNIQUEIDENTIFIER NOT NULL, 
    [Eliminado] BIT NOT NULL, 
    CONSTRAINT [UK_Inventario_Codigo] UNIQUE ([Codigo]), 
    CONSTRAINT [FK_Inventario_Almacen] FOREIGN KEY ([IdAlmacen]) REFERENCES [Almacen]([Id]), 
    CONSTRAINT [FK_Inventario_Articulo] FOREIGN KEY ([IdArticulo]) REFERENCES [Articulo]([Id]), 
    CONSTRAINT [FK_Inventario_UnidadMedida] FOREIGN KEY ([IdUnidadMedida]) REFERENCES [UnidadMedida]([Id])
)
