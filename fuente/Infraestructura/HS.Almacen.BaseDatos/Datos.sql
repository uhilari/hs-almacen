CREATE TABLE [dbo].[Datos]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY  , 
    [Codigo] CHAR(2) NOT NULL, 
    [Descripcion] VARCHAR(250) NOT NULL, 
    [Eliminado] BIT NOT NULL,
	[TipoDato] VARCHAR(150) NOT NULL,
    CONSTRAINT [UK_TipoDocumento_Codigo] UNIQUE ([Codigo], [TipoDato])
)
