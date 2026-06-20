using Microsoft.EntityFrameworkCore;
using PTPMQL_MVC.Models.Entities;


namespace PTPMQL_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set;}
        public DbSet<Faculty> Faculties { get; set;}
        public DbSet<Customer> Customer { get; set; } = default!;
        public DbSet<Order> Order { get; set; } = default!;
        public DbSet<OrderDetail> OrderDetail { get; set; } = default!;
        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<PTPMQL_MVC.Models.Entities.Device> Device { get; set; } = default!;
        public DbSet<PTPMQL_MVC.Models.Entities.DeviceCategory> DeviceCategory { get; set; } = default!;
        public DbSet<PTPMQL_MVC.Models.Entities.ExportReceipt> ExportReceipt { get; set; } = default!;
        public DbSet<PTPMQL_MVC.Models.Entities.ImportReceipt> ImportReceipt { get; set; } = default!;
        public DbSet<PTPMQL_MVC.Models.Entities.Supplier> Supplier { get; set; } = default!;
      }
}