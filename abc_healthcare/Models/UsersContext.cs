using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace abc_healthcare.Models
{
    public class UsersContext:DbContext
    {
        public UsersContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Users> Userss { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
