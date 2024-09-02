using Microsoft.AspNetCore.Mvc;
using Biblioteca;
using System.Threading.Tasks;

namespace SuperSimple.Mvc.Controllers
{
    public class BuscarPlatoController : Controller
    {
    protected readonly IAdo Ado;
    private static readonly string _cadena =
        @"Server=localhost;Database=5to_comidapp;Uid=5to_agbd;pwd=Trigg3rs!;Allow User Variables=True";
    public BuscarPlatoController() 
    {
        Ado = new Resto.Dapper.AdoDapper(_cadena);
    }

        [HttpGet("plato")]
        public async Task<IActionResult> Index()
        {
            var platos = await Ado.TodosPlatos();
            return View("ListaPlatos", platos);
        }

        [HttpGet]
        public async Task<IActionResult> Detalle(int id)
        {
            var platos = await Ado.TodosPlatos();
            var plato = platos.FirstOrDefault(p => p.id == id);

            if (plato == null)
            {
                return NotFound();
            }

            return View(plato);
        }
    }
}