using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EnvironmentSetting.ViewModel;

namespace EnvironmentSetting.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Registration(UserViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}