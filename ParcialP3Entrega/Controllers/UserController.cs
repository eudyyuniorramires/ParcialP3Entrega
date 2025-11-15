using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using ParcialP3Entrega.Models;
using ParcialP3Entrega.Models.ViewModels;

namespace ParcialP3Entrega.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Query()
        {
            List<QueryViewModels> lst = null; //La creacion del objeto que tiene la data 

            using (DBMVCEntities DB = new DBMVCEntities()) 
            {

                lst = (from d in DB.USERS
                       where d.idEstatus == 1
                       orderby d.Email



                       select new QueryViewModels
                       {
                           _Email = d.Email,
                           _Edad = d.Edad,
                           _Id = d.ID

                       }).ToList();
            }
                return View(lst); //Mandar la data a la vista
        }

                [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Add(AddUserViewModels model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new DBMVCEntities())
            {
                USER ou = new USER();
                ou.idEstatus = 1;
                ou.Edad = model._Edad;
                ou.Password = model._Clave;
                ou.Nombre = model._Nombre;
                ou.Email = model._Correo;

                db.USERS.Add(ou);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/Query"));
        }

        [HttpGet]
        public ActionResult Edit(int _Id)
        {
            EditUserViewModels model = new EditUserViewModels();

            using (var db = new DBMVCEntities())
            {
                var ou = new DBMVCEntities().USERS.Find(_Id);
               model._Nombre = ou.Nombre;
               model._Clave = ou.Password;
               model._Correo = ou.Email;
               model._Edad = ou.Edad;
               model._Id = ou.ID;

                return View(model);
            }

        }

        [HttpPost]

        public ActionResult Edit(EditUserViewModels model)
        {
            using (var db = new DBMVCEntities())
            {
                var ou = db.USERS.Find(model._Id);
                ou.Nombre = model._Nombre;
                ou.Email = model._Correo;
                ou.Edad = model._Edad;

                if (model._Clave != null || model._Clave != "")
                {
                    ou.Password = model._Clave;
                }
                db.Entry(ou).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/User/Query"));
        }

        [HttpPost]
         public ActionResult BorrarRegistro(int ID)
        {
            using (var db = new DBMVCEntities())
            {
                var ou = db.USERS.Find(ID);
                ou.idEstatus = 3;
                db.Entry(ou).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }
                return Content("1");
         }

    }


}

