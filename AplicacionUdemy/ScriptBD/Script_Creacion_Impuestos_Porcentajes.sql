CREATE TABLE Impuesto
(
	IdImpuesto				INT IDENTITY(1,1) PRIMARY KEY,
	NombreImpuesto			NCHAR(50),
	UsuarioCreacion			VARCHAR(50),
	FechaCreacion			Datetime,
	UsuarioModificacion		VARCHAR(50) NULL,
	FechaModificacion		Datetime NULL
)
GO
/*
INSERT INTO Impuesto(NombreImpuesto, UsuarioCreacion, FechaCreacion) VALUES('IGV','PROCESO',GETDATE())
INSERT INTO Impuesto(NombreImpuesto, UsuarioCreacion, FechaCreacion) VALUES('IVA','PROCESO',GETDATE())
*/
CREATE PROCEDURE Usp_listarImpuesto
/*-------------------------------------*/
/*---Comentario: Mostrar los Impuestos.---*/
/*---Ejecución: 
	EXEC Usp_listarImpuesto			---*/
AS
BEGIN
	Select IdImpuesto, NombreImpuesto from Impuesto
END
GO
CREATE TABLE PorcentajeImpuesto
(
	IdImpuesto				INT IDENTITY(1,1) PRIMARY KEY,
	PorcImpuesto			INT,
	UsuarioCreacion			VARCHAR(50),
	FechaCreacion			Datetime,
	UsuarioModificacion		VARCHAR(50) NULL,
	FechaModificacion		Datetime NULL
)
GO

INSERT INTO PorcentajeImpuesto(PorcImpuesto, UsuarioCreacion, FechaCreacion) VALUES(18,'PROCESO',GETDATE())
INSERT INTO PorcentajeImpuesto(PorcImpuesto, UsuarioCreacion, FechaCreacion) VALUES(5,'PROCESO',GETDATE())
INSERT INTO PorcentajeImpuesto(PorcImpuesto, UsuarioCreacion, FechaCreacion) VALUES(2,'PROCESO',GETDATE())
GO
CREATE PROCEDURE Usp_listarPorcImpuesto
/*-------------------------------------*/
/*---Comentario: Mostrar los Impuestos.---*/
/*---Ejecución: 
	EXEC Usp_listarPorcImpuesto			---*/
AS
BEGIN
	Select IdImpuesto, PorcImpuesto from PorcentajeImpuesto
END
GO