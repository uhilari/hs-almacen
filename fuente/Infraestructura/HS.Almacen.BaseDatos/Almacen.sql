CREATE TABLE [dbo].[Almacen]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY  , 
    [Codigo] CHAR(2) NOT NULL, 
    [Nombre] VARCHAR(250) NOT NULL, 
    [Eliminado] BIT NOT NULL, 
    CONSTRAINT [UK_Almacen_Codigo] UNIQUE ([Codigo])
)
