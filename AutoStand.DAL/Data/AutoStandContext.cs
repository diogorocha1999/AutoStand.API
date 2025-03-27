// AutoStand.DAL/Data/AutoStandContext.cs
using AutoStand.BOL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoStand.DAL.Data
{
    public class AutoStandContext : DbContext
    {
        public AutoStandContext(DbContextOptions<AutoStandContext> options) : base(options) { }

        // Adicione esta linha para o inventário
        public DbSet<InventoryMovement> InventoryMovements { get; set; }

        // Mantenha os outros DbSets existentes
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração para InventoryMovement
            modelBuilder.Entity<InventoryMovement>()
                .HasOne(im => im.Vehicle)
                .WithMany()
                .HasForeignKey(im => im.VehicleId);

            // Mantenha as outras configurações existentes
            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Vehicle)
                .WithMany()
                .HasForeignKey(s => s.VehicleId);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany()
                .HasForeignKey(s => s.CustomerId);
        }
    }
}