using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParcialP3Entrega.Models;

namespace ParcialP3Entrega.Controllers
{
    public class AccederController : Controller
    {
        // GET: Acceder
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Enter(string _usuario, string _password)
        {
            // Validar si los parámetros son nulos o vacíos
            if (string.IsNullOrEmpty(_usuario) || string.IsNullOrEmpty(_password))
            {
                return Content("El usuario y la contraseña son obligatorios.");
            }

            using (DBMVCEntities db = new DBMVCEntities())
            {
                // Convertir el correo a minúsculas para evitar problemas de mayúsculas/minúsculas
                string usuarioLower = _usuario.ToLower();

                // Encriptar la contraseña si es necesario (ejemplo con SHA256)
                string passwordHash = _password; // Reemplaza con la lógica de encriptación si aplica

                var _read = from d in db.USERS
                            where d.Email.ToLower() == usuarioLower
                            && d.Password == passwordHash
                            && d.idEstatus == 1
                            select d;

                if (_read.Any()) // Cambié Count() > 0 por Any() para mejor rendimiento
                {
                    Session["Usuario"] = _read.First();
                    return Content("1");
                }
                else
                {
                    return Content("Revisa el Usuario y la clave de usuario");
                }
            }
        }
    }
}
