DELIMITER $$
use 5to_comidapp $$
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
