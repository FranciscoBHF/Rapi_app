using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca;
using Resto.MVC.Controllers.Modal;
using System.Security.Cryptography;
using System.Text;

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
        return View("../Cliente/AltaCliente");
    }

    [HttpGet]
    public IActionResult ObtenerInicioSesion()
    {
        var modal = new ClienteModal();
        return View("../Cliente/InicioSesion", modal);
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
    [HttpPost]
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

    private string ConvertirAHashSHA256(string texto)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerDetalle(int id)
    {
        var cliente = await _Ado.DetalleClienteAsync(id);
        return View("../Cliente/DetalleCliente", cliente);
    }

        [HttpPost]
    public async Task<IActionResult> InicioSesion(ClienteModal clienteModal) 
    {
        var clientes = await _Ado.ObtenerClientesAsync();
        var modal = new ClienteModal();
        var cliente = clientes.Where(x => x.email == clienteModal.Email && x.pasword == ConvertirAHashSHA256(clienteModal.password)).ToList();
        if (cliente.Count == 0)
        {
            modal.error = true;
            return View("../Cliente/InicioSesion", modal);
        }
        return RedirectToAction(nameof(ObtenerDetalleInicio));
    }
    [HttpGet]
    public async Task<IActionResult> ObtenerDetalleInicio(int id)
    {
        var cliente = await _Ado.DetalleInicioAsync(id);
        return View("../Cliente/DetalleInicio", cliente);
    }
}