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
        var ordenarCliente = clientes.OrderBy(x => x.idCliente);
        return View("../Cliente/ListaCliente", ordenarCliente);
    }

    [HttpGet]
    public IActionResult GetAltaCliente()
    {
        // var clientes = await _ado.ObtenerClientesAsync();
        // var ordenados = clientes.OrderBy(x => x.cliente).ThenBy(x => x.apellido).ToList();
        return View("../Cliente/AltaCliente");
    }

    [HttpPost]
    public async Task<IActionResult> AltaCliente(ClienteModal clienteModal)
    {
        var cliente = new Cliente(clienteModal.Email, clienteModal.Cliente, clienteModal.Apellido, clienteModal.password);
        await _ado.AltaClienteAsync(cliente);
        return RedirectToAction(nameof(GetAltaCliente));
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
    // [HttpGet]
    // public async Task<IActionResult> GetAltaClienteAsync()
    // {
    //     var clientes = await _ado.ObtenerClientesAsync();
    //     var ordenados = clientes.OrderBy(x => x.email).ToList();
    //     ClienteModal clienteModal = new ClienteModal();
    //     return View("AltaCliente", clienteModal);
    // }

    // [HttpPost]
    // public async Task<IActionResult> AltaClienteAsync(Cliente cliente, string password)
    // {
    //     await _ado.AltaClienteAsync(cliente);
    //     return RedirectToAction(nameof(GetAltaClienteAsync));
    // }
}
