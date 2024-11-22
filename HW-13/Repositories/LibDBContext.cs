using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_13.Entities;
using HW_13.Configs;

namespace HW_13.Repositories
{
    public class LibDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-03R7JG5\\SQLEXPRESS; Database=Libarary;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdminConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
        public DbSet<Admin> Admins{ get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Book> books { get; set; }
    }
}
