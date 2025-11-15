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


        [HttpPost]
        public JsonResult GuardarTipoPropiedad(TipoPropiedad oTP)
        {
            bool respuesta = false;

            respuesta = (oTP.IdTipoPropiedad == 0)
                ? TipoPropiedad.Instancia.Registrar(oTP)
                : TipoPropiedad.Instancia.Modificar(oTP);
            string mensaje = string.Empty;
           
            return Json(new { respuesta = respuesta}, JsonRequestBehavior.AllowGet);
        }
    }
}