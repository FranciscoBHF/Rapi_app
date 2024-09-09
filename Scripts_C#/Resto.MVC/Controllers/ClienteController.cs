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
        return View("../Cliente/ListaClientes", clientes);
    }

    [HttpGet]
    public async Task<IActionResult> GetAltaCliente()
    {
        var clientes = await _ado.ObtenerClientesAsync();
        var ordenados = clientes.OrderBy(x => x.cliente).ThenBy(x => x.apellido).ToList();
        return View("../Cliente/NuevoCliente", ordenados);
    }

    [HttpPost]
    public async Task<IActionResult> AltaCliente(Cliente cliente)
    {
        await _ado.AltaClienteAsync(cliente);
        return RedirectToAction(nameof(GetAltaCliente));
    }

    [HttpGet]
    public async Task<IActionResult> BuscarCliente(string email, string password)
    {
        var cliente = await _ado.ClientePorPassAsync(email, password);
        if (cliente != null)
        {
            return View("../Cliente/DetalleCliente", cliente);
        }
        else
        {
            ViewBag.Error = "No se encontró el cliente";
            return View("../Cliente/NuevoCliente");
        }
    }
    [HttpGet]
    public IActionResult Error()
    {
        return View();
    }
}
