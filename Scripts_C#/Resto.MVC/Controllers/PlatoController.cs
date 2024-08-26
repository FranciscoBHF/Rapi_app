using Microsoft.AspNetCore.Mvc;
using Biblioteca;
using System.Threading.Tasks;

namespace SuperSimple.Mvc.Controllers
{
    public class PlatoController : Controller
    {
        private readonly IAdo _ado;

        public PlatoController(IAdo ado)
        {
            _ado = ado;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var platos = await _ado.TodosPlatos();
            return View(platos);
        }

        [HttpGet]
        public async Task<IActionResult> Detalle(int id)
        {
            var platos = await _ado.TodosPlatos();
            var plato = platos.FirstOrDefault(p => p.id == id);

            if (plato == null)
            {
                return NotFound();
            }

            return View(plato);
        }
    }
}
