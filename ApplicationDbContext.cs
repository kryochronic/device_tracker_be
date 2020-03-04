using Microsoft.EntityFrameworkCore;

namespace vue_dotnet_mvc {
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<DeviceRecord> DeviceRecords { get; set; }
  }
}