DELIMITER $$
use 5to_comidapp $$
DELIMITER $$
SELECT 'Generando Inserts' Estado$$

CALL RegistrarCliente1('roberto@gmail.com', 'roberto', 'guaymayen', '321')$$
Call  RegistrarCliente1 ("Robert@gmail.com","Rupert", "orci", "Pelele")$$
CALL RegistrarCliente1('Chema@gmail.com', 'Chems', 'Chep', 'Palete')$$
CALL AltaRestaurante('Las Palmitas','pepelepu500','pe','LasPalmitas@gmail.com')$$
CALL AltaRestaurante('La Rioja','Obo2000','Che','LaRioja@gmail.com')$$
CALL AltaRestaurante('El Tango','EApollo773','Odisea2001','Nashe@gmail.com')$$
CALL AltaPlato(1,'pizz-a','Una pizza clasita con queso y salsa', 500, TRUE,"https://www.clarin.com/2022/08/17/QoyfI4ouM_2000x1500__1.jpg")$$
CALL AltaPlato(1,'empa-nada','Una empanada vacia', 900, TRUE,'https://www.clarin.com/2022/08/17/QoyfI4ouM_2000x1500__1.jpg')$$
CALL AltaPlato(2,'El Rio','Sopa de carne con espinaca', 700, TRUE,'https://www.clarin.com/2022/08/17/QoyfI4ouM_2000x1500__1.jpg')$$
CALL AltaPlato(2,'Bife','Es un bife pero de la Rioja', 800, TRUE,'https://www.clarin.com/2022/08/17/QoyfI4ouM_2000x1500__1.jpg')$$
CALL AltaPlato(3,'La Nave','Un Pastel de carne hecho con forma de nave', 1500, TRUE,'https://www.clarin.com/2022/08/17/QoyfI4ouM_2000x1500__1.jpg')$$
CALL AltaPlato(3,'HAL','Una milanesa con salsa en el medio con forma circular', 900, TRUE,'https://www.clarin.com/2022/08/17/QoyfI4ouM_2000x1500__1.jpg')$$
CALL AltaPedido( 1, '2000-02-29' , 2.5 , 'res papas con chedar y una pizz-a',1,1)$$
CALL AltaPedido( 2, '2000-03-10' , 2.5 , 'res papas con chedar y una pizz-a',1,1)$$
CALL AltaPlatoPedido(1,1,4,1000.50)$$
CALL AltaPlatoPedido(2,2,4,1000.50)$$

CALL  Buscar('Las palmitas')$$

SELECT *
from Restaurante