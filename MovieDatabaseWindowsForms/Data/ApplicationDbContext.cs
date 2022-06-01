using Microsoft.EntityFrameworkCore;
using MovieDatabaseWindowsForms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabaseWindowsForms.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {          
                optionsBuilder.UseSqlServer("Server=DESKTOP-AFN6KTM;Database=MovieDatabase;Trusted_Connection=True");
            }
        }
    }    
}
