using Microsoft.AspNetCore.Mvc;
using Biblioteca;

namespace SuperSimple.Mvc.Controllers;
public class PlatoController : Controller
{
    readonly IAdo _ado;

    public PlatoController(IAdo ado) => _ado = ado;

    [HttpGet]
    public IActionResult Index()
        => View(_ado.TodosPlatos);

    [HttpGet]
    public IActionResult Detalle(int id)
    {
        var categoria = Repositorio.GetCategoria(id);
        if (categoria is null)
        {
            return NotFound();
        }
        return View(categoria);
    }

}