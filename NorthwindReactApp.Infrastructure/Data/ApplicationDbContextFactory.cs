using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace NorthwindReactApp.Infrastructure.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../NorthwindReactApp.Server");    // Because appsettings.json is in server project

            var configuration = new ConfigurationBuilder()      // Needed to read appsettings.json
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString, b => b.MigrationsAssembly("NorthwindReactApp.Infrastructure"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}

// This is needed for:
//      dotnet ef migrations
//      add and dotnet ef database update

/* An instance of ApplicationDbContext is neeeded to access the db and run the migrations .
    IMPORTANT: This is different from the program.cs coz that one is needed to set up DI to access it through the entire application.
    This on the other hand is needed for:
        Needed by EF Core tools to create an instance of the DbContext outside the application's runtime environment, primarily for running migrations and updates
 */