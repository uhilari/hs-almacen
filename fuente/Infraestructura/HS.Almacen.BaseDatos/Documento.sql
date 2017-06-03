CREATE TABLE [dbo].[Documento]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY , 
    [Fecha] DATE NOT NULL, 
    [Serie] INT NOT NULL, 
    [Numero] INT NOT NULL, 
    [IdTipoDocumento] UNIQUEIDENTIFIER NULL, 
    [Eliminado] BIT NOT NULL, 
    CONSTRAINT [FK_Documento_TipoDocumento] FOREIGN KEY ([IdTipoDocumento]) REFERENCES [Datos]([Id])
)
