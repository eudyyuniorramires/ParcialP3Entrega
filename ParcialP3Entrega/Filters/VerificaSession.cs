using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParcialP3Entrega.Models;
using ParcialP3Entrega.Controllers;
using System.Web.Mvc;



namespace ParcialP3Entrega.Filters
{
    public class VerificaSession : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var miUsuario = (USER)HttpContext.Current.Session["Usuario"];

            if (miUsuario == null)
            {

                if (filterContext.Controller is AccederController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Acceder/Login");
                }
            }
            else 
            {
                if (filterContext.Controller is AccederController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }


            }
            base.OnActionExecuting(filterContext);
        }
    }
}