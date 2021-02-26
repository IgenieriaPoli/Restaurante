
-- CREACION DE BAS DE DATOS
CREATE DATABASE restaurante_el_buen_sabor;
-- SELECCIONAR BASE DE DATOS
USE restaurante_el_buen_sabor;

-- TABLA PRODUCTOS
CREATE TABLE productos (
	id INT IDENTITY NOT NULL,
	nombre VARCHAR(30) NOT NULL,
	imagen VARCHAR (50) NOT NULL,
	precio_compra INT NOT NULL,
	precio_venta INT NOT NULL,
	stock INT NOT NULL,
	PRIMARY KEY (id)
);

-- TABLA ESTADO MESA
CREATE TABLE estado_mesa (
	id INT IDENTITY NOT NULL,
	estado VARCHAR(30) NOT NULL,
	PRIMARY KEY (id)
);

-- TABLA DE TIPO DOCUMENTO
CREATE TABLE tipo_documento (
	tipo_documento VARCHAR(10) NOT NULL,
	descripcion VARCHAR(50) NOT NULL,
	PRIMARY KEY (tipo_documento)
);

-- TABLA ROL
CREATE TABLE rol (
	id INT NOT NULL IDENTITY,
	rol VARCHAR(30) NOT NULL,
	PRIMARY KEY (id)
);

-- TABLA PEDIDOS
CREATE TABLE pedidos (
	id INT NOT NULL IDENTITY,
	fk_id_producto INT NOT NULL,
	cantidad INT NOT NULL,
	fk_id_comanda INT NOT NULL,
	PRIMARY KEY (id)
);

-- TABLA MESAS
CREATE TABLE mesas (
	numero_mesa INT NOT NULL,
	fk_id_estado INT NOT NULL,
	comensales INT NOT NULL,
	PRIMARY KEY (numero_mesa)
);

-- TABLA COMANDA
CREATE TABLE comanda (
	id INT NOT NULL IDENTITY,
	fk_numero_mesa INT NOT NULL,
	PRIMARY KEY (id)
);

-- TABLA EMPLEADO
CREATE TABLE empleado (
	identificacion INT NOT NULL,
	fkpk_tipo_doc VARCHAR(10) NOT NULL,
	primer_nombre VARCHAR(30) NOT NULL,
	segundo_nombre VARCHAR(30) NOT NULL,
	primer_apellido VARCHAR(30) NOT NULL,
	segundo_apellido VARCHAR(30) NOT NULL,
	contrasenia VARCHAR(50) NOT NULL,
	telefono VARCHAR(13) NOT NULL,
	email VARCHAR(60) NOT NULL,
	direccion VARCHAR(100) NOT NULL,
	fk_rol INT NOT NULL,
	PRIMARY KEY(identificacion,fkpk_tipo_doc)
);

-- TABLA FACTURACION
CREATE TABLE facturacion (
	fkpk_id_comanda INT NOT NULL,
	propina INT NOT NULL,
	cobro INT NOT NULL,
	PRIMARY KEY (fkpk_id_comanda)
);

-- LLAVE FORANEA PEDIDOS
ALTER TABLE pedidos ADD
	CONSTRAINT fk_pedidos_productos FOREIGN KEY (fk_id_producto) REFERENCES productos (id);
ALTER TABLE pedidos ADD
	CONSTRAINT fk_pedidos_comandas FOREIGN KEY (fk_id_comanda) REFERENCES comanda (id);

-- LLAVE FORANEA COMANDA
ALTER TABLE comanda ADD
	CONSTRAINT fkpk_numero_mesa FOREIGN KEY (fk_numero_mesa) REFERENCES mesas (numero_mesa);

-- LLAVE FORANEA FACTURACION
ALTER TABLE facturacion ADD
	CONSTRAINT fkpk_facturaciuon_comanda FOREIGN KEY (fkpk_id_comanda) REFERENCES comanda (id);

-- LLAVE FORANEA MESAS
ALTER TABLE mesas ADD
	CONSTRAINT fkpk_mesas_estado FOREIGN KEY (fk_id_estado) REFERENCES estado_mesa (id);

-- LLAVE FORANEA EMPLEADOS
ALTER TABLE empleado ADD
	CONSTRAINT fkpk_empleado_tipodoc FOREIGN KEY (fkpk_tipo_doc) REFERENCES tipo_documento (tipo_documento);
ALTER TABLE empleado ADD
	CONSTRAINT fk_empleado_rol FOREIGN KEY (fk_rol) REFERENCES rol (id);



-- Vistas
CREATE VIEW view_empleado AS
	SELECT identificacion, fkpk_tipo_doc,primer_nombre,primer_apellido,segundo_nombre,segundo_apellido, telefono, email, direccion, rol FROM empleado
	JOIN rol ON fk_rol = rol.id;

CREATE VIEW productos_mesa AS
    SELECT numero_mesa, cantidad, nombre AS producto, precio_venta FROM mesas
    JOIN comanda ON fk_numero_mesa = numero_mesa
    JOIN pedidos ON fk_id_comanda = comanda.id
    JOIN productos ON fk_id_producto = productos.id;

CREATE PROCEDURE procedure_factura
	@numero_mesa INT
AS
	SELECT comanda.id AS comanda, SUM(precio_venta * cantidad) AS TOTAL FROM mesas
	JOIN comanda ON fk_numero_mesa = numero_mesa
	JOIN pedidos ON fk_id_comanda = comanda.id
	JOIN productos ON fk_id_producto = productos.id
    WHERE numero_mesa = @numero_mesa
	GROUP BY comanda.id
GO