using Biblioteca;
using Microsoft.AspNetCore.Mvc;
using Resto.Dapper;

namespace SuperSimple.Mvc.Controllers
{
    public class AltaPlatoController : Controller
    {
        protected readonly IAdo Ado;
        public AltaPlatoController(IAdo ado) => Ado = ado;

        [HttpGet]
        public async Task<IActionResult> Crear()
        {
            var restaurantes = await Ado.TodosRestaurants();
            ViewBag.Restaurantes = restaurantes; 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Plato plato, int idRestaurant)
        {
            if (!ModelState.IsValid)
            {
                return View(plato);
            }

            try
            {
                await Ado.AltaPlatoAsync(plato, idRestaurant);
                return RedirectToAction("ObtenerPlato", "Plato");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error al crear el plato: {ex.Message}");
                return View(plato);
            }
        }
    }
}
