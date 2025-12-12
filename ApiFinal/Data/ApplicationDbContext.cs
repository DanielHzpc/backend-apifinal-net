
using ApiEmpresa.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpresa.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }


        public DbSet<User> Users { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Servicio> Servicio { get; set; }

        public DbSet<ReservaServicio> ReservaServicio { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ReservaServicio>()
                .HasKey(rs => new { rs.ReservaId, rs.ServicioId });

            modelBuilder.Entity<ReservaServicio>()
                .HasOne(rs => rs.Reserva)
                .WithMany(r => r.ReservaServicio)
                .HasForeignKey(rs => rs.ReservaId);

            modelBuilder.Entity<ReservaServicio>()
                .HasOne(rs => rs.Servicio)
                .WithMany(s => s.ReservaServicio)
                .HasForeignKey(rs => rs.ServicioId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Cliente)
                .WithMany()
                .HasForeignKey(r => r.IdCliente);

        }

    }
}
