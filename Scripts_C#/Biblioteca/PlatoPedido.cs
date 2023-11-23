namespace Biblioteca;

public class PlatoPedido
{
    public int id {get ; set ;}
    public int cantPlatos {get ; set ;}
    public float detalle {get ; set ;}
    public PlatoPedido(int id, int cantPlatos, float detalle)
    {
        this.id = id;
        this.cantPlatos = cantPlatos;
        this.detalle = detalle;
    }
}