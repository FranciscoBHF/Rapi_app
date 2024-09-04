using Microsoft.AspNetCore.Mvc;
using Biblioteca;

namespace SuperSimple.Mvc.Controllers;

public class PlatoController : Controller
{
    protected readonly IAdo Ado;
    public PlatoController(IAdo ado) => Ado = ado;

    [HttpGet("plato")]
    public async Task<IActionResult> Index()
    {
        var platos = await Ado.TodosPlatos();
        return View("ListaPlatos", platos);
    }

    [HttpGet]
    public async Task<IActionResult> Detalle(int id)
    {
        var platos = await Ado.TodosPlatos();
        var plato = platos.FirstOrDefault(p => p.id == id);

        if (plato == null)
        {
            return NotFound();
        }

        return View(plato);
    }
}
