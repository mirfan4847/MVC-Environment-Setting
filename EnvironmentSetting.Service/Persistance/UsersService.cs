using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnvironmentSetting.BusinessLogic;
using EnvironmentSetting.ExceptionManager;
using EnvironmentSetting.ViewModel;

namespace EnvironmentSetting.Service
{
    public class UsersService : IUsersService
    {
        private readonly IUsersBusinessLogic _usersBusinessLogic;

        public UsersService(IUsersBusinessLogic usersBusinessLogic)
        {
            _usersBusinessLogic = usersBusinessLogic;
        }

        public bool AddUser(UserViewModel model)
        {
            try
            {
                return
                    _usersBusinessLogic.AddUser(model);
            }
            catch (Exception ex)
            {
                CustomException.WriteExceptionMessageToFile(ex.Message, ex);
                return false;
            }
        }

        public bool Registration(UserViewModel model)
        {
            try
            {
                return
                   _usersBusinessLogic.Registration(model);
            }
            catch (Exception ex)
            {
                CustomException.WriteExceptionMessageToFile(ex.Message, ex);
                return false;
                throw;
            }
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            try
            {
                return
                    _usersBusinessLogic.GetAllUsers();
            }
            catch (Exception ex)
            {
                CustomException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }
    }
}
