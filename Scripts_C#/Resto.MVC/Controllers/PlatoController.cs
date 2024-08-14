using Microsoft.AspNetCore.Mvc;
using Biblioteca;
using Resto.Dapper;

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

    [HttpGet]
    public IActionResult FormAlta() => View();

    [HttpPost]
    public IActionResult FormAlta(Categoria categoria)
    {
        Repositorio.AgregarCategoria(categoria);
        return View("Index", Repositorio.Categorias);
    }
    [HttpGet]
    public IActionResult Modificar(int id)
    {
        var categoria = Repositorio.GetCategoria(id);
        if (categoria is null)
        {
            return NotFound();
        }
        return View(categoria);
    }

    [HttpPost]
    public IActionResult Modificar(Categoria categoria)
    {
        Repositorio.ActualizarCategoria(categoria);
        return View("Index", Repositorio.Categorias);
    }
}