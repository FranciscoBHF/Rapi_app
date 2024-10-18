using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca;
using Resto.MVC.Controllers.Modal;

namespace Biblio.Mvc.Controllers;

public class ClienteController : Controller
{
    private readonly IAdo _Ado;
    public ClienteController(IAdo ado)
    {
        _Ado = ado;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerClientes()
    {
        var clientes = await _Ado.ObtenerClientesAsync();
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
        // Verificar si ya existe un cliente con el mismo email
        var clientesExistentes = await _Ado.ObtenerClientesAsync();
        var clienteExistente = clientesExistentes.FirstOrDefault(c => 
            c.email.Equals(clienteModal.Email, StringComparison.OrdinalIgnoreCase));

        if (clienteExistente != null)
        {
            ModelState.AddModelError(string.Empty, "Ya existe un cliente con este email.");
            return View("../Cliente/AltaCliente", clienteModal); // Devuelve la vista con el error
        }

        var cliente = new Cliente(clienteModal.Email!, clienteModal.Cliente!, clienteModal.Apellido!, clienteModal.password!);
        await _Ado.AltaClienteAsync(cliente);
        return RedirectToAction(nameof(ObtenerClientes)); 
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
    
    // [HttpGet]
    // public async Task<IActionResult> ObtenerDetalle()
    // {
    //     var cliente = await _Ado.AltaClienteAsync();
    //     return View("../Cliente/AltaCliente", cliente);
    // }
    public async Task<IActionResult> Detalle(int id)
    {
        var clientes = await _Ado.TodosClientes();
        var cliente = clientes.FirstOrDefault(c => c.idCliente == id);
        if (cliente == null)
        {
            return NotFound();
        }
        return View(cliente);
    }
    [HttpGet]
    public async Task<IActionResult> ObtenerDetalle(int id)
    {
        var cliente = await _Ado.DetalleClienteAsync(id);
        return View("../Cliente/DetalleCliente", cliente);
    }
}