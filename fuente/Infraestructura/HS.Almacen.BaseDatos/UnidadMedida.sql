CREATE TABLE [dbo].[UnidadMedida]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY  , 
    [Codigo] VARCHAR(5) NOT NULL, 
    [Nombre] VARCHAR(250) NOT NULL, 
    [Eliminado] BIT NOT NULL, 
    CONSTRAINT [UK_UnidadMedida_Codigo] UNIQUE ([Codigo])
)
