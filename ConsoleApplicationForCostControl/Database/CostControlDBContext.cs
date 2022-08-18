using ConsoleApplicationForCostControl.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplicationForCostControl.Database
{
    public class CostControlDBContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Cost> Costs { get; set; }
        public virtual DbSet<Category> Categories { get; set; }


        public CostControlDBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\matil\\source\\repos\\ConsoleApplicationForCostControl\\ConsoleApplicationForCostControl\\Database\\CostControlDB.mdf;Integrated Security=True");
            }
        }
    }
}
