using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSetting.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Users = new UsersRepository(context);
        }


        public void Complete()
        {
            _context.SaveChanges();
        }



        public void Dispose()
        {
            _context.Dispose();
        }


        public IUsersRepository Users { get; private set; }
    }
}
