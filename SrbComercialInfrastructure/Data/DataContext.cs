using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SrbComercialDomain.Entities;
using static SrbComercialInfrastructure.Data.DataContext;


namespace SrbComercialInfrastructure.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {          
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set;}
        public DbSet<Client> Clients {get; set;}
        public DbSet<State> States {get; set;}
        public DbSet<City> Cities {get; set;}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
            
            modelBuilder.Entity<Supplier>()
                .HasOne(s => s.City)
                .WithMany()
                .HasForeignKey(s => s.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Client>()
                .HasOne(s => s.City)
                .WithMany()
                .HasForeignKey(s => s.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<City>()
                    .HasOne(c => c.State) // Cada cidade tem um estado
                    .WithMany(s => s.Cities) // Um estado tem muitas cidades
                    .HasForeignKey(c => c.StateId) // Chave estrangeira na tabela Cities
                    .OnDelete(DeleteBehavior.Cascade); // Comportamento ao deletar (cascata)          
        }



       
    }


}
