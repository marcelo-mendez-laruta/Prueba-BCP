CREATE TABLE [dbo].[Moneda]
(
	[Codigo] CHAR(3) NOT NULL PRIMARY KEY, 
    [Nombre] VARCHAR(50) NOT NULL, 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Se conciderara solo dos escenarios USD y  BOL',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Moneda',
    @level2type = N'COLUMN',
    @level2name = 'Codigo'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Se conciderara solo dos escenarios Dolar Estadounidense y  Boliviano',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Moneda',
    @level2type = N'COLUMN',
    @level2name = N'Nombre'

