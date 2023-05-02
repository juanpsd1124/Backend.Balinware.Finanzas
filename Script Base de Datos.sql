CREATE DATABASE Movimientos

CREATE TABLE Usuario (
    Id_Usuario SMALLINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Username varchar(30) NOT NULL UNIQUE,
    Password varchar(150) NOT NULL,
	Email varchar(100) NOT NULL UNIQUE,
	FirstName varchar(100) NOT NULL,
	LastName varchar(100) NOT NULL
)

ALTER TABLE Usuario ADD
	Email varchar(100),
	FirstName varchar(100) ,
	LastName varchar(100)

 

INSERT INTO Usuario VALUES ('jposada','contrasena1234', 'jposada@test.com', 'Juan', 'Posada')


CREATE TABLE Tipo(
    Id_Tipo TINYINT NOT NULL PRIMARY KEY,
    Descripcion VARCHAR (50) NOT NULL,
)

INSERT INTO Tipo VALUES (0, 'Ingreso')
INSERT INTO Tipo VALUES (1, 'Egreso')

CREATE TABLE Categoria(
    Id_Categoria TINYINT NOT NULL PRIMARY KEY,
    Descripcion VARCHAR (50) NOT NULL,
)

INSERT INTO Categoria VALUES (0, 'Hogar')
INSERT INTO Categoria VALUES (1, 'Comida')
INSERT INTO Categoria VALUES (2, 'Salidas')
INSERT INTO Categoria VALUES (3, 'Transporte')
INSERT INTO Categoria VALUES (4, 'Imprevistos')

CREATE TABLE Registro (
    Id_Registro INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Fecha DATETIME NOT NULL,
    Id_Usuario_FK SMALLINT NOT NULL,
    Valor MONEY NOT NULL,
    Id_Tipo_FK TINYINT NOT NULL,
    Id_Categoria_FK TINYINT NOT NULL,
    Descripcion VARCHAR(500) NOT NULL,
    FOREIGN KEY (Id_Usuario_FK) REFERENCES Usuario(Id_Usuario),
    FOREIGN KEY (Id_Tipo_FK) REFERENCES Tipo(Id_Tipo),
    FOREIGN KEY (Id_Categoria_FK) REFERENCES Categoria(Id_Categoria)
)

INSERT INTO Registro Values ('2023-04-27', 1, 50000, 1, 0, 'Compre una tuberia para el baño' )
INSERT INTO Registro Values ('2023-04-27', 1, 10000, 0, 0, 'Vendi un Boli' )
INSERT INTO Registro Values ('2023-05-28', 2, 100000, 1, 1, 'Compre la cena para la familia' )
INSERT INTO Registro Values ('2023-05-28', 2, 100000, 0, 3, 'Me regalaron gasolina' )


CREATE TABLE Meta (
    Id_Meta SMALLINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Id_Usuario_Fk SMALLINT NOT NULL,
    Nombre varchar(30) NOT NULL,
    Total MONEY NOT NULL
    FOREIGN KEY (Id_Usuario_Fk) REFERENCES Usuario(Id_Usuario)
)

 

Create Table Abono(
    Id_Abono SMALLINT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Id_Meta_Fk SMALLINT NOT NULL,
    Fecha DATETIME NOT NULL,
    Valor MONEY,
    FOREIGN KEY (Id_Meta_Fk) REFERENCES Meta(Id_Meta)
)

-- Consultas

--tabla usuario
select registro.Id_Registro, Registro.Fecha, Usuario.Username, Registro.Valor, Tipo.Descripcion, Categoria.Descripcion, Registro.Descripcion
from Registro
inner join Usuario on Registro.Id_Usuario_FK = Usuario.Id_Usuario
inner join tipo on Registro.Id_Tipo_FK = Tipo.Id_Tipo 
inner join Categoria on Registro.Id_Categoria_FK = Categoria.Id_Categoria where Usuario.Username = 'dmolina'

 

--tabla de ingresos_Usuario
select registro.Id_Registro, Registro.Fecha, Usuario.Username, Registro.Valor, Tipo.Descripcion, Categoria.Descripcion, Registro.Descripcion
from Registro
inner join Usuario on Registro.Id_Usuario_FK = Usuario.Id_Usuario
inner join tipo on Registro.Id_Tipo_FK = Tipo.Id_Tipo 
inner join Categoria on Registro.Id_Categoria_FK = Categoria.Id_Categoria where Usuario.Username = 'dmolina' and Tipo.Descripcion = 'Ingreso'

 

