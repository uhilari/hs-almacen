CREATE TABLE [dbo].[InstanciaSecuencia]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Llave] VARCHAR(20) NOT NULL, 
    [Valor] INT NOT NULL, 
    [IdDefinicion] UNIQUEIDENTIFIER NOT NULL, 
    [Eliminado] BIT NOT NULL, 
    CONSTRAINT [FK_InstanciaSecuencia_Secuencia] FOREIGN KEY ([IdDefinicion]) REFERENCES [Secuencia]([Id])
)
