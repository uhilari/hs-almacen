CREATE TABLE [dbo].[Lote]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY , 
    [Numero] INT NOT NULL, 
    [Fecha] DATE NOT NULL, 
    [Cantidad] NUMERIC(18, 8) NOT NULL, 
    [Saldo] NUMERIC(18, 8) NOT NULL, 
    [Precio] NUMERIC(18, 8) NOT NULL, 
    [IdInventario] UNIQUEIDENTIFIER NOT NULL, 
    [IdDocumento] UNIQUEIDENTIFIER NOT NULL, 
    [Eliminado] BIT NOT NULL, 
    CONSTRAINT [UK_Lote_Codigo] UNIQUE ([Numero]), 
    CONSTRAINT [FK_Lote_Inventario] FOREIGN KEY ([IdInventario]) REFERENCES [Inventario]([Id]), 
    CONSTRAINT [FK_Lote_Documento] FOREIGN KEY ([IdDocumento]) REFERENCES [Documento]([Id])
)
