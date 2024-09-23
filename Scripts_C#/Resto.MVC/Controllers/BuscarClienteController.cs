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

        public async Task<IActionResult> buscarCliente(string? cadena)
        {
            if(cadena is null)
                return NotFound();
            var cliente = await Ado.buscarCliente(cadena);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        public async Task<IActionResult> Detalle(string? cadena)
        {
            if (cadena == null)
                return NotFound();
            var clientes = await Ado.buscarCliente(cadena);
            if (clientes == null)
            {
                return NotFound();
            }
            return View("ListaClientes", clientes);
        }
}
