using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.Entity.ModelConfiguration;

namespace EnvironmentSetting.Model
{
    public class UsersConfiguration : EntityTypeConfiguration<Users>
    {
        public UsersConfiguration()
        {
            ToTable("Users");
            HasKey(x => new { x.UserID });
        }
    }
}
