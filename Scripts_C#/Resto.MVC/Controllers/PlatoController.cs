using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca;
using Resto.MVC.Controllers.Modal;

namespace SuperSimple.Mvc.Controllers;

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
}

