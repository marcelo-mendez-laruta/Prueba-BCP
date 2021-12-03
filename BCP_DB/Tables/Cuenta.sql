CREATE TABLE [dbo].[Cuenta]
(
	[NRO_CUENTA] NVARCHAR(14) NOT NULL , 
    [TIPO] CHAR(3) NOT NULL, 
    [MONEDA] CHAR(3) NOT NULL, 
    [NOMBRE] NCHAR(40) NOT NULL, 
    [SALDO] DECIMAL(12, 2) NOT NULL, 
    PRIMARY KEY (NRO_CUENTA),
    CONSTRAINT FK_CodigoMoneda FOREIGN KEY (MONEDA)
    REFERENCES [dbo].[Moneda](Codigo)
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Número de cuenta (13 caracteres si es CTE, 14 si es AHO)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Cuenta',
    @level2type = N'COLUMN',
    @level2name = N'NRO_CUENTA'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Tipo (AHO/CTE)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Cuenta',
    @level2type = N'COLUMN',
    @level2name = N'TIPO'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Identificador de Moneda (BOL/USD) Bolivianos/Dólares',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Cuenta',
    @level2type = N'COLUMN',
    @level2name = N'MONEDA'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Nombre de la cuenta',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Cuenta',
    @level2type = N'COLUMN',
    @level2name = N'NOMBRE'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Saldo actual',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Cuenta',
    @level2type = N'COLUMN',
    @level2name = N'SALDO'