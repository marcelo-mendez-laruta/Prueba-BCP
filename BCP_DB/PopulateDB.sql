INSERT INTO [dbo].[Moneda] (Codigo, Nombre) VALUES ('USD',  'Dolar Estadounidense');
INSERT INTO [dbo].[Moneda] (Codigo, Nombre) VALUES ('BOL',  'Boliviano');
INSERT INTO [dbo].[Tipo_Cambio] (Codigo_Base,Codigo_Cambio, Valor) VALUES ('BOL','USD',  0.15);
INSERT INTO [dbo].[Tipo_Cambio] (Codigo_Base,Codigo_Cambio, Valor) VALUES ('USD','BOL',  6.89);