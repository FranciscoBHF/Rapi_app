namespace Biblioteca;

public class Plato
{
    public static Restaurant restaurant;

    public uint id {get ; set ;}
    public string plato {get ; set ;}
    public string descripcion {get ; set ;}
    public decimal precio {get ; set ;}
    public UInt16 idRestaurant {get ; set ;}
    public bool disponible {get ; set ;}
    public Plato(string plato, string descripcion, decimal precio,ushort idRestaurant ,bool disponible,uint idPlato)
    {
        this.plato = plato;
        this.descripcion = descripcion;
        this.precio = precio;
        this.idRestaurant = idRestaurant;
        this.disponible = disponible;
        this.id = idPlato;
    }

}