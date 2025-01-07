using Microsoft.EntityFrameworkCore;
using RestaurantWebApi.Core.Domain.Entities;

namespace RestaurantWebApi.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region tables
            modelBuilder.Entity<Dish>().ToTable("Dishes");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredients");
            modelBuilder.Entity<Table>().ToTable("Tables");
            modelBuilder.Entity<Order>().ToTable("Orders");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Dish>().HasKey(d => d.Id);
            modelBuilder.Entity<Ingredient>().HasKey(i => i.Id);
            modelBuilder.Entity<Table>().HasKey(t => t.Id);
            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            #endregion

            #region relationships
            modelBuilder.Entity<Dish>()
                .HasMany<Ingredient>(d => d.Ingredients)
                .WithMany(i => i.Dishes)
                .UsingEntity(j => j.ToTable("DishIngredients"));

            modelBuilder.Entity<Order>()
                .HasMany<Dish>(o => o.Dishes)
                .WithMany(d => d.Orders)
                .UsingEntity(j => j.ToTable("OrderDishes"));

            modelBuilder.Entity<Table>()
                .HasMany<Order>(t => t.Orders)
                .WithOne(o => o.Table)
                .HasForeignKey(o => o.TableId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "property configurations"

            #region dishes
            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Price)
                .IsRequired()
                .HasPrecision(10, 2);

            modelBuilder.Entity<Dish>()
                .Property(d => d.ForHowManyPeople)
                .IsRequired();

            modelBuilder.Entity<Dish>()
                .Property(d => d.CategoryId)
                .IsRequired();
            #endregion

            #region ingredients
            modelBuilder.Entity<Ingredient>()
                .Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);
            #endregion

            #region tables
            modelBuilder.Entity<Table>()
                .Property(t => t.Capacity)
                .IsRequired();

            modelBuilder.Entity<Table>()
                .Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Table>()
                .Property(t => t.StatusId)
                .IsRequired();
            #endregion

            #region orders
            modelBuilder.Entity<Order>()
                .Property(o => o.Subtotal)
                .IsRequired()
                .HasPrecision(10, 0);

            modelBuilder.Entity<Order>()
                .Property(d => d.StatusId)
                .IsRequired();
            #endregion

            #endregion
        }
    }
}
