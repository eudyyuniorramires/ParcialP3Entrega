using ParcialP3Entrega.Models.ViewModels;
using PSC08.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ParcialP3Entrega.Controllers
{
    public class InmueblesController : Controller
    {
        private InmueblesMetodo _inmueblesMetodo = new InmueblesMetodo();

        public ActionResult Inmuebles()
        {
            return View();
        }


        [HttpGet]
        public JsonResult Listar()
        {
            var lista = _inmueblesMetodo.Listar();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        //public JsonResult Registrar(InmueblesViewModels _obj)
        //{
        //    var respuesta = _inmueblesMetodo.Insertar(_obj);
        //    return Json(new { ok = respuesta });
        //}


        [HttpPost]
        public JsonResult Actualizar(InmueblesViewModels _obj)
        {
            var respuesta = _inmueblesMetodo.Actualizar(_obj);
            return Json(new { ok = respuesta });
        }

        [HttpPost]
        public JsonResult Eliminar(int id)
        {
            var respuesta = _inmueblesMetodo.Eliminar(id);
            return Json(new { ok = respuesta });
        }

        [HttpGet]
        public JsonResult ListarTipoPropiedad()
        {
            var lista = _inmueblesMetodo.ListarTipoPropiedad();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ListarCondiciones()
        {
            var lista = _inmueblesMetodo.ListarCondiciones();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult ListarCiudades()
        {
            var lista = _inmueblesMetodo.ListarCiudades();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult SubirImagen(int idInmueble) 
        {
            bool ok = false;

            try
            {
                if (Request.Files.Count > 0) 
                {
                    HttpPostedFileBase archivo = Request.Files[0];
                    using (var ms = new System.IO.MemoryStream()) 
                    {
                        archivo.InputStream.CopyTo(ms);
                        byte[] data = ms.ToArray();
                    
                        InmueblesMetodo met = new InmueblesMetodo();
                        ok = met.InsertarImagen(idInmueble, data);
                    }                
                }
            }
            catch (Exception ex) 
            {
                return Json(new { ok = true, message = ex.Message});
            }

            return Json(new { ok = ok});
        }


        [HttpGet]
        public JsonResult ListarImagenes(int idinmuebles) 
        {
            var lista = _inmueblesMetodo.ListarImagenes(idinmuebles).Select(e => new 
            {
                e.IdFoto,
                ImagenBase64 = Convert.ToBase64String(e.Imagen)
            });
            
            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ObtenerPorId(int id) 
        { 
             bool ok = false;
            try
            {
                var inmueble = _inmueblesMetodo.ObtenerPorId(id);
                if (inmueble is null) 
                {
                    return Json(new {ok, message = "Inmueble no encontrado palomo." }, JsonRequestBehavior.AllowGet);
                }

                return Json(inmueble, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception ex) 
            {
                return Json(new { ok = true, message = ex.Message });
            }
        }
    }
}