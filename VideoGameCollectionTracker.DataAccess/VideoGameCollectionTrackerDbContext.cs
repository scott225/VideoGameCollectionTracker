using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using VideoGameCollectionTracker.Model;

namespace VideoGameCollectionTracker.DataAccess
{
  public class VideoGameCollectionTrackerDbContext : DbContext
  {
    public DbSet<VideoGameSystem> VideoGameSystems { get; set; }

    public VideoGameCollectionTrackerDbContext() : base("VideoGameCollectionTrackerDb")
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
  }
}
