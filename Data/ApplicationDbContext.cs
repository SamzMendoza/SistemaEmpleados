using Microsoft.EntityFrameworkCore;
using SistemaEmpleados.Models;

namespace SistemaEmpleados.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<Subarea> SubAreas { get; set; }

    }
}
