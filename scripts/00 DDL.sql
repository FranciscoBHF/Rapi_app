drop database if exists 5to_comidapp;
create database 5to_comidapp;
use 5to_comidapp;
CREATE table Restaurante
(
idRestaurant SMALLINT UNSIGNED,  
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

DELIMITER $$
Create procedure RegistrarCliente1 (in unidCliente mediumint unsigned, in unemail varchar(45),in uncliente varchar(45), in unapellido varchar(45),in unpasword char(64))
begin
	Insert into Cliente (idCliente,email,cliente,apellido,pasword)
	values (unidCliente,unemail,uncliente,unapellido,SHA2(unpasword,256));
end$$

DELIMITER $$
CREATE PROCEDURE AltaRestaurante(in unidRestaurant SMALLINT UNSIGNED,in unrestaurante varchar(45),in undomicilio varchar(45),in unpasword char(64), in unemail varchar(45))
begin
	Insert into Restaurante (idRestaurant, domicilio,restaurante,email,pasword)
	VALUES (unidRestaurant,undomicilio, unrestaurante, unemail, unpasword);
end$$

DELIMITER $$
CREATE PROCEDURE AltaPlato(In unidPlato mediumint UNSIGNED,in unidRestaurant SMALLINT UNSIGNED,in unplato VARCHAR(45),in undescripcionP VARCHAR(45),in unprecio DECIMAL(7,2),in undisponible bool)
begin
	Insert into Plato (idPlato, idRestaurant, Plato, descripcion, precio, disponible)
	values (unidPlato, unidRestaurant, unplato, undescripcionP, unprecio, undisponible);
end$$

DELIMITER $$
CREATE PROCEDURE AltaPedido(in unnumero mediumint UNSIGNED, in unfecha DATETIME, in unvaloracion FLOAT,in undescripcionPE VARCHAR(45),in unidRestaurant SMALLINT UNSIGNED,in unidCliente mediumint unsigned)
begin 
	insert into Pedido(numero,idRestaurant,idCliente,fecha,valoracion,descripcion)
	values(unnumero,unidRestaurant,unidCliente,unfecha,unvaloracion,undescripcionPE);
end$$

DELIMITER $$
CREATE PROCEDURE AltaPlatoPedido(In unidPlato mediumint UNSIGNED,in unnumero mediumint UNSIGNED,in uncantPlatos TINYINT UNSIGNED,in undetalle DECIMAL(7,2))
begin
	INSERT into PlatoPedido (idPlato,numero,cantPlatos,detalle)
	values (unidPlato,unnumero,uncantPlatos,undetalle);
END$$
DELIMITER $$
CREATE FUNCTION GananciaResto (unidRestaurant SMALLINT UNSIGNED, unfecha1 DATETIME, unfecha2 DATETIME) returns FLOAT  reads sql data
BEGIN
	declare resultado FLOAT;

	select sum(detalle*cantPlatos) into resultado
	from PlatoPedido P
	join Pedido p2 on p2.numero = P.numero 
	WHERE idRestaurant = unidRestaurant
	and fecha BETWEEN unfecha1 and unfecha2;
	
	return resultado;
END$$
DELIMITER $$
CREATE Procedure Buscar (in Cadena varchar(45))
BEGIN
	Select Plato
	from Plato P
	JOIN Restaurante R on P.idRestaurant = R.idRestaurant
	where match (Plato, descripcion) AGAINST (Cadena IN BOOLEAN MODE)
	or match (restaurante) AGAINST (Cadena in boolean mode);
END$$

CALL RegistrarCliente1(1, 'roberto@gmail.com', 'roberto', 'guaymayen', '321')$$
CALL AltaRestaurante(1, 'Las palmitas','pepelepu500','pe','LasPalmitas@gmail.com')$$
CALL AltaPlato(1,1,'pizz-a','Una pizza clasita con queso y salsa', 500, TRUE)$$
CALL AltaPedido( 1, '2000-02-29' , 2.5 , 'res papas con chedar y una pizz-a',1,1)$$
CALL AltaPedido( 2, '2000-03-10' , 2.5 , 'res papas con chedar y una pizz-a',1,1)$$
CALL AltaPlatoPedido(1,1,4,1000.50)$$
CALL AltaPlatoPedido(1,2,4,1000.50)$$

CALL  Buscar('Las palmitas')$$

DELIMITER $$
CREATE TRIGGER IncrementarMontoVenta AFTER INSERT ON PlatoPedido FOR EACH ROW
BEGIN
	declare VarMes tinyint UNSIGNED;
	declare VarAno year;
	set VarMes = MONTH(CURRENT_DATE());
	set VarAno = YEAR(CURRENT_DATE());
	if (exists (SELECT *
    	FROM VentaResto
    	WHERE idPlato = NEW.idPlato
    	and mes = VarMes
        and ano = VarAno ))THEN
        	UPDATE VentaResto
        	SET monto = monto + NEW.detalle
        	WHERE idPlato = NEW.idPlato
            	and mes = VarMes
        	and ano = VarAno;
	ELSE
        	INSERT INTO VentaResto (idRestaurant, idPlato, mes, ano, monto)
        	VALUES (idRestaurant, NEW.idPlato, mes, ano , (NEW.detalle * NEW.cantPlatos));
    END IF;
END$$
DELIMITER $$
CREATE TRIGGER DecrementarMontoVenta AFTER DELETE ON PlatoPedido
FOR EACH ROW
BEGIN
    UPDATE VentaResto
    SET monto = monto - OLD.detalle
    WHERE idPlato = OLD.idPlato
   	and mes = VarMes
    	and ano = VarAno;
END$$

DELIMITER $$
DROP TRIGGER IF EXISTS befInsCliente $$
CREATE TRIGGER befInsCajero BEFORE INSERT ON Cliente
FOR EACH ROW
BEGIN
    SET NEW.pasword = SHA2(NEW.pasword, 256);
END $$

DELIMITER $$
DROP TRIGGER IF EXISTS befInsRestaurante $$
CREATE TRIGGER befInsRestaurante BEFORE INSERT ON Restaurante
FOR EACH ROW
BEGIN
    SET NEW.pasword = SHA2(NEW.pasword, 256);
END $$
