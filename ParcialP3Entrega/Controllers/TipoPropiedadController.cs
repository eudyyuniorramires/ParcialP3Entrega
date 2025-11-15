using ParcialP3Entrega.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ParcialP3Entrega.Controllers
{
    public class TipoPropiedadController : Controller
    {
        [HttpGet]
        public JsonResult ListarTipoPropiedad()
        {
            List<TipoPropiedad> _oTP = new List<TipoPropiedad>();
            _oTP = TipoPropiedad.Instancia.Listar();
            return Json(new { _oTP}, JsonRequestBehavior.AllowGet);
        }


    }
}