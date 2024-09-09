using Biblioteca;
using Microsoft.AspNetCore.Mvc;
using Resto.Dapper;

namespace SuperSimple.Mvc.Controllers;

public class PlatoController : Controller
{
    protected readonly IAdo Ado;
    public PlatoController(IAdo ado) => Ado = ado;

    [HttpGet]
    public async Task<IActionResult> ObtenerPlato()
    {
        var platos = await Ado.TodosPlatosAsync();
        
        return View("ListaPlatos", platos);
    }

    [HttpGet]
    public async Task<IActionResult> Detalle(int id)
    {
        var platos = await Ado.TodosPlatosAsync();
        var plato = platos.FirstOrDefault(p => p.id == id);

        if (plato == null)
        {
            return NotFound();
        }

        return View(plato);
    }
}