--tabla de egresos_Usuario
select registro.Id_Registro, Registro.Fecha, Usuario.Username, Registro.Valor, Tipo.Descripcion, Categoria.Descripcion, Registro.Descripcion
from Registro
inner join Usuario on Registro.Id_Usuario_FK = Usuario.Id_Usuario
inner join tipo on Registro.Id_Tipo_FK = Tipo.Id_Tipo 
inner join Categoria on Registro.Id_Categoria_FK = Categoria.Id_Categoria where Usuario.Username = 'dmolina'and Tipo.Descripcion = 'Egreso'


-- Stored Procedures

CREATE PROCEDURE Movimientos_Usuario 
	@Id_Usuario SMALLINT,
	@Tipo_Movimiento SMALLINT

AS
	IF (@Tipo_Movimiento = 0)
	BEGIN 
		SELECT registro.Id_Registro, Registro.Fecha, Usuario.Username, Registro.Valor, Tipo.Descripcion AS Tipo, Categoria.Descripcion AS Categoria, Registro.Descripcion
		FROM Registro
		INNER JOIN Usuario ON Registro.Id_Usuario_FK = Usuario.Id_Usuario
		INNER JOIN tipo ON Registro.Id_Tipo_FK = Tipo.Id_Tipo 
		INNER JOIN Categoria ON Registro.Id_Categoria_FK = Categoria.Id_Categoria WHERE Usuario.Id_Usuario = @Id_Usuario 
		FOR JSON PATH
	END

	ELSE IF (@Tipo_Movimiento = 1)
	BEGIN 
		SELECT registro.Id_Registro, Registro.Fecha, Usuario.Username, Registro.Valor, Tipo.Descripcion AS Tipo, Categoria.Descripcion AS Categoria, Registro.Descripcion
		FROM Registro
		INNER JOIN Usuario ON Registro.Id_Usuario_FK = Usuario.Id_Usuario
		INNER JOIN tipo ON Registro.Id_Tipo_FK = Tipo.Id_Tipo 
		INNER JOIN Categoria ON Registro.Id_Categoria_FK = Categoria.Id_Categoria WHERE Usuario.Id_Usuario = @Id_Usuario AND Tipo.Descripcion = 'Ingreso'
		FOR JSON PATH
	END

	ELSE IF (@Tipo_Movimiento = 2)
	BEGIN 
		SELECT registro.Id_Registro, Registro.Fecha, Usuario.Username, Registro.Valor, Tipo.Descripcion AS Tipo, Categoria.Descripcion AS Categoria, Registro.Descripcion
		FROM Registro
		INNER JOIN Usuario ON Registro.Id_Usuario_FK = Usuario.Id_Usuario
		INNER JOIN tipo ON Registro.Id_Tipo_FK = Tipo.Id_Tipo 
		INNER JOIN Categoria ON Registro.Id_Categoria_FK = Categoria.Id_Categoria WHERE Usuario.Id_Usuario = @Id_Usuario AND Tipo.Descripcion = 'Egreso'
		FOR JSON PATH
	END
GO

SELECT * FROM Caterogia
SELECT * FROM Registro
SELECT * FROM Tipo
Select * FROM Usuario

EXEC Movimientos_Usuario 2,0

-- Procedimiento para insertar registros

CREATE PROCEDURE Insertar_Registro
	@Id_Usuario SMALLINT,
	@Fecha DATETIME,
	@Valor MONEY,
	@Tipo TINYINT,
	@Categoria TINYINT,
	@Descripcion VARCHAR(500)
AS
	
	INSERT INTO Registro Values ( @Fecha, @Id_Usuario, @Valor, @Tipo, @Categoria, @Descripcion )
GO

EXEC Insertar_Registro 2, '2023-04-28 16:45:57' ,140000,0,1,'Prueba'

CREATE PROCEDURE [dbo].[UsersGetByUserAndPassword]
(
    @UserName varchar(30),
    @Password varchar(150)
)
AS
BEGIN
    SELECT Id_Usuario, Username, Email, FirstName, LastName, NULL as Password
    FROM Usuario
    WHERE UserName = @UserName and Password = @Password
	FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
END

SELECT Id_Usuario, Username, Email, FirstName, LastName, Password
    FROM Usuario
    WHERE UserName = 'jposada' and Password = 'contrasena1234'

INSERT INTO Usuario VALUES ('jposada','contrasena1234','jposada@test.com', 'Juan', 'Posada')


EXEC UsersGetByUserAndPassword 'jposada','contrasena1234'
 

 

