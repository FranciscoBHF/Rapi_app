using Biblioteca;
using Microsoft.AspNetCore.Mvc;
using Resto.Dapper;

namespace SuperSimple.Mvc.Controllers;

public class PlatoController : Controller
{
    // protected readonly IAdo Ado;
    // private static readonly string _cadena =
    //     @"Server=localhost;Database=5to_comidapp;Uid=5to_agbd;pwd=Trigg3rs!;Allow User Variables=True";
    //     // @"Server=localhost;Database=5to_Biblioteca;Uid=root;pwd=root;Allow User Variables=True";
    // public PlatoController()
    // {
    //     Ado = new AdoDapper(_cadena);
    // }
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
