
namespace Rubns.Infrastructure.Persistence
{
    public class AuthDbContextEFC : DbContext
    {
        public AuthDbContextEFC(DbContextOptions<AuthDbContextEFC> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

    }
}
