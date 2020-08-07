

use AlmaPLAST;

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'U' AND name = 'Producto')
DROP TABLE Producto
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'U' AND name = 'Cliente')
DROP TABLE Cliente
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'U' AND name = 'Venta')
DROP TABLE Venta
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'U' AND name = 'DetalleVenta')
DROP TABLE DetalleVenta
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'U' AND name = 'Pedido')
DROP TABLE Pedido
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'U' AND name = 'EscalonPrecios')
DROP TABLE EscalonPrecios
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'U' AND name = 'Pico')
DROP TABLE Pico
GO








CREATE TABLE [dbo].[Cliente] (
    [id_cliente] INT  IDENTITY(1,1) NOT NULL,
    [nombre] VARCHAR (50) NOT NULL,
    [telefono]  VARCHAR (50) NULL,
	[direccion]  VARCHAR (50) NULL,
	[mail]  VARCHAR (50) NULL,
	[cuit]  VARCHAR (50) NULL,
	[horarios]  VARCHAR (50) NULL,
	[comentarios]  VARCHAR (50) NULL,
	[numero_escalon] INT NULL,
	[saldo]  MONEY NULL,
  PRIMARY KEY CLUSTERED ([id_cliente] ASC)
);


CREATE TABLE [dbo].[Producto] (
    [id_producto] INT IDENTITY(1,1) NOT NULL,
	[tipo] INT NULL, --1 Envase, 2Tapa, 3Otros
    [nombre] VARCHAR (50) NULL,
    [cantidad] INT NULL,
    [gramaje]  INT NULL,
    [pico]  INT NULL,
	[stock] INT NULL,
	[pedidas] INT NULL,
	[disponibles] INT NULL,
    PRIMARY KEY CLUSTERED ([id_producto] ASC)
	);






CREATE TABLE [dbo].[Venta] (
    [id_venta] INT IDENTITY(1,1) NOT NULL,
	[id_cliente] INT NULL, 
	[id_vendedor] INT NULL,
    [fecha] date,
    [tipo_comprobante]  INT NULL,
    [codigo_factura]  INT NULL,
	[iva] INT NULL,
	[total] money NULL,

    PRIMARY KEY CLUSTERED ([id_venta] ASC)
	);

	CREATE TABLE [dbo].[DetalleVenta] (
    [id_detalleventa] INT IDENTITY(1,1) NOT NULL,
	[id_venta] INT NULL,
	[id_cliente] INT NULL,
	[fecha] DATE NULL,
	[descripcion] varchar(100) NULL, 
	[cantidad] INT NULL,
    [precio_unitario] money NULL,
    [iva] money NULL,
	[descuento] MONEY NULL,
    [total]  MONEY NULL,

    PRIMARY KEY CLUSTERED ([id_detalleventa] ASC)
	);


	CREATE TABLE [dbo].[Pedido] (
    [id_pedido] INT IDENTITY(1,1) NOT NULL,
	[id_cliente] INT NULL,
	[id_vendedor] INT NULL, 
	[fecha] DATE,
	[detalle] varchar(100) NULL,
    [cantidad] INT NULL,
    PRIMARY KEY CLUSTERED ([id_pedido] ASC)
	);


	CREATE TABLE [dbo].[Pico] (
    [id_pico] INT IDENTITY(1,1) NOT NULL,
	[tipo_pico] INT NULL
    PRIMARY KEY CLUSTERED ([id_Pico] ASC)
	);
	

	CREATE TABLE [dbo].[EscalonPrecios] (
    [id_escalon] INT IDENTITY(1,1) NOT NULL,
	[nro_escalon] INT NULL,
	[iva] INT NULL,
	[pico] INT NULL,
	[gramaje] INT NULL, 
	[precio] MONEY null,
    PRIMARY KEY CLUSTERED ([id_escalon] ASC)
	);

	CREATE TABLE [dbo].[PreciosTapa] (
    [id_tapa] INT IDENTITY(1,1) NOT NULL,
	[nombre] VARCHAR(50) NULL,
	[iva] INT NULL,
	[pico] INT NULL, 
	[precio] MONEY null,
    PRIMARY KEY CLUSTERED ([id_tapa] ASC)
	);


	select * from Venta
	select * from DetalleVenta

