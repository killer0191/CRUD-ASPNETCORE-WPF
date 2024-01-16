using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Persona>().HasKey(a => a.IdPersona);
            modelBuilder.Entity<Factura>().HasKey(b => b.IdFactura);

            // Configura la relación uno a muchos entre Persona y Factura
            modelBuilder.Entity<Factura>()
                .HasOne<Persona>()
                .WithMany(persona => persona.Facturas)
                .HasForeignKey(factura => factura.IdPersona)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
