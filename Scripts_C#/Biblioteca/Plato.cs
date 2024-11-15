namespace Biblioteca;

public class Plato
{
    
    public uint id {get ; set ;}
    public string plato {get ; set ;}
    public string descripcion {get ; set ;}
    public decimal? precio {get ; set ;}
    public ushort idRestaurant {get ; set ;}
    public bool disponible {get ; set ;}
    public Restaurant? Restaurant { get; set; }
    public string? imagen {get; set;} 
    public Plato(string plato, string descripcion, decimal? precio,ushort idRestaurant ,bool disponible, string imagen)
    {
        this.plato = plato;
        this.descripcion = descripcion;
        this.precio = precio;
        this.idRestaurant = idRestaurant;
        this.disponible = disponible;
        this.imagen = imagen;
        //this.id = idPlato;
    }
    public Plato() { }
}