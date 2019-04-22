using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_exercise
{
    public class UsersContext : DbContext
    {
        public UsersContext() : base()
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
