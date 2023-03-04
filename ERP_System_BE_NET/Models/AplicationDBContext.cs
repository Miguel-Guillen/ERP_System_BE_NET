using Microsoft.EntityFrameworkCore;
using ERP_System_BE_NET.Models;

namespace ERP_System_BE_NET.Models
{
    public class AplicationDBContext: DbContext
    {
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options): base(options)
        {

        }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<ERP_System_BE_NET.Models.Areas> Areas { get; set; }
    }
}
