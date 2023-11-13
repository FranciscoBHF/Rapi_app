DELIMITER $$
use 5to_comidapp $$

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