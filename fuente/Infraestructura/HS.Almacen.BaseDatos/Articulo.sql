CREATE TABLE [dbo].[Articulo]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY  , 
    [Codigo] CHAR(6) NOT NULL, 
    [Descripcion] VARCHAR(250) NOT NULL, 
    [Eliminado] BIT NOT NULL, 
    CONSTRAINT [UK_Articulo_Codigo] UNIQUE ([Codigo])
)
