using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindReactApp.Infrastructure.Data
{
    public static class DbContextExtensions
    {
        public static async Task CheckDbConnectionAsync(this IServiceProvider serviceProvider)      // this makes CheckDbConnectionAsync as an extension for IServiceProvider.  Extension methods allow you to "add" methods to existing types without modifying the original type or using inheritance
        {
            using var scope = serviceProvider.CreateScope();    // Scopes are needed to manage the lifetime of dependencies (service provider)
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();   // Get the ApplicationDbContext from the service provider
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<ApplicationDbContext>>(); // Get the ILogger from the service provider

            try
            {
                if (await dbContext.Database.CanConnectAsync())
                {
                    logger.LogInformation("Database connection is successful.");
                }
                else
                {
                    logger.LogError("Database connection failed.");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while checking the database connection.");
            }
        }
    }
}
