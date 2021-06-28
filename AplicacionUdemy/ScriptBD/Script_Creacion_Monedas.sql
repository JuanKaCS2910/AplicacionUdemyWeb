CREATE TABLE Moneda
(
	IdMoneda				INT IDENTITY(1,1) PRIMARY KEY,
	NombreMoneda			NCHAR(50),
	UsuarioCreacion			VARCHAR(50),
	FechaCreacion			Datetime,
	UsuarioModificacion		VARCHAR(50) NULL,
	FechaModificacion		Datetime NULL
)
GO
/*
INSERT INTO Moneda(NombreMoneda, UsuarioCreacion, FechaCreacion) VALUES('S/','PROCESO',GETDATE())
INSERT INTO Moneda(NombreMoneda, UsuarioCreacion, FechaCreacion) VALUES('$','PROCESO',GETDATE())
*/
CREATE PROCEDURE Usp_listarMonedas
/*-------------------------------------*/
/*---Comentario: Mostrar los Paises.---*/
/*---Ejecución: 
	EXEC Usp_listarMonedas			---*/
AS
BEGIN
	Select IdMoneda, NombreMoneda from Moneda
END
GO