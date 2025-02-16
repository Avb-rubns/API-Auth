
namespace Rubns.Infrastructure.Persistence
{
    public class ApplicationDbContextEFC : DbContext
    {
        public ApplicationDbContextEFC(DbContextOptions<ApplicationDbContextEFC> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
