using Biblioteca;

namespace Resto.MVC.Controllers.Modal;
public class PlatoModal
{

    public string? plato { get; set; }
    public string? descripcion { get; set; }
    public decimal? precio { get; set; }
    public ushort idRestaurant { get; set; }
    public bool disponible {get; set;}
    public List<Restaurant> restaurants { get; set; } = new List<Restaurant>();
    public PlatoModal() {}
}