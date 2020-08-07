IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'escalon_sel_by_id')
DROP PROCEDURE escalon_sel_by_id
GO

CREATE PROCEDURE escalon_sel_by_id
	@id_cliente int,
    @iva int,
	@pico int, 
    @gramaje int
AS
BEGIN
			
			IF @gramaje > 1
			BEGIN
	              SELECT EscalonPrecios.precio
                  FROM EscalonPrecios
                  INNER JOIN Cliente ON Cliente.numero_escalon = EscalonPrecios.nro_escalon 
				  WHERE Cliente.id_cliente = @id_cliente and 
				  EscalonPrecios.iva = @iva and 
				  EscalonPrecios.pico = @pico and 
				  EscalonPrecios.gramaje = @gramaje	
				  END		
			ELSE
			BEGIN
			 SELECT precio FROM EscalonPrecios
				  WHERE iva = @iva and 
				  pico = @pico and 
				  gramaje = @gramaje	
			END
		
END