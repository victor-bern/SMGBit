using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SMGBit.Infra.Context;

namespace SMGBit.Application.Extensions
{
    public static class DatabaseExtension
    {
        public static void MigrateDatabase(this IHost host)
        {
            using var scope = host.Services.CreateScope();

            var databaseService = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
            try
            {
                databaseService.Database.Migrate();
            }
            catch
            {
                throw;
            }

        }
    }
}
