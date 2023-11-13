DELIMITER $$
use 5to_comidapp $$
DELIMITER $$
CALL RegistrarCliente1(1, 'roberto@gmail.com', 'roberto', 'guaymayen', '321')$$
CALL AltaRestaurante(1, 'Las palmitas','pepelepu500','pe','LasPalmitas@gmail.com')$$
CALL AltaPlato(1,1,'pizz-a','Una pizza clasita con queso y salsa', 500, TRUE)$$
CALL AltaPedido( 1, '2000-02-29' , 2.5 , 'res papas con chedar y una pizz-a',1,1)$$
CALL AltaPedido( 2, '2000-03-10' , 2.5 , 'res papas con chedar y una pizz-a',1,1)$$
CALL AltaPlatoPedido(1,1,4,1000.50)$$
CALL AltaPlatoPedido(1,2,4,1000.50)$$

CALL  Buscar('Las palmitas')$$