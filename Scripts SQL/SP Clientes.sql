IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'cliente_upd')
DROP PROCEDURE cliente_upd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'cliente_sel_max_id_cliente')
DROP PROCEDURE cliente_sel_max_id_cliente
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'cliente_sel_by_id')
DROP PROCEDURE cliente_sel_by_id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'cliente_sel_all')
DROP PROCEDURE cliente_sel_all
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'cliente_ins')
DROP PROCEDURE cliente_ins
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'cliente_del')
DROP PROCEDURE cliente_del
GO

/***
* Descripción: Modifica un registro de la tabla Cliente.
***/
CREATE PROCEDURE cliente_upd
	@nombre varchar(50),
	@telefono varchar(50),
	@direccion varchar(50),
	@mail varchar(50),
	@cuit varchar(50),
	@horarios varchar(50),
	@comentarios varchar(50), 
	@numero_escalon int,
	@saldo as money,
	@id_cliente int
AS
BEGIN
	UPDATE Cliente
	SET  
		nombre = @nombre, 
		telefono = @telefono,
		direccion = @direccion,
		mail = @mail,
		cuit = @cuit,
		horarios = @horarios,
		comentarios = @comentarios,
		numero_escalon = @numero_escalon,
		saldo = @saldo                                       
	WHERE id_cliente = @id_cliente
END

GO

/***
* Descripción: Selecciona el máximo valor del campo clave primaria (primary key).
***/
CREATE PROCEDURE cliente_sel_max_id_cliente
AS
BEGIN
	SELECT MAX(id_cliente) FROM Cliente
END

GO

/***
* Descripción: Selecciona un registro de la tabla Cliente por su clave primaria (primary key).
***/
CREATE PROCEDURE [cliente_sel_by_id]
	@id_cliente int
AS
BEGIN
	SELECT * FROM Cliente WHERE id_cliente = @id_cliente
END

GO

/***
* Descripción: Selecciona todos los registros de la tabla Cliente.
***/
CREATE PROCEDURE cliente_sel_all
AS
BEGIN
	SELECT * FROM Cliente ORDER BY id_cliente ASC
END

GO

/***
* Descripción: Adiciona un registro en la tabla cliente.
***/
CREATE PROCEDURE cliente_ins
    @nombre varchar(50),
	@telefono varchar(50),
	@direccion varchar(50),
	@mail varchar(50),
	@cuit varchar(50),
	@horarios varchar(50),
	@comentarios varchar(50), 
	@numero_escalon int,
	@saldo as money
	AS
BEGIN
	INSERT INTO Cliente 
            (nombre, telefono, direccion, mail, cuit, horarios, comentarios, numero_escalon, saldo) 
    VALUES 
            (@nombre, @telefono, @direccion, @mail, @cuit, @horarios, @comentarios, @numero_escalon, @saldo)
END

GO

/***
* Descripción: Elimina un registro por su clave primaria (primary key)
***/
CREATE PROCEDURE cliente_del
	@id_cliente int
AS
BEGIN
	DELETE FROM Cliente WHERE id_cliente = @id_cliente
END








