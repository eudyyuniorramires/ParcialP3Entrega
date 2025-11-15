<<<<<<< HEAD
﻿using ParcialP3Entrega.Metodos;
=======
﻿using ParcialP3Entrega.Clases;
using ParcialP3Entrega.Metodos;
>>>>>>> 0ee7a87827df00b10d283e31fa251dc1c79bee47
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
        public TipoPropiedadController()
        {
            if (System.Web.HttpContext.Current.Session["Usuario"] == null)
            {
                System.Web.HttpContext.Current.Response.Redirect("/Home/Index");
            }
        }

        [HttpGet]
        public JsonResult ConsultaTipoPropiedad()
        {
            List<TipoPropiedad> _oTP = new List<TipoPropiedad>();
            _oTP = TipoPropiedadMetodo.Instancia.Lista();
            return Json(new { _oTP}, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GuardarTipoPropiedad(TipoPropiedad oTP)
        {
            bool respuesta = false;

            respuesta = (oTP.IdTipoPropiedad == 0)
                ? TipoPropiedadMetodo.Instancia.Registrar(oTP)
                : TipoPropiedadMetodo.Instancia.Modificar(oTP);
            string mensaje = string.Empty;
           
            return Json(new { respuesta = respuesta}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public bool Eliminar(int id)
        {
            bool respuesta = true;
<<<<<<< HEAD
            using (SqlConnection cxn = new SqlConnection()) 
=======
            using (SqlConnection cxn = new SqlConnection(cnn.db)) 
>>>>>>> 0ee7a87827df00b10d283e31fa251dc1c79bee47
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
                catch (Exception)
                {
                    respuesta = false;
                }
            }
            respuesta = TipoPropiedadMetodo.Instancia.Eliminar(id);
            return true;
        }
    }
}