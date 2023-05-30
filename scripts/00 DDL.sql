drop database if exists comidapp;
create database comidapp;
use comidapp;
CREATE table Restaurante
(
restaurante varchar(45),
domicilio varchar(45) not null,
email varchar(45) not null,
pasword varchar(64),
primary key (domicilio)
);
create table Plato
(
Plato varchar(45) ,
descripcion varchar (45),
precio decimal(7,2),
domicilio varchar(45),
disponible bool,
idPLato mediumint unsigned,
primary key(idPlato),
CONSTRAINT FK_Restaurante_Plato FOREIGN KEY (domicilio)
REFERENCES Restaurante(domicilio)
);
create table Cliente
(
idCliente mediumint unsigned,
email varchar(45) not null ,
cliente varchar(45),
apellido varchar(45),
pasword varchar(45),
primary key (idCliente)
);
create table Pedido
(
idCliente mediumint unsigned,
numero mediumint unsigned not null,
domicilio varchar(45),
idPlatoPedido int,
idPlato int,
fecha datetime,
Precio_total int,
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
