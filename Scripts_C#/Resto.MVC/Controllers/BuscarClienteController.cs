using Microsoft.AspNetCore.Mvc;
using Biblioteca;
using Resto.MVC.Controllers.Modal;
namespace Resto.MVC.Controllers;

public class BuscarClienteController : Controller
{
    protected readonly IAdo Ado;
    public BuscarClienteController(IAdo ado)
    {
        Ado = ado;
    }
    [HttpGet]

    public async Task<IActionResult> buscarCliente(string nombre)
        {
            if(nombre is null)
                return NotFound();
            var cliente = await Ado.buscarCliente(nombre);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
    
}
