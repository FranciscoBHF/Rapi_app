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
CALL AltaPlato(1,'pizz-a','Una pizza clasita con queso y salsa', 500, TRUE,"https://hips.hearstapps.com/hmg-prod/images/pizza-111-variedades-queso-1522235912.jpg")$$
CALL AltaPlato(1,'empa-nada','Una empanada vacia', 900, TRUE,'https://media.ambito.com/p/bc650c6361a73e3503099a3877f5cba5/adjuntos/239/imagenes/038/281/0038281195/1200x675/smart/tapas-empanadasjpg.jpg')$$
CALL AltaPlato(2,'El Rio','Sopa de carne con espinaca', 700, TRUE,'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSCWOHaOiJ5_3pVpZ3EQxSdS6biVzdhYrJLlA&s')$$
CALL AltaPlato(2,'Bife','Es un bife pero de la Rioja', 800, TRUE,'https://airescriollos.com.ar/wp-content/uploads/2020/11/Medio-Bife-de-Chorizo.jpg')$$
CALL AltaPlato(3,'La Nave','Un Pastel de carne hecho con forma de nave', 1500, TRUE,'https://www.paladarselecto.com/wp-content/uploads/2011/05/pastel-de-carne.jpg')$$
CALL AltaPlato(3,'HAL','Una milanesa con salsa en el medio con forma circular', 900, TRUE,'https://i.ytimg.com/vi/cW5yYwMzNbM/hq720.jpg?sqp=-oaymwEhCK4FEIIDSFryq4qpAxMIARUAAAAAGAElAADIQj0AgKJD&rs=AOn4CLAfiu7K_jz_iW9Ccu2qsxAF9mpcgw')$$
CALL AltaPedido( 1, '2000-02-29' , 2.5 , 'res papas con chedar y una pizz-a',1,1)$$
CALL AltaPedido( 2, '2000-03-10' , 2.5 , 'res papas con chedar y una pizz-a',1,1)$$
CALL AltaPlatoPedido(1,1,4,1000.50)$$
CALL AltaPlatoPedido(2,2,4,1000.50)$$

CALL  Buscar('Las palmitas')$$

SELECT *
from Restaurante