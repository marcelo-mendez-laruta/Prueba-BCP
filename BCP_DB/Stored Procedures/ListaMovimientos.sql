CREATE PROCEDURE [dbo].[ListaMovimientos]
	@NRO_CUENTA nvarchar(14)
AS
	SELECT * FROM [dbo].[Movimiento] WHERE NRO_CUENTA=@NRO_CUENTA
GO
