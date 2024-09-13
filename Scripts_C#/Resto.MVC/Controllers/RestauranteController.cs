namespace Resto.MVC.Controllers;

using System;
using System.Collections.Generic;
using Biblioteca;
using Microsoft.AspNetCore.Mvc;

public class Restaurante(IAdo ado) : Controller
{
    protected readonly IAdo Ado = ado;

    [HttpGet]
    public async Task<IActionResult> ObtenerRestaurant()
    {
        var restautants = await Ado.TodosRestaurants();
        
        return View("ListaRestautants", restautants);
    }

    [HttpGet]
    public async Task<IActionResult> Detalle(int id)
    {
        var restautants = await Ado.TodosRestaurants();
        var restautant = restautants.FirstOrDefault(p => p.id == id);

        if (restautants == null)
        {
            return NotFound();
        }

        return View(restautants);
    }
}
