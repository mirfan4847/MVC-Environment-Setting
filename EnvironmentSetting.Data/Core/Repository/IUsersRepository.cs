using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnvironmentSetting.Model;

namespace EnvironmentSetting.Data
{
    public interface IUsersRepository : IRepository<Users>
    {
        IEnumerable<Users> GetAllUsers();
    }
}
