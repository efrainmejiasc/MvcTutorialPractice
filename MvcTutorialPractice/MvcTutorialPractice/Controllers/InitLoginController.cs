using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using MvcTutorialPractice.Models;

namespace MvcTutorialPractice.Controllers
{
    public class Login_UserController : Controller
    {
    
        public ActionResult InitLogin()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult InitLogin(Usuarios Usuario)
        {
            EngineDB Funcion = new EngineDB();
            Int32 Id = Funcion.SeleccionarIdUsuario(Usuario);
            if (Id == 0)
            { 
             return View();
            }
            return View("CellPhonePage");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterData Usuario)
        {
            Int32 Id = EngineDB.InsertarUsuario(Usuario);
            if (Id == 0)
            {
                return View();
            }
            return View("InitLogin");
        }


        public ActionResult CellPhonePage()
        {
            ShowData Funcion = new ShowData();
            List<ShowData.Telefono> ListaTelefono = new List<ShowData.Telefono>();
            ListaTelefono = Funcion.ListaTelefono();
            return View(ListaTelefono);
        }

    }
}