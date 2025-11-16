
using ParcialP3Entrega.Metodos;
using ParcialP3Entrega.Models.ViewModels;
using System.Web.Mvc;

namespace ParcialP3Entrega.Controllers
{
    public class CondicionMetodoController : Controller
    {
        public readonly CondicionPropiedadMetodo _condicionService;

        //public IActionResult Index()
        //{
        //    var lista = _condicionService.Listar();
        //    return View(lista);
        //}

        [HttpPost]
        public JsonResult Insertar(CondicionPropiedad modelo)
        {
            var resultado = _condicionService.Registrar(modelo);
            return Json(new { success = resultado });
        }

        [HttpPost]
        public JsonResult Actualizar(CondicionPropiedad modelo)
        {
            var resultado = _condicionService.Modificar(modelo);
            return Json(new { success = resultado });
        }

        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            var resultado = _condicionService.Eliminar(id);
            return Json(new { success = resultado });
        }
    }
}