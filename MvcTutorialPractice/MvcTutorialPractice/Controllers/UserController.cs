using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTutorialPractice.Models.DbProcedure;
using MvcTutorialPractice.Models.DbTable;

namespace MvcTutorialPractice.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario Usuario)
        {
            DbEngine Funcion = new DbEngine();
            Int32 Id = Funcion.SeleccionarIdUsuario(Usuario);
            if (Id == 0)
            {
                return View();
            }
            return View("Factura");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterData Usuario)
        {
            DbEngine Funcion = new DbEngine();
            Int32 Id = Funcion.InsertarUsuario(Usuario);
            if (Id == 0)
            {
                return View();
            }
            return View("Login");
        }
    }
}