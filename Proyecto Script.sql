
use master
go

--Creando un login 
create login BetterFuture with password = '123456'
go

Create DataBase UnFuturoMejor
go

use UnFuturoMejor
go

--Creando usuario para la base de datos con el login BetterFuture

create user BetterFuture for login BetterFuture

--Cambiando el rol del usuario otorgandole permisos

alter role db_owner add member BetterFuture

--Creando tabla para los usuarios
 
 create table Usuario(
 Usuario varchar(50)
 Constraint PK_Usuario Primary Key (Usuario),
 Nombre varchar(50),
 Apellido varchar(50),
 Contraseña varchar(15),
 Telefono varchar(9),
 Correo varchar(75),
 TipoUsuario varchar(15)
 )


 Insert Into Usuario Values ('Admin','Administrador','','1234','1234-1234','admin@gmail.com','Admin')
 Insert Into Usuario Values ('Usuario','Usuario','','1234','1234-1234','usu@gmail.com','Usuario')


 Create table Solicitud(
 IdSoli int identity(1,1) Primary key,
 Lugar varchar(100),
 Titulo varchar(50),
 Descripcion varchar(500),
 Imagen image,
 Fecha date,
 Estado varchar(14),
 Respuesta varchar(500),
 Usuario varchar(50)
 constraint FK_Usuario Foreign Key references Usuario(Usuario))
  

