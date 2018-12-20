using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcTutorialPractice.Controllers
{
    public class Login_UserController : Controller
    {
        // GET: Init
        public ActionResult InitLogin()
        {
            return View();
        }
    }
}