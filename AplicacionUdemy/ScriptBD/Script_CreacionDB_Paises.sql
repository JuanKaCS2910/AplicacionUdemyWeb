CREATE DATABASE DBSistemaFactur
GO
USE DBSistemaFactur
GO
CREATE TABLE Paises
(
	IdPais					INT IDENTITY(1,1) PRIMARY KEY,
	NombrePais				NCHAR(50),
	UsuarioCreacion			VARCHAR(50),
	FechaCreacion			Datetime,
	UsuarioModificacion		VARCHAR(50) NULL,
	FechaModificacion		Datetime NULL
)
GO
/*
INSERT INTO Paises(NombrePais, UsuarioCreacion, FechaCreacion) VALUES('PERÚ','PROCESO',GETDATE())
INSERT INTO Paises(NombrePais, UsuarioCreacion, FechaCreacion) VALUES('ARGENTINA','PROCESO',GETDATE())
INSERT INTO Paises(NombrePais, UsuarioCreacion, FechaCreacion) VALUES('BOLIVIA','PROCESO',GETDATE())
INSERT INTO Paises(NombrePais, UsuarioCreacion, FechaCreacion) VALUES('CHILE','PROCESO',GETDATE())
INSERT INTO Paises(NombrePais, UsuarioCreacion, FechaCreacion) VALUES('ECUADOR','PROCESO',GETDATE())
INSERT INTO Paises(NombrePais, UsuarioCreacion, FechaCreacion) VALUES('COLOMBIA','PROCESO',GETDATE())
INSERT INTO Paises(NombrePais, UsuarioCreacion, FechaCreacion) VALUES('BRAZIL','PROCESO',GETDATE())
INSERT INTO Paises(NombrePais, UsuarioCreacion, FechaCreacion) VALUES('VENEZUELA','PROCESO',GETDATE())
INSERT INTO Paises(NombrePais, UsuarioCreacion, FechaCreacion) VALUES('MEXICO','PROCESO',GETDATE())
*/
CREATE PROCEDURE Usp_listarPaises
/*-------------------------------------*/
/*---Comentario: Mostrar los Paises.---*/
/*---Ejecución: 
	EXEC Usp_listarPaises			---*/
AS
BEGIN
	Select IdPais, NombrePais from Paises
END
GO
/*
CREATE TABLE UserToken
(
	IdUserToken		int IDENTITY(1,1) PRIMARY KEY,
	UserToken		NCHAR(50),
	PassToken		NCHAR(50),
	Status			int
)
GO
*/