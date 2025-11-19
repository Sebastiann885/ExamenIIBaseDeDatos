CREATE DATABASE Facturacion;
GO

USE Facturacion;
GO

-- TABLA CLIENTE
CREATE TABLE Cliente 
(
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    Telefono VARCHAR(50) NULL,
    Direccion VARCHAR(100) NULL
);
GO

-- TABLA FACTURA
CREATE TABLE Factura
(
    ID INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    Cajero VARCHAR(50) NOT NULL,

    IdCliente INT NOT NULL,
    CONSTRAINT FK_Factura_Cliente FOREIGN KEY (IdCliente)
        REFERENCES Cliente(ID)
);
GO

-- TABLA DETALLE FACTURA
CREATE TABLE DetalleFactura
(
    IdDetalle INT PRIMARY KEY IDENTITY(1,1),

    IdFactura INT NOT NULL,
    Articulo VARCHAR(100) NOT NULL,
    Precio DECIMAL(12, 2) NOT NULL,
    Cantidad INT NOT NULL DEFAULT 1,

    -- SubTotal calculado automáticamente
    SubTotal AS (Precio * Cantidad),

    CONSTRAINT FK_DetalleFactura_Factura FOREIGN KEY (IdFactura)
        REFERENCES Factura(ID)
);
GO