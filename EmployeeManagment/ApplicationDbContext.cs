using EmployeeManagment.Models;
using EmployeeManagment.Models.ViewModels;
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
        public DbSet<CatalogoPuesto> CatalogoPuestos { get; set; }
        public DbSet<CatalogoCentro> CatalogoCentros { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Directivo> Directivos { get; set; }
        public DbSet<ReporteEmpleadosViewModel> ReporteEmpleados { get; set; }
        #endregion

        #region Configuraciones de las Entidades

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CATALOGO_PUESTOS
            modelBuilder.Entity<CatalogoPuesto>(entity =>
            {
                entity.ToTable("CATALOGO_PUESTOS");
                entity.HasKey(e => e.IdPuesto).HasName("PK_CATALOGO_PUESTOS");
                entity.Property(e => e.IdPuesto).HasColumnName("ID_Puesto");
                entity.Property(e => e.DescripcionPuesto)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Descripcion_Puesto");
            });

            // CATALOGO_CENTROS
            modelBuilder.Entity<CatalogoCentro>(entity =>
            {
                entity.ToTable("CATALOGO_CENTROS");
                entity.HasKey(e => e.IdCentro).HasName("PK_CATALOGO_CENTROS");
                entity.Property(e => e.IdCentro).HasColumnName("ID_Centro");
                entity.Property(e => e.NombreCentro)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Nombre_Centro");
                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Ciudad");
            });

            // EMPLEADOS
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("EMPLEADOS");
                entity.HasKey(e => e.IdEmpleado).HasName("PK_EMPLEADOS");
                entity.Property(e => e.IdEmpleado).HasColumnName("ID_Empleado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Nombre");
                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Apellido_Paterno");
                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Apellido_Materno");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("Fecha_Nacimiento");
                entity.Property(e => e.RFC)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("RFC");
                entity.HasIndex(e => e.RFC).IsUnique();

                entity.Property(e => e.CentroTrabajo).HasColumnName("Centro_Trabajo");
                entity.Property(e => e.IdPuesto).HasColumnName("ID_Puesto");
                entity.Property(e => e.EsDirectivo).HasColumnName("Es_Directivo");

                entity.HasOne(e => e.Puesto)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(e => e.IdPuesto)
                    .HasConstraintName("FK_Empleados_Puesto")
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.CentroTrabajoNavigation)
                    .WithMany(c => c.Empleados)
                    .HasForeignKey(e => e.CentroTrabajo)
                    .HasConstraintName("FK_Empleados_Centro")
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // DIRECTIVOS
            modelBuilder.Entity<Directivo>(entity =>
            {
                entity.ToTable("DIRECTIVOS");
                entity.HasKey(d => d.IdEmpleado).HasName("PK_DIRECTIVOS");
                entity.Property(d => d.IdEmpleado).HasColumnName("ID_Empleado");
                entity.Property(d => d.CentroSupervisado).HasColumnName("Centro_Supervisado");
                entity.Property(d => d.PrestacionCombustible).HasColumnName("Prestacion_Combustible");

                entity.HasOne(d => d.Empleado)
                    .WithOne(e => e.Directivo)
                    .HasForeignKey<Directivo>(d => d.IdEmpleado)
                    .HasConstraintName("FK_Directivos_Empleado")
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.CentroSupervisadoNavigation)
                    .WithMany(c => c.DirectivosSupervisores)
                    .HasForeignKey(d => d.CentroSupervisado)
                    .HasConstraintName("FK_Directivos_Centro")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ReporteEmpleadosViewModel (keyless)
            modelBuilder.Entity<ReporteEmpleadosViewModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToView(null);
            });
        }
        #endregion
    }
}
