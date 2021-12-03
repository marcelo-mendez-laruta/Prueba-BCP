CREATE TABLE [dbo].[Tipo_Cambio]
(
	[Codigo_Base] CHAR(3) NOT NULL , 
    [Codigo_Cambio] CHAR(3) NOT NULL, 
    [Valor] DECIMAL(12, 2) NOT NULL, 
    PRIMARY KEY ([Codigo_Base]),
    CONSTRAINT FK_CambioMoneda FOREIGN KEY (Codigo_Base)
    REFERENCES [dbo].[Moneda](Codigo)

)
