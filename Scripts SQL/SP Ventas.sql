IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'venta_upd')
DROP PROCEDURE venta_upd
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'venta_sel_max_id_venta')
DROP PROCEDURE venta_sel_max_id_venta
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'venta_sel_by_id')
DROP PROCEDURE venta_sel_by_id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'venta_sel_all')
DROP PROCEDURE venta_sel_all
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'venta_ins')
DROP PROCEDURE venta_ins
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'venta_del')
DROP PROCEDURE venta_del
GO

/***
* Descripción: Modifica un registro de la tabla Cliente.
***/
CREATE PROCEDURE venta_upd
	@id_cliente int,
	@id_vendedor int,
	@fecha date,
	@tipo_comprobante int,
	@codigo_factura int,
	@iva int,
	@total money,
	@id_venta int
AS
BEGIN
	UPDATE Venta
	SET  
		id_cliente = @id_cliente, 
		id_vendedor = @id_vendedor,
		fecha = @fecha,
		tipo_comprobante = @tipo_comprobante,
		codigo_factura = @codigo_factura,
		iva = @iva,
		total = @total		                                  
	WHERE id_venta = @id_venta 

END

GO

/***
* Descripción: Selecciona el máximo valor del campo clave primaria (primary key).
***/
CREATE PROCEDURE venta_sel_max_id_venta
AS
BEGIN
	SELECT MAX(id_venta) FROM Venta
END

GO

/***
* Descripción: Selecciona un registro de la tabla Cliente por su clave primaria (primary key).
***/
CREATE PROCEDURE [venta_sel_by_id]
	@id_venta int
AS
BEGIN
	SELECT * FROM Venta WHERE id_venta = @id_venta
END

GO

/***
* Descripción: Selecciona todos los registros de la tabla Cliente.
***/
CREATE PROCEDURE venta_sel_all
AS
BEGIN
	SELECT * FROM Venta ORDER BY id_venta ASC
END

GO

/***
* Descripción: Adiciona un registro en la tabla cliente.
***/
CREATE PROCEDURE venta_ins

	@id_cliente int,
	@id_vendedor int,
	@fecha date,
	@tipo_comprobante int,
	@codigo_factura int,
	@iva int,
	@total money
	AS
BEGIN
	INSERT INTO Venta 
            (id_cliente, id_vendedor, fecha, tipo_comprobante, codigo_factura, iva, total) 
    VALUES 
            (@id_cliente, @id_vendedor, @fecha, @tipo_comprobante, @codigo_factura, @iva, @total)
END

GO

/***
* Descripción: Elimina un registro por su clave primaria (primary key)
***/
CREATE PROCEDURE venta_del
	@id_venta int
AS
BEGIN
	DELETE FROM Venta WHERE id_venta = @id_venta
END



