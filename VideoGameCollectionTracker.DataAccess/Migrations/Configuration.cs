using System.Data.Entity.Migrations;
using VideoGameCollectionTracker.Model;

namespace VideoGameCollectionTracker.DataAccess.Migrations
{
  internal sealed class Configuration : DbMigrationsConfiguration<VideoGameCollectionTrackerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VideoGameCollectionTrackerDbContext context)
        {
      context.VideoGameSystems.AddOrUpdate(vgs => vgs.Name,
        new VideoGameSystem { Name = "Nintendo Entertainment System" },
        new VideoGameSystem { Name = "Super Nintendo Entertainment System" },
        new VideoGameSystem { Name = "Nintendo 64" });
        }
    }
}
