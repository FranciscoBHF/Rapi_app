using Biblioteca;
using Microsoft.AspNetCore.Mvc;
using Resto.Dapper;

namespace SuperSimple.Mvc.Controllers;

public class RestauranteController : Controller
{
    protected readonly IAdo Ado;
    public RestauranteController(IAdo ado) => Ado = ado;

    [HttpGet]
    public async Task<IActionResult> ObtenerRestaurants()
    {
        var Restaurantes = await Ado.TodosRestaurants();
        
        return View("ListaRestaurante", Restaurantes);
    }

    [HttpGet]
    public async Task<IActionResult> Detalle(int id)
    {
        var restaurantes = await Ado.TodosRestaurants();
        var restaurante = restaurantes.FirstOrDefault(p => p.id == id);

        if (restaurantes == null)
        {
            return NotFound();
        }

        return View(restaurante);
    }
}
