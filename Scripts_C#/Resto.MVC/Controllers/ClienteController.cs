using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca;
using Resto.MVC.Controllers.Modal;

namespace Biblio.Mvc.Controllers;

public class ClienteController : Controller
{
    private readonly IAdo _ado;
    private static readonly string _cadena =
    @"Server=Server=localhost;Database=5to_comidapp;User=5to_agbd;Password=Trigg3rs!";

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
    [HttpGet]
    public async Task<IActionResult> AltaCliente(Cliente cliente)
    {
        await _ado.AltaClienteAsync(cliente);
        return View("../Cliente/ListaCliente");
    }
    // [HttpPost]
    // public async Task<IActionResult> AltaCliente(ClienteModal clienteModal)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return View(clienteModal);
    //     }

    //     var cliente = new Cliente(
    //         id: Guid.NewGuid(),
    //         email: clienteModal.Email!,
    //         cliente: clienteModal.Cliente!,
    //         apellido: clienteModal.Apellido!
    //     );

    //     await _ado.AltaClienteAsync(cliente);
    //     return RedirectToAction("ListaCliente");
    // }
}
