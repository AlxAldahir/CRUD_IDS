using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=TiendaKamil;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        #region DbSets<>

        #endregion
    }
}
