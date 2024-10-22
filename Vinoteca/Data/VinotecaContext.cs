using Microsoft.EntityFrameworkCore;
using System;
using Vinoteca.Entities;

namespace Vinoteca.Data
{
    public class VinotecaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wine> Wines { get; set; }

        public VinotecaContext(DbContextOptions<VinotecaContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User luis = new User()
            {

                Id = 1,
                UserName = "Luis",
                Password = "lamismadesiempre",

            };

            Wine malbec = new Wine()
            {
                Id = 1,
                Variety = "Don savignon",
                Stock = 30,
                Year = 100,
                Region = "Chaco",
                CreatedAt = DateTime.Now,

            };

            modelBuilder.Entity<User>().HasData(
                luis);

            modelBuilder.Entity<Wine>().HasData(
                malbec);

            modelBuilder.Entity<Cata>()
      .HasMany(c => c.Vinos)
      .WithOne(w => w.Cata)
      .HasForeignKey(w => w.CataId);
            base.OnModelCreating(modelBuilder);
        }


    }
}
