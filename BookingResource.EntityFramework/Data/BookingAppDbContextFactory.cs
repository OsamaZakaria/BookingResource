using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BookingResource.EntityFramework.Data
{
    public class BookingAppDbContextFactory : IDesignTimeDbContextFactory<BookingAppDbContext>
    {
        public BookingAppDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();
            var builder = new DbContextOptionsBuilder<BookingAppDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new BookingAppDbContext(builder.Options, new OperationalStoreOptionsMigrations());
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
    public class OperationalStoreOptionsMigrations : IOptions<OperationalStoreOptions>
    {
        public OperationalStoreOptions Value => new OperationalStoreOptions()
        {
            DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
            EnableTokenCleanup = false,
            PersistedGrants = new TableConfiguration("PersistedGrants"),
            TokenCleanupBatchSize = 100,
            TokenCleanupInterval = 3600,
        };
    }
}
