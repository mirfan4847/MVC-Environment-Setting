using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentSetting.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository Users { get; }

        #region Methods
        void Complete();

        #endregion
    }
}
