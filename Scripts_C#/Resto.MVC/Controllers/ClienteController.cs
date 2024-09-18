using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca;
using Resto.MVC.Controllers.Modal;

namespace Biblio.Mvc.Controllers;

public class ClienteController : Controller
{
    private readonly IAdo _ado;

    public ClienteController(IAdo ado)
    {
        _ado = ado;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerClientes()
    {
        var clientes = await _ado.ObtenerClientesAsync();
        return View("../Cliente/ListaCliente", clientes);
    }

    [HttpGet]
    public async Task<IActionResult> GetAltaCliente()
    {
        var clientes = await _ado.ObtenerClientesAsync();
        var ordenados = clientes.OrderBy(x => x.cliente).ThenBy(x => x.apellido).ToList();
        return View("../Cliente/NuevoCliente", ordenados);
    }

    // [HttpPost]
    // public async Task<IActionResult> AltaCliente(Cliente cliente)
    // {
    //     await _ado.AltaClienteAsync(cliente);
    //     return RedirectToAction(nameof(GetAltaCliente));
    // }

    // [HttpGet]
    // public IActionResult Error()
    // {
    //     return View();
    // }
}
