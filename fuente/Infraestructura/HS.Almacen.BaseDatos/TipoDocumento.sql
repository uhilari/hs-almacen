CREATE TABLE [dbo].[TipoDocumento]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY  , 
    [Codigo] CHAR(2) NOT NULL, 
    [Descripcion] VARCHAR(250) NOT NULL, 
    [Eliminado] BIT NOT NULL, 
    CONSTRAINT [UK_TipoDocumento_Codigo] UNIQUE ([Codigo])
)
