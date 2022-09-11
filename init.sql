create database desarrollo;
create database produccion;

USE desarrollo;

CREATE TABLE restaurantes (
	restaurante_id INT NOT NULL AUTO_INCREMENT,
    nombre_ciudad VARCHAR(255) NOT NULL,
    PRIMARY KEY (restaurante_id)
);

CREATE TABLE pedidos (
	pedido_id INT NOT NULL AUTO_INCREMENT,
    codigo VARCHAR(255) NOT NULL,
    descripcion VARCHAR(2000),
    temperatura INT NOT NULL,
    humedad INT NOT NULL,
    PRIMARY KEY (pedido_id)
);

insert into restaurantes (nombre_ciudad) values ('Madrid');

USE produccion;

CREATE TABLE restaurantes (
	restaurante_id INT NOT NULL AUTO_INCREMENT,
    nombre_ciudad VARCHAR(255) NOT NULL,
    PRIMARY KEY (restaurante_id)
);

CREATE TABLE pedidos (
	pedido_id INT NOT NULL AUTO_INCREMENT,
    codigo VARCHAR(255) NOT NULL,
    descripcion VARCHAR(2000),
    temperatura INT NOT NULL,
    humedad INT NOT NULL,
    PRIMARY KEY (pedido_id)
);

insert into restaurantes (nombre_ciudad) values ('Madrid');