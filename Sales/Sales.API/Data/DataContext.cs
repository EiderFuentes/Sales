using Microsoft.EntityFrameworkCore;
using Sales.Shared.Entites;

namespace Sales.API.Data
{
    //Herredamos de la clase DbContext 
    public class DataContext : DbContext
    {
        //Creamos el constructor para conectanos a la base de datos
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //Mapear mis tablas o entidades
        public DbSet<Country> Countries { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        //Creamos un indice para los nombre de los paises
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Creamos los indices en la base de datos
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
            //Creamos indices compuestos 
            modelBuilder.Entity<State>().HasIndex("CountryId", "Name").IsUnique();
            modelBuilder.Entity<City>().HasIndex("StateId", "Name").IsUnique();
        }
    }
}
