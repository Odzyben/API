using Microsoft.EntityFrameworkCore;

namespace CustomerServerAPI.Models
{
    public class Context : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json")
        //            .Build();
        //        var connectionString = configuration.GetConnectionString("DefaulConnection");
        //        _ = optionsBuilder.UseSqlServer(connectionString);
        //    }
        //}

        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
