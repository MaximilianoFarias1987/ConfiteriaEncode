--Procedimientos almacenados

--USUARIO
--Insertar Usuario
create proc sp_InsertarUsuario
@nombre varchar(50),
@apellido varchar(50),
@idTipoDoc int,
@numeroDoc varchar(12),
@nombreUsuario varchar(50),
@contrasenia varchar(20),
@idRol int
as
insert into Usuarios values(@nombre,@apellido,@idTipoDoc,@numeroDoc,@nombreUsuario,@contrasenia,@idRol)


--Actualizar Usuario
create proc sp_ActualizarUsuario
@idUsuario int,
@nombre varchar(50),
@apellido varchar(50),
@idTipoDoc int,
@numeroDoc varchar(12),
@nombreUsuario varchar(50),
@contrasenia varchar(20),
@idRol int
as
update Usuarios set
nombre = @nombre,
apellido = @apellido,
idTipoDoc = @idTipoDoc,
numeroDoc = @numeroDoc,
nombreUsuario = @nombreUsuario,
contrasenia = @contrasenia,
idRol = @idRol
where idUsuario = @idUsuario

--Eliminar Usuario
create proc sp_EliminarUsuario
@idUsaurio int
as
delete Usuarios where idUsuario = @idUsaurio

--Obtener Usuarios
create proc sp_ObtenerUsuarios
as
select * from Usuarios

--Obtener Usuario por ID
create proc sp_ObtenerUsuarioID
@idUsuario int
as
select * from Usuarios where idUsuario = @idUsuario


--MOZO--
-- Insertar Mozo
create proc sp_InsertarMozo
@nombre varchar(50),
@apellido varchar(50),
@idTipoDoc int,
@numDocumento varchar(12),
@email varchar(50),
@telefono varchar(15),
@direccion varchar(50),
@porComision float,
@fechaIngreso date
as
insert into Mozos values (@nombre,@apellido,@idTipoDoc,@numDocumento,@email,@telefono,@direccion,@porComision,@fechaIngreso)


--Actualizar Mozo
create proc sp_ActualizarMozo
@idMozo int,
@nombre varchar(50),
@apellido varchar(50),
@idTipoDoc int,
@numDocumento varchar(12),
@email varchar(50),
@telefono varchar(15),
@direccion varchar(50),
@porComision float,
@fechaIngreso date
as
Update Mozos set
nombre = @nombre,
apellido = @apellido,
idTipoDoc = @idTipoDoc,
numDocumento =@numDocumento,
email = @email,
telefono = @telefono,
direccion = @direccion,
porComision = @porComision,
fechaIngreso = @fechaIngreso
where idMozo = @idMozo

--Eliminar Mozo

create proc sp_EliminarMozo
@idMozo int
as
delete Mozos where idMozo = @idMozo

--Obtener Mozos

create proc sp_ObtenerMozos
as
select * from Mozos


--Obtener Mozo por id

create proc sp_ObtenerMozoId
@idMozo int
as
select * from Mozos where idMozo = @idMozo


--ARTICULOS

--Insertar Articulos

create proc sp_InsertaArticulo
@descripcion varchar(50),
@precio float,
@stock int,
@idRubro int
as
insert into Articulos values (@descripcion,@precio,@stock,@idRubro)

--Actualizar Articulo
create proc sp_ActualizarArticulo
@idArticulo int,
@descripcion varchar(50),
@precio float,
@stock int,
@idRubro int
as
Update Articulos set
descripcion = @descripcion,
precio = @precio,
stock = @stock,
idRubro = @idRubro
where idArticulo = @idArticulo


--Eliminar Articulo

create proc sp_EliminarArticulo
@idArticulo int
as
delete Articulos where idArticulo = @idArticulo

--Obtener Articulos
create proc sp_ObtenerArticulos
as
select * from Articulos

--Obtener Articulo por ID
create proc sp_ObtenerArticuloID
@idArticulo int
as
select * from Articulos where idArticulo = @idArticulo


--LOCALES

--Insertar Local

create proc sp_InsertarLocal
@razonSocial varchar(50),
@direccion varchar(50),
@cuit varchar(50),
@idTipoIva int,
@ingBruto float
as
insert into Locales values(@razonSocial,@direccion,@cuit,@idTipoIva,@ingBruto)


--Actualizar Local
create proc sp_ActualizarLocal
@idLocal int,
@razonSocial varchar(50),
@direccion varchar(50),
@cuit varchar(50),
@idTipoIva int,
@ingBruto float
as
update Locales set
razonSocial = @razonSocial,
direccion = @direccion,
cuit = @cuit,
idTipoIva = @idTipoIva,
ingBruto = @ingBruto
where idLocal = @idLocal

--Eliminar Local
create proc sp_EliminarLocal
@idLocal int
as
delete Locales where idLocal = @idLocal

--Obtener Locales
create proc sp_ObtenerLocales
as
select * from Locales



--TICKETS
--Insertar Ticket

create proc sp_InserarTicket
@idTicket int = null output,
@idLocal int,
@idUsuario int,
@idMozo int,
@idFormaPago int,
@fecha date
as
insert into Tickets values(@idLocal,@idUsuario,@idMozo,@idFormaPago,@fecha)
--obtengo idVenta
set @idTicket = @@IDENTITY

--Eliminar Ticket
create proc sp_EliminarTicket
@idTicket int
as
delete from Tickets where idTicket = @idTicket


--Insertar Detalle de Ticket

create proc sp_InsertarDetalleTicket
@idTicket int,
@idArticulo int,
@cantidad int,
@preUnitario float
as
insert into DetallesTickets values(@idTicket,@idArticulo,@cantidad,@preUnitario)