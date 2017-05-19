CREATE TABLE [dbo].[Secuencia]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Llave] VARCHAR(15) NOT NULL, 
    [Longitud] INT NOT NULL, 
    [Prefijo] VARCHAR(5) NULL, 
	[TipoSeq] VARCHAR(20) NOT NULL, 
    [Eliminado] BIT NOT NULL, 
    CONSTRAINT [UK_Secuencia_Llave] UNIQUE ([Llave])
)
