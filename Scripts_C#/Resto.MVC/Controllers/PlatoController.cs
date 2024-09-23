using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca;
using Resto.MVC.Controllers.Modal;

namespace Biblio.Mvc.Controllers;

public class PlatoController : Controller
{
    protected readonly IAdo _Ado;
    public PlatoController(IAdo ado) => _Ado = ado;

    [HttpGet]
    public async Task<IActionResult> ObtenerPlato()
    {
        var platos = await _Ado.TodosPlatosAsync();
        return View("ListaPlatos", platos);
    }
    public async Task<IActionResult> Detalle(int id)
    {
        var platos = await _Ado.TodosPlatosAsync();
        var plato = platos.FirstOrDefault(p => p.id == id);

        if (plato == null)
        {
            return NotFound();
        }

        return View(plato);
    }

    public async Task<IActionResult> GetAltaPlato()
    {
        var restaurantes = await _Ado.TodosRestaurants();
        var orderRestaurantes = restaurantes.OrderBy(x => x.id).ToList();
        var platoModal = new PlatoModal();
        platoModal.restaurants = orderRestaurantes;
        return View("../Plato/AltaPlato", platoModal);
    }

    public async Task<IActionResult> AltaPlato(PlatoModal platoModal)
    {
        var plato = new Plato(platoModal.plato, platoModal.descripcion, platoModal.precio, platoModal.idRestaurant, platoModal.disponible);
        await _Ado.AltaPlatoAsync(plato);
        return RedirectToAction(nameof(GetAltaPlato));
    }
}

