namespace Resto.MVC.Controllers;

using System;
using System.Collections.Generic;
using Biblioteca;
using Microsoft.AspNetCore.Mvc;

public class RestauranteController
{
    private readonly IAdo _ado;

    public RestauranteController(IAdo ado)
    {
        _ado = ado;
    }
    [HttpGet]
    public async Task<IActionResult> ObtenerRestaurante()
    {
        var restaurants = await _ado.ObtenerRestauranteAsync();
        return View("../Restorant/ListaRestorant", restaurants);
    }

    private IActionResult View(string v, List<Restaurant> restorants)
    {
        throw new NotImplementedException();
    }
}
