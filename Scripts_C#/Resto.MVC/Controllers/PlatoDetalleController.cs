using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca;
using Resto.MVC.Controllers.Modal;namespace Resto.MVC.Controllers
{
    public class PlatoDetalleController : Controller
    {
        protected readonly IAdo _Ado;
        public PlatoDetalleController(IAdo ado) => _Ado = ado;


    }
}