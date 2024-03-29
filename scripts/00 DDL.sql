drop database if exists 5to_comidapp;
create database 5to_comidapp;
use 5to_comidapp;
CREATE table Restaurante
(
idRestaurant SMALLINT UNSIGNED AUTO_INCREMENT,  
restaurante varchar(45),
domicilio varchar(45) not null,
email varchar(45) not null unique,
pasword char(64),
primary key (idRestaurant),
FULLTEXT (restaurante )
);
create table Plato
(
Plato varchar(45),
descripcion varchar (45),
precio decimal(7,2),
idRestaurant SMALLINT UNSIGNED,
disponible bool,
idPLato mediumint unsigned,
primary key(idPlato),
CONSTRAINT FK_Restaurante_Plato FOREIGN KEY (idRestaurant)
REFERENCES Restaurante(idRestaurant),
FULLTEXT (Plato,descripcion)
);
create table Cliente
(
idCliente mediumint unsigned AUTO_INCREMENT,
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
idRestaurant SMALLINT UNSIGNED,
idPlato int,
fecha datetime,
valoracion float(10)not null,
descripcion varchar(45)not null,
primary key (numero),
constraint fk_Restaurante_Pedido foreign key(idRestaurant)
references Restaurante(idRestaurant),
constraint FK_Cliente_idCliente foreign key(idCliente)
references Cliente(idCliente)
);
create table PlatoPedido
(
idPlato mediumint unsigned,
numero mediumint unsigned,
cantPlatos tinyint unsigned,
detalle decimal(7,2),
constraint pk_PlatoPedido primary key(idPlato,numero),
constraint FK_PlatoPed foreign key(idPlato)
references Plato(idPlato),
constraint fk_PlatoPedi foreign key(numero)
references Pedido(numero)
);
create table VentaResto
(
idRestaurant SMALLINT UNSIGNED,
idPlato mediumint unsigned,
mes tinyint unsigned,
ano YEAR,
monto DECIMAL(9,2),
constraint pk_VentaResto primary key(idRestaurant,idPlato,mes,ano),
constraint Fk_VentaRestaurant foreign key (idRestaurant)
references Restaurante(idRestaurant),
constraint fk_VentaPlatoPedido foreign key (idPlato)
references PlatoPedido(idPlato)
);