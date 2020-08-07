use AlmaPLAST;

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'detalleventa_upd')
DROP PROCEDURE detalleventa_upd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'detalleventa_sel_max_id_detalleventa')
DROP PROCEDURE detalleventa_sel_max_id_detalleventa
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'detalleventa_sel_by_id')
DROP PROCEDURE detalleventa_sel_by_id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'detalleventa_sel_all')
DROP PROCEDURE detalleventa_sel_all
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'detalleventa_ins')
DROP PROCEDURE detalleventa_ins
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'detalleventa_del')
DROP PROCEDURE detalleventa_del
GO

/***
* Descripción: Modifica un registro de la tabla Cliente.
***/
CREATE PROCEDURE detalleventa_upd
	@id_venta int,
	@id_cliente int,
	@fecha date,
	@descripcion varchar(100),
	@cantidad int,
	@precio_unitario money,
	@iva money,
	@descuento as money,
	@total money,
	@id_detalleventa int
AS
BEGIN
	UPDATE DetalleVenta
	SET  
		id_venta = @id_venta, 
		id_cliente = @id_cliente,
		fecha = @fecha,
		descripcion = @descripcion,
		cantidad = @cantidad,
		precio_unitario = @precio_unitario,
		iva = @iva,
		descuento = @descuento,
		total = @total		                                  
	WHERE id_venta = @id_venta 

END

GO

/***
* Descripción: Selecciona el máximo valor del campo clave primaria (primary key).
***/
CREATE PROCEDURE detalleventa_sel_max_id_detalleventa
AS
BEGIN
	SELECT MAX(id_detalleventa) FROM DetalleVenta
END

GO

/***
* Descripción: Selecciona un registro de la tabla Cliente por su clave primaria (primary key).
***/
CREATE PROCEDURE [detalleventa_sel_by_id]
	@id_detalleventa int
AS
BEGIN
	SELECT * FROM DetalleVenta WHERE id_detalleventa = @id_detalleventa
END

GO

/***
* Descripción: Selecciona todos los registros de la tabla Cliente.
***/
CREATE PROCEDURE detalleventa_sel_all
AS
BEGIN
	SELECT * FROM DetalleVenta ORDER BY id_detalleventa ASC
END

GO

/***
* Descripción: Adiciona un registro en la tabla cliente.
***/
CREATE PROCEDURE detalleventa_ins

	@id_venta int,
	@id_cliente int,
	@fecha date,
	@descripcion varchar(100),
	@cantidad int,
	@precio_unitario money,
	@iva money,
	@descuento money,
	@total money
	AS
BEGIN
	INSERT INTO DetalleVenta 
            (id_venta, id_cliente, fecha, descripcion, cantidad, precio_unitario, iva, descuento, total) 
    VALUES 
            (@id_venta, @id_cliente, @fecha, @descripcion, @cantidad, @precio_unitario, @iva, @descuento, @total)
END

GO

/***
* Descripción: Elimina un registro por su clave primaria (primary key)
***/
CREATE PROCEDURE detalleventa_del
	@id_detalleventa int
AS
BEGIN
	DELETE FROM DetalleVenta WHERE id_detalleventa = @id_detalleventa
END



