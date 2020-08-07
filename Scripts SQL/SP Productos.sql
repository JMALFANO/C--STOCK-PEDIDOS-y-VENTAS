IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'producto_upd')
DROP PROCEDURE producto_upd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'producto_stk')
DROP PROCEDURE producto_stk
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'producto_sel_max_id_producto')
DROP PROCEDURE producto_sel_max_id_producto
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'producto_sel_by_id')
DROP PROCEDURE producto_sel_by_id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'producto_sel_all')
DROP PROCEDURE producto_sel_all
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'producto_sel_stk')
DROP PROCEDURE producto_sel_stk
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'producto_ins')
DROP PROCEDURE producto_ins
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'producto_del')
DROP PROCEDURE producto_del
GO



/***
* Descripción: Modifica un stock de un producto de la tabla Producto.
***/
CREATE PROCEDURE producto_stk
    @stock int,
	@id_producto int
AS
BEGIN
	UPDATE Producto
	SET  
	stock = @stock                          
	WHERE id_producto = @id_producto
END

GO

/***
* Descripción: Modifica un registro de la tabla Producto.
***/
CREATE PROCEDURE producto_upd
	@tipo int,
	@nombre varchar(50),
	@cantidad int,
	@gramaje int,
	@pico int,
	@stock int,
	@pedidas int,
	@disponibles int,
	@id_producto int
AS
BEGIN
	UPDATE Producto
	SET  
		tipo = @tipo,
		nombre = @nombre, 
		cantidad = @cantidad,
		gramaje = @gramaje,
		pico = @pico,
		stock = @stock,
		pedidas = @pedidas,
		disponibles = @disponibles                             
	WHERE id_producto = @id_producto
END

GO

/***
* Descripción: Selecciona el máximo valor del campo clave primaria (primary key).
***/
CREATE PROCEDURE producto_sel_max_id_producto
AS
BEGIN
	SELECT MAX(id_producto) FROM Producto
END

GO

/***
* Descripción: Selecciona un registro de la tabla Producto por su clave primaria (primary key).
***/
CREATE PROCEDURE [producto_sel_by_id]
	@id_producto int
AS
BEGIN
	SELECT * FROM Producto WHERE id_producto = @id_producto
END

GO

/***
* Descripción: Selecciona todos los registros de la tabla Producto.
***/
CREATE PROCEDURE producto_sel_all
AS
BEGIN
	SELECT * FROM Producto ORDER BY id_producto ASC
END

GO

/***
* Descripción: Selecciona los registros nombre y stock de la tabla Producto.
***/
CREATE PROCEDURE producto_sel_stk
AS
BEGIN
	SELECT id_producto, nombre, stock FROM Producto ORDER BY nombre ASC
END

GO





/***
* Descripción: Adiciona un registro en la tabla Producto.
***/
CREATE PROCEDURE producto_ins
	@tipo int,
    @nombre varchar(50),
	@cantidad int,
	@gramaje int,
	@pico int,
	@stock int,
	@pedidas int,
	@disponibles int
	AS
BEGIN
	INSERT INTO Producto 
            (tipo, nombre, cantidad, gramaje, pico, stock, pedidas, disponibles) 
    VALUES 
            (@tipo, @nombre, @cantidad, @gramaje, @pico, @stock, @pedidas, @disponibles)
END

GO

/***
* Descripción: Elimina un registro por su clave primaria (primary key)
***/
CREATE PROCEDURE producto_del
	@id_producto int
AS
BEGIN
	DELETE FROM Producto WHERE id_producto = @id_producto
END

