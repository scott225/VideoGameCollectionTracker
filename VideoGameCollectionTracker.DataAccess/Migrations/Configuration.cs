using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
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

      context.Genres.AddOrUpdate(g => g.Name,
        new Genre { Name = "Platformer" },
        new Genre { Name = "RPG" },
        new Genre { Name = "Sports" });

      context.SaveChanges();

      context.VideoGames.AddOrUpdate(vg => vg.Name,
        new VideoGame
        {
          Name = "Super Mario Bros.",
          Systems = new Collection<VideoGameSystem>()
          {
            context.VideoGameSystems.First()
          },
          Genres = new Collection<Genre>()
          {
            context.Genres.First()
          }

        },
        new VideoGame
        {
          Name = "The Legend of Zelda",
          Systems = new Collection<VideoGameSystem>()
          {
            context.VideoGameSystems.First()
          },
          Genres = new Collection<Genre>()
          {
            context.Genres.First()
          }
        },
        new VideoGame
        {
          Name = "Metroid",
          Systems = new Collection<VideoGameSystem>()
          {
            context.VideoGameSystems.First()
          },
          Genres = new Collection<Genre>()
          {
            context.Genres.First()
          }
        }); ;
    }
  }
}
