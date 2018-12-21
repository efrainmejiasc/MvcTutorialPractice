using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult InitLogin(LoginData Usuario)
        {
            return View();
        }
    }
}