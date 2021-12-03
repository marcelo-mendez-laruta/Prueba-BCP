CREATE TABLE [dbo].[Movimiento]
(
	[NRO_CUENTA] NVARCHAR(14) NOT NULL , 
    [FECHA] DATETIME NOT NULL, 
    [TIPO] CHAR(1) NOT NULL, 
    [IMPORTE] DECIMAL(12, 2) NOT NULL
    PRIMARY KEY (NRO_CUENTA),
    CONSTRAINT FK_CuentaMovimiento FOREIGN KEY (NRO_CUENTA)
    REFERENCES [dbo].[Cuenta](NRO_CUENTA)
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Número de cuenta',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Movimiento',
    @level2type = N'COLUMN',
    @level2name = N'NRO_CUENTA'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Fecha de operación',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Movimiento',
    @level2type = N'COLUMN',
    @level2name = N'FECHA'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Tipo de operación. Posibles valores: D – Debito, A – Abono',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Movimiento',
    @level2type = N'COLUMN',
    @level2name = N'TIPO'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Importe de la operación (Deposito o Retiro)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Movimiento',
    @level2type = N'COLUMN',
    @level2name = N'IMPORTE'