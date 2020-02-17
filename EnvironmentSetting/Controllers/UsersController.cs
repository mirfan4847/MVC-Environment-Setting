using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EnvironmentSetting.Service;
using EnvironmentSetting.ViewModel;
using EnvironmentSetting.ExceptionManager;

namespace EnvironmentSetting.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService _userService;

        public UsersController(IUsersService userService)
        {
            _userService = userService;
        }
        public ActionResult Index()
        {
            var data = _userService.GetAllUsers();
            return View("GetAllUsers", data);
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userService.AddUser(model);
                }
                return View();
            }
            catch (Exception ex)
            {
                CustomException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }

        }

        public ActionResult GetAllUsers()
        {
            return View();
        }

    }
}