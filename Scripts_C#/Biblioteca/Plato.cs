namespace Biblioteca;

public class Plato
{
    public int id {get ; set ;}
    public string plato {get ; set ;}
    public string descripcion {get ; set ;}
    public float precio {get ; set ;}
    public bool disponible {get ; set ;}
    public Plato(int id, string plato, string descripcion, float precio, bool disponible)
    {
        this.id = id;
        this.plato = plato;
        this.descripcion = descripcion;
        this.precio = precio;
        this.disponible = disponible;
    }

}