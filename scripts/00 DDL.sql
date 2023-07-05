drop database if exists 5to_comidapp;
create database 5to_comidapp;
use 5to_comidapp;
CREATE table Restaurante
(
restaurante varchar(45),
domicilio SMALLINT UNSIGNED not null,
email varchar(45) not null unique,
pasword char(64),
primary key (domicilio),
FULLTEXT (restaurante )
);
create table Plato
(
Plato varchar(45),
descripcion varchar (45),
precio decimal(7,2),
domicilio SMALLINT UNSIGNED,
disponible bool,
idPLato mediumint unsigned,
primary key(idPlato),
CONSTRAINT FK_Restaurante_Plato FOREIGN KEY (domicilio)
REFERENCES Restaurante(domicilio),
FULLTEXT (Plato,descripcion)
);
create table Cliente
(
idCliente mediumint unsigned,
email varchar(45) not null unique,
cliente varchar(45),
apellido varchar(45),
pasword char(64),
primary key (idCliente)
);
create table Pedido
(
idCliente mediumint unsigned,
numero mediumint unsigned not null,
domicilio SMALLINT UNSIGNED,
idPlato int,
fecha datetime,
valoracion float(10)not null,
descripcion varchar(45)not null,
primary key (numero),
constraint fk_Restaurante_Pedido foreign key(domicilio)
references Restaurante(domicilio),
constraint FK_Cliente_idCliente foreign key(idCliente)
references Cliente(idCliente)
);
create table PlatoPedido
(
idPlato mediumint unsigned,
numero mediumint unsigned,
CatPlatos tinyint unsigned,
detalle decimal(7,2),
constraint pk_PlatoPedido primary key(idPlato,numero),
constraint FK_PlatoPed foreign key(idPlato)
references Plato(idPlato),
constraint fk_PlatoPedi foreign key(numero)
references Pedido(numero)
);
DELIMITER $$
Create procedure RegistrarCliente (in unidCliente mediumint unsigned, in unemail varchar(45),in uncliente varchar(45), in unapellido varchar(45),in unpasword char(64))
begin
	Insert into Cliente (idCliente,email,cliente,apellido,pasword)
	values (unidCliente,unemail,uncliente,unapellido,SHA2(unpasword,256));
end$$
DELIMITER $$
CREATE PROCEDURE AltaRestaurante(in unrestaurante varchar(45), in unpasword char(64), in unemail varchar(45))
begin
	Insert into Restaurante (Domicilio,restaurante,email,pasword)
	VALUES (undomicilio,unrestaurante,unemail,unpasword);
end$$
DELIMITER $$
CREATE PROCEDURE AltaPlato(In unidPlato mediumint UNSIGNED,in undomicilio SMALLINT UNSIGNED,in unplato VARCHAR(45),in undescripcionP VARCHAR(45),in unprecio DECIMAL(7,2),in undisponible bool)
begin
	Insert into Plato (idPlato, domicilio, Plato, descripcion, precio, disponible)
	values (unidPlato, undomicilio, unplato, undescripcionP, unprecio, undisponible);
end$$
DELIMITER $$
CREATE PROCEDURE AltaPedido(in unnumero mediumint UNSIGNED, in unfecha DATETIME, in unvaloracion FLOAT,in undescripcionPE VARCHAR(45))
begin 
	insert into Pedido(numero,domicilio,idCliente,fecha,valoracion,descripcion)
	values(unnumero,undomicilio,unidCliente,unfecha,unvaloracion,undescripcionPE);
end$$
DELIMITER $$
CREATE PROCEDURE AltaPlatoPedido(in uncantPlatos TINYINT UNSIGNED,in undetalle DECIMAL(7,2))
begin
	INSERT into PlatoPedido (idPlato,numero,cantPlatos,detalle)
	values (unidPlato,unnumero,uncantPlatos,undetalle);
END$$
DELIMITER $$
CREATE FUNCTION GananciaResto (undomicilio SMALLINT UNSIGNED, unfecha1 DATETIME, unfecha2 DATETIME) returns FLOAT  reads sql data
BEGIN
	declare resultado FLOAT;
	select sum(precio*count(plato)) into resultado
	from Plato P
	join Restaurante R on P.domicilio = R.domicilio
	WHERE Domicilio = undomicilio
	and fecha BETWEEN unfecha1 and unfecha2;
	
	return resultado;
END$$
DELIMITER $$
CREATE Procedure Buscar (in Cadena varchar(45))
BEGIN
	Select Plato
	from Plato P
	JOIN Restaurante R on P.domicilio = R.domicilio
	where match (Plato, descripcion, restaurante) AGAINST (Cadena);
END$$
