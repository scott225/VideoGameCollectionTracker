using VideoGameCollectionTracker.DataAccess;

namespace VideoGameCollectionTracker.UI.Data.Repositories
{
  public class BaseRepository
  {
    protected VideoGameCollectionTrackerDbContext DbContext;

    public BaseRepository(VideoGameCollectionTrackerDbContext dbContext)
    {
      DbContext = dbContext;
    }
  }
}
