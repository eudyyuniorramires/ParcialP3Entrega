using ParcialP3Entrega.Models.ViewModels;

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