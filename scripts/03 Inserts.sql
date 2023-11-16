DELIMITER $$
use 5to_comidapp $$
DELIMITER $$

CALL RegistrarCliente1(1, 'roberto@gmail.com', 'roberto', 'guaymayen', '321')$$
Call  RegistrarCliente1 (2,  "Robert@gmail.com","Rupert", "orci", "Pelele")$$
CALL RegistrarCliente1(3, 'Chema@gmail.com', 'Chems', 'Chep', 'Palete')$$
CALL AltaRestaurante(1, 'pepelepu500','Las Palmitas','pe','LasPalmitas@gmail.com')$$
CALL AltaRestaurante(2, 'Obo2000','La Rioja','LaRioja@gmail.com','Che')$$
CALL AltaRestaurante(3, 'El Tango','Apollo773','Nashe@gmail.com','Odisea2001')$$
CALL AltaPlato(1,1,'pizz-a','Una pizza clasita con queso y salsa', 500, TRUE)$$
CALL AltaPlato(2,1,'empa-nada','Una empanada vacia', 900, TRUE)$$
CALL AltaPlato(3,2,'El Rio','Sopa de carne con espinaca', 700, TRUE)$$
CALL AltaPlato(4,2,'Bife','Es un bife pero de la Rioja', 800, TRUE)$$
CALL AltaPlato(5,3,'La Nave','Un Pastel de carne hecho con forma de nave', 1500, TRUE)$$
CALL AltaPlato(6,3,'HAL','Una milanesa con salsa en el medio con forma circular', 900, TRUE)$$
CALL AltaPedido( 1, '2000-02-29' , 2.5 , 'res papas con chedar y una pizz-a',1,1)$$
CALL AltaPedido( 2, '2000-03-10' , 2.5 , 'res papas con chedar y una pizz-a',1,1)$$
CALL AltaPlatoPedido(1,1,4,1000.50)$$
CALL AltaPlatoPedido(2,2,4,1000.50)$$

CALL  Buscar('Las palmitas')$$

SELECT *
from Cliente