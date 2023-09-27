```mermaid
erDiagram
    Restaurante{
        Smallint_unsigned  idrestaurante PK
        varchar(45) domicilio 
        varchar(45) restaurant
        varchar(45) email UK
        char(64) password 

    }
    Plato{
        medium_unsigned idPlato PK
        Smallint_unsigned idrestaurante FK
        varchar(45) plato
        varchar(45) descripcion
        decimal(7_2) precio
        bool disponible
    }   
    Cliente{
        MEDIUMINT_UNSIGNED idCliente PK
        varchar(45) email UK
        varchar(45) cliente
        varchar(45) apellido
        char(64) password
    }
    Pedido{
        Medium_unsigned numero PK
        Smallint_unsigned  idrestaurante FK
        Medium_unsigned idCliente FK
        datetime fecha
        float valoracion 
        varchar(45) descripcion
    }
    PlatoPedido{
        Medium_unsigned idPlato PK,FK
        Medium_unsigned numero PK,FK
        tinyint_unsigned cantPlatos
        decimal(7_2) detalle 
    }
    VentaResto{
        datetime fecha PK
        Smallint_unsigned  idrestaurante PK,Fk
        Medium_unsigned idPlato PK,FK
        decimal(9_2) monto 
    }
    Plato }|--|| Restaurante : ""
    Pedido }|--|| Restaurante : ""
    PlatoPedido }|--|| Plato : ""
    PlatoPedido }|--|| Pedido : ""
    Pedido }|--|| Cliente : ""
    VentaResto }|--|| Restaurante : ""
    VentaResto }|--|| Plato : ""

```
