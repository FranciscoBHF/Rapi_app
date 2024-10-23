using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca;
using Resto.MVC.Controllers.Modal;

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
        var restaurante = restaurantes.FirstOrDefault(p => p.idRestaurant == id);

        if (restaurantes == null)
        {
            return NotFound();
        }

        return View(restaurante);
    }
    [HttpGet]
    public IActionResult GetAltaRestaurante()
    {
        // var clientes = await _ado.ObtenerClientesAsync();
        // var ordenados = clientes.OrderBy(x => x.cliente).ThenBy(x => x.apellido).ToList();
        return View("../Restaurante/AltaRestaurante");
    }
    [HttpPost]
    public async Task<IActionResult> AltaRestaurante(RestauranteModal restauranteModal)
    {

        var restaurantesExistentes = await Ado.TodosRestaurants();

        var restauranteExistente = restaurantesExistentes
            .FirstOrDefault(r => 
                r.restaurante == restauranteModal.restaurante || 
                r.email == restauranteModal.Email || 
                r.domicilio == restauranteModal.domicilio);

        if (restauranteExistente != null)
        {

            ModelState.AddModelError(string.Empty, "Ya existe un restaurante con ese nombre, email o domicilio.");
            return View("../Restaurante/AltaRestaurante", restauranteModal);
        }

        var restaurante = new Restaurant(restauranteModal.restaurante!, restauranteModal.domicilio!, restauranteModal.Email!, restauranteModal.password!);
        await Ado.AltaRestauranteAsync(restaurante);
        return RedirectToAction(nameof(ObtenerRestaurants));
    }
[HttpGet]
public async Task<IActionResult> ObtenerDetalleResto(ushort idRestaurant)
{
    var resto = await Ado.DetalleRestaurantAsync(idRestaurant);
    return View("../Restaurante/DetalleResto", resto);
}
}
