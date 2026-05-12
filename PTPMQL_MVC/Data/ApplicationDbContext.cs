using Microsoft.EntityFrameworkCore;
using PTPMQL_MVC.Models.Entities;

namespace PTPMQL_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
    public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
    {}
        public DbSet<PTPMQL_MVC.Models.Entities.Employee> Employee { get; set; } = default!;
        public DbSet<PTPMQL_MVC.Models.Entities.Student> Students { get; set; } = default!;
        public DbSet<PTPMQL_MVC.Models.Entities.Faculty> Faculties { get; set; } = default!;
        public DbSet<PTPMQL_MVC.Models.Entities.Supplier> Suppliers { get; set; } = default!;
        public DbSet<PTPMQL_MVC.Models.Entities.DeviceCategory> DeviceCategorys { get; set; } = default!;
        public DbSet<PTPMQL_MVC.Models.Entities.Device> Devices { get; set; } = default!;
        public DbSet<PTPMQL_MVC.Models.Entities.ImportReceipt> ImportReceipts { get; set; } = default!;
        public DbSet<PTPMQL_MVC.Models.Entities.ImportDetail> ImportDetails { get; set; } = default!;
        public DbSet<PTPMQL_MVC.Models.Entities.ExportReceipt> ExportReceipts { get; set; } = default!;
        public DbSet<PTPMQL_MVC.Models.Entities.ExportDetail> ExportDetails { get; set; } = default!;
    }
} 