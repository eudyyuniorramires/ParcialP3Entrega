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

        [HttPost]
        public bool Eliminar(int id)
        {
            bool respuesta = true;
            using (SqlConnection cxn = new SqlConnection(cn.db)) 
            {
                cxn.Open();
                try 
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarTipoPropiedad", cxn);
                    cmd.parameters.AddWithValue("@IdTipoPropiedad", id);
                    cmd.parameters.AddWithValue("Estatus", false);

                    cmd.parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.commandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) 
                {
                    respuesta = false;
                }

            }
                respuesta = TipoPropiedad.Instancia.Eliminar(idTP);
            return Json(new { respuesta = respuesta }, JsonRequestBehavior.AllowGet);
        }

    }
}