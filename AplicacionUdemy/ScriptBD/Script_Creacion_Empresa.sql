CREATE TABLE Empresa
(
	IdEmpresa				INT IDENTITY(1,1) PRIMARY KEY,
	RazonSocial				NCHAR(100),
	RUC						NCHAR(100),
	Email					NCHAR(100),
	IdPais					INT,
	IdMoneda				INT,
	VendeConImpuesto		INT,
	TipoImpuesto			INT,
	IdporImpuesto			INT,
	Direccion				VARCHAR(MAX),
	Imagen					VARCHAR(MAX),
	Status					INT,
	FechaRegistro			Datetime,
	UsuarioCreacion			VARCHAR(50),
	FechaCreacion			Datetime,
	UsuarioModificacion		VARCHAR(50) NULL,
	FechaModificacion		Datetime NULL
)
GO
/*
INSERT INTO Empresa(NombreEmpresa, UsuarioCreacion, FechaCreacion) VALUES('S/','PROCESO',GETDATE())
INSERT INTO Empresa(NombreEmpresa, UsuarioCreacion, FechaCreacion) VALUES('$','PROCESO',GETDATE())
*/
CREATE PROCEDURE Usp_listarEmpresa
/*----------------------------------------*/
/*---Comentario: Mostrar las Empresas.---*/
/*---Ejecución: 
	EXEC Usp_listarEmpresa			-----*/
AS
BEGIN
	Select IdEmpresa, RazonSocial from Empresa
END
GO

/*-------------------------------------------------------------*/
/*---Comentario: Mostrar las Empresas.------------------------*/
/*---Ejecución: 
	EXEC Usp_validarRegistroEmpresa '','',''			-----*/
/*-------------------------------------------------------------*/
CREATE PROCEDURE Usp_validarRegistroEmpresa
(
@razonSocial	nchar(200),
@ruc			nchar(200),
@email			nchar(200)
)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Empresa where RazonSocial = @razonSocial)
		BEGIN 
			IF NOT EXISTS(SELECT * FROM Empresa where RUC = @ruc)
				BEGIN
					IF NOT EXISTS(SELECT * FROM Empresa where Email = @email)
						BEGIN
							SELECT 'Ok' response
						END
					ELSE
						BEGIN 
							SELECT 'El email ya se encuentra registrada' response
						END
				END
			ELSE
				BEGIN 
					SELECT 'El ruc ya se encuentra registrada' response
				END
		END
	ELSE
		BEGIN 
			SELECT 'La razon social ya se encuentra registrada' response
		END
	

	--Select IdEmpresa, RazonSocial from Empresa
END
GO