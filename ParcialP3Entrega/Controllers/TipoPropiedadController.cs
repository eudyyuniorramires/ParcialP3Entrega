using ParcialP3Entrega.Clases;
using ParcialP3Entrega.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        [HttpPost]
        public bool Eliminar(int id)
        {
            bool respuesta = true;
            using (SqlConnection cxn = new SqlConnection(cnn.db)) 
            {
                cxn.Open();
                try 
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarTipoPropiedad", cxn);
                    cmd.Parameters.AddWithValue("@IdTipoPropiedad", id);
                    cmd.Parameters.AddWithValue("Estatus", false);

                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex) 
                {
                    respuesta = false;
                }

            }
            respuesta = TipoPropiedad.Instancia.Eliminar(id);
            return Json(new { respuesta = respuesta }, JsonRequestBehavior.AllowGet);
        }

    }
}