/***IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'venta_upd')
DROP PROCEDURE venta_upd
GO***/

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'pedido_sel_max_id_pedido')
DROP PROCEDURE pedido_sel_max_id_pedido
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'pedido_sel_by_id')
DROP PROCEDURE pedido_sel_by_id
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'pedido_sel_all')
DROP PROCEDURE pedido_sel_all
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'pedido_ins')
DROP PROCEDURE pedido_ins
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'pedido_del')
DROP PROCEDURE pedido_del
GO

/***
* Descripción: Modifica un registro de la tabla Cliente.
***/

/***CREATE PROCEDURE venta_upd
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
***/
/***
* Descripción: Selecciona el máximo valor del campo clave primaria (primary key).
***/
CREATE PROCEDURE pedido_sel_max_id_pedido
AS
BEGIN
	SELECT MAX(id_pedido) FROM Pedido
END

GO

/***
* Descripción: Selecciona un registro de la tabla Cliente por su clave primaria (primary key).
***/
CREATE PROCEDURE [pedido_sel_by_id]
	@id_pedido int
AS
BEGIN
	SELECT * FROM Pedido WHERE id_pedido = @id_pedido
END

GO

/***
* Descripción: Selecciona todos los registros de la tabla Cliente.
***/
CREATE PROCEDURE pedido_sel_all
AS
BEGIN
	SELECT * FROM Pedido ORDER BY id_pedido ASC
END

GO

/***
* Descripción: Adiciona un registro en la tabla cliente.
***/
CREATE PROCEDURE pedido_ins
	@id_cliente int,
	@id_vendedor int,
	@fecha date,
	@detalle varchar(100),
	@cantidad int
	AS
BEGIN
	INSERT INTO Pedido 
            (id_cliente, id_vendedor, fecha, detalle, cantidad) 
    VALUES 
            (@id_cliente, @id_vendedor, @fecha, @detalle, @cantidad)
END

GO

/***
* Descripción: Elimina un registro por su clave primaria (primary key)
***/
CREATE PROCEDURE pedido_del
	@id_pedido int
AS
BEGIN
	DELETE FROM Pedido WHERE id_pedido = @id_pedido
END



