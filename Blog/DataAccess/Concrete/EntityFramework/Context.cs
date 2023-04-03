using Core.Entities.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class Context : DbContext
    {
        public Context() { }
        //public Context(DbContextOptions options) : base(options) { }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=77.245.159.8,1433;Database=coresnippetsDB;User Id=coresnippets;Password=softdev.864;");
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BlogDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        public override int SaveChanges()
        {
            var dataEntries = ChangeTracker.Entries<BaseEntity<object>>();
            foreach (var data in dataEntries)
            {
                switch (data.State)
                {
                    case EntityState.Detached: break;
                    case EntityState.Unchanged: break;
                    case EntityState.Deleted: break;
                    case EntityState.Modified: data.Entity.EditDate = DateTime.Now; break;
                    case EntityState.Added: data.Entity.CreateDate = DateTime.Now; break;
                }
            }
            return base.SaveChanges();
        }
    }
}
