using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.Diagnostics;
using EnvironmentSetting.Model;

namespace EnvironmentSetting.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
            Database.SetInitializer<ApplicationDbContext>(null);
            Database.Log = sql => Debug.Write(sql);
        }
        public virtual DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UsersConfiguration());
        }
    }
}
