CREATE DATABASE Facturacion;
GO
USE Facturacion;
GO
-- Tabla Cliente
CREATE TABLE Cliente 
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	Telefono VARCHAR(50) NULL,
	Direccion VARCHAR(100)
);
GO
-- Tabla Factura
CREATE TABLE Factura
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	Fecha DATETIME DEFAULT GETDATE(),
	Cajero VARCHAR(50) NOT NULL,
	IdCliente INT NOT NULL,
	CONSTRAINT FK_IDCliente FOREIGN KEY (IdCliente) REFERENCES Cliente(ID)
);
GO
-- Tabla DetalleFactura
CREATE TABLE DetalleFactura
(
	IdFactura INT NOT NULL,
	Articulo VARCHAR(100) NOT NULL,
	Precio DECIMAL(12,8) NOT NULL DEFAULT 1,
	Cantidad INT NOT NULL DEFAULT 1,
	SubTotal AS (Precio * Cantidad) PERSISTED, -- opcional: cálculo automático
	CONSTRAINT FK_IdDetalleFactura FOREIGN KEY (IdFactura) REFERENCES Factura(ID)
);
GO