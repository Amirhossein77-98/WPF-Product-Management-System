using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace DataAccess
{
    public class AppDBContext : DbContext
    {
        public DbSet<Product> Products {get;set;}
        public DbSet<Employee> Employees {get;set;}
        public DbSet<Customer> Customers {get;set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseMySql("server=localhost;database=management_system;user=root;password=root", new MySqlServerVersion(new Version(8, 0, 38)));
        }
    }
}
