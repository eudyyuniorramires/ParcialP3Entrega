using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParcialP3Entrega.Controllers
{
    public class CerrarSessionController : Controller
    {
        // GET: CerrarSession
        public ActionResult LogoOff()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Login", "Acceder");
        }
    }
}