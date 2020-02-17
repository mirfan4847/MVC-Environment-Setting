using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnvironmentSetting.Model;
using EnvironmentSetting.ExceptionManager;

namespace EnvironmentSetting.Data
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {

        public UsersRepository(ApplicationDbContext context)
            : base(context)
        {

        }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return _Context; }
        }

        public IEnumerable<Users> GetAllUsers()
        {
            try
            {
                var result = _Context.Users.Where(x => x.Active == true).ToList();
                return result;
            }
            catch (Exception ex)
            {
                CustomException.WriteExceptionMessageToFile(ex.Message, ex);
                return null;
            }
        }
    }
}
