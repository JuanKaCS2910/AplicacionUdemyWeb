CREATE DATABASE DBAccesos
GO
USE DBAccesos
GO
CREATE TABLE Usuarios_Factur
(
	IdUsuario				INT IDENTITY(1,1) PRIMARY KEY,
	UserName				NCHAR(200),
	DNI						NCHAR(10),
	Email					NCHAR(100),
	Usuario					NCHAR(50),
	Contrasena				VARCHAR(MAX),
	Cargo					NCHAR(50),
	CantidadAcceso			INT,
	Ruc						NCHAR(20),
	Proyecto				NCHAR(30),
	Status					INT,
	FechaRegistro			Datetime,
	UsuarioCreacion			VARCHAR(50),
	FechaCreacion			Datetime,
	UsuarioModificacion		VARCHAR(50) NULL,
	FechaModificacion		Datetime NULL
)
GO
--SELECT * FROM Usuarios_Factur
CREATE TABLE Licencias
(
	IdLicencia				INT IDENTITY(1,1) PRIMARY KEY,
	Ruc						NCHAR(20),
	Email					NCHAR(100),
	Fecha_Inicio			Datetime,
	Fecha_Fin				Datetime,
	Proyecto				NCHAR(30),
	Cantidad_Usuario		INT,
	Validar_Email			INT,
	Status					INT,
	FechaRegistro			Datetime,
	UsuarioCreacion			VARCHAR(50),
	FechaCreacion			Datetime,
	UsuarioModificacion		VARCHAR(50) NULL,
	FechaModificacion		Datetime NULL
)
GO
--TRUNCATE TABLE Licencias
--TRUNCATE TABLE Usuarios_Factur
--SELECT * FROM Licencias

CREATE PROCEDURE Usp_insertarUserAdminEmpresa
-------------------------------------*/
/*---Comentario: Mostrar los Paises.---*/
/*---Ejecución: 
	EXEC Usp_insertarUserAdminEmpresa			---*/
(
@ruc				NCHAR(20),
@email				NCHAR(100),
@username			NCHAR(200),
@usuario			NCHAR(50),
@contrasena			VARCHAR(MAX),
@cargo				NCHAR(20),
@cantUser			INT,
@proyecto			NCHAR(30)
)
AS
BEGIN

DECLARE @FechaFIN DATETIME

SELECT @FechaFIN = DATEADD(DAY,16,GETDATE())

	IF NOT EXISTS(SELECT * FROM USUARIOS_FACTUR WHERE Usuario = @usuario
					AND RUC = @ruc)
		BEGIN
			INSERT INTO Usuarios_Factur
			(UserName,DNI,Email,Usuario
			,Contrasena,Cargo,CantidadAcceso,Ruc
			,Proyecto,Status,FechaRegistro
			,UsuarioCreacion,FechaCreacion)  
			VALUES (@username,'00000000',@email,@usuario,
					@contrasena,@cargo,0,@ruc,
					@proyecto,0,GETDATE(),'PROCESO',GETDATE())

			INSERT INTO LICENCIAS
			(Ruc,Email,Fecha_Inicio,Fecha_Fin
		    ,Proyecto,Cantidad_Usuario,Validar_Email,Status
			,FechaRegistro,UsuarioCreacion,FechaCreacion)
			VALUES
			(@ruc,@email,GETDATE(),@FechaFIN,
			 @proyecto,@cantUser,0,0,
			 GETDATE(), 'PROCESO',GETDATE())

			SELECT 'Ok' response
		END
	ELSE
		BEGIN
			SELECT 'USUARIO ya se encuentra registrado' response
		END
END
GO

ALTER PROCEDURE Usp_activarCuenta
-------------------------------------*/
/*---Comentario: Activar Cuenta.---*/
/*---Ejecución: 
	EXEC Usp_activarCuenta			---*/
(
@ruc				NCHAR(20)
)
AS
BEGIN

DECLARE @FechaFIN DATETIME

SELECT @FechaFIN = DATEADD(DAY,16,GETDATE())

IF EXISTS(SELECT * FROM LICENCIAS WHERE RUC = @ruc AND Validar_Email = 0)
	BEGIN
		UPDATE LICENCIAS 
		   SET Validar_Email = 1, STATUS = 1, 
		       Fecha_Fin = @FechaFIN,
			   FechaModificacion = GETDATE(), 
			   UsuarioModificacion = 'PROCESO'
		  WHERE RUC = @ruc AND Validar_Email = 0

		UPDATE USUARIOS_FACTUR 
		   SET Status = 1,
			   FechaModificacion = GETDATE(), 
			   UsuarioModificacion = 'PROCESO'
		  WHERE RUC = @ruc AND STATUS = 0

		  SELECT 'CUENTA ACTIVADA CORRECTAMENTE' response
	END
ELSE
	BEGIN
		SELECT 'LA CUENTA YA ESTÁ ACTIVADA' response
	END

END
GO
