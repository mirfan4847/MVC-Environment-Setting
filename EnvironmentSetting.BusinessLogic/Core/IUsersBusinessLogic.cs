using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnvironmentSetting.ViewModel;

namespace EnvironmentSetting.BusinessLogic
{
    public interface IUsersBusinessLogic
    {
        bool AddUser(UserViewModel model);

        bool Registration(UserViewModel model);

        IEnumerable<UserViewModel> GetAllUsers();
    }
}
