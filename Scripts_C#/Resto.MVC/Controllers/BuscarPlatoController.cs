using Microsoft.AspNetCore.Mvc;
using Biblioteca;

namespace SuperSimple.Mvc.Controllers
{
    public class BuscarPlatoController : Controller
    {
        protected readonly IAdo Ado;
        public BuscarPlatoController(IAdo ado)
        {
            Ado = ado;
        }
        [HttpGet]
        //public async Task<IActionResult> Detalle(int id)
        //{
        //    var platos = await Ado.TodosPlatos();
        //    var plato = platos.FirstOrDefault(p => p.id == id);

        //    if (plato == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(plato);
        //}
        public async Task<IActionResult> BuscarPlato(string? cadena)
        {
            if(cadena is null)
                return NotFound();
            var platos = await Ado.buscarPlato(cadena);
            if (platos == null)
            {
                return NotFound();
            }
            return View(platos);
        }

        public async Task<IActionResult> Detalle(string? cadena)
        {
            if (cadena == null)
                return NotFound();
            var platos = await Ado.buscarPlato(cadena);
            if (platos == null)
            {
                return NotFound();
            }
            return View("ListaPlatos", platos);
        }
    }
}