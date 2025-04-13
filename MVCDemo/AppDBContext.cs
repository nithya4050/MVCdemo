using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCDemo.Models;

namespace MVCDemo
{
    public class AppDBContext :DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { 
        
        
        }
       

    }
}
