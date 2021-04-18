using System.Collections.Generic;
using System.Threading.Tasks;
using VideoGameCollectionTracker.DataAccess;

namespace VideoGameCollectionTracker.UI.Data.Repositories
{
  public abstract class BaseRepository<T> : IBaseRepository<T>
  {
    protected VideoGameCollectionTrackerDbContext DbContext;

    public BaseRepository(VideoGameCollectionTrackerDbContext dbContext)
    {
      DbContext = dbContext;
    }

    public async Task SaveAsync()
    {
      await DbContext.SaveChangesAsync();
    }

    public abstract Task<List<T>> GetAllAsync();

    public abstract Task<T> GetById(int id);
  }
}
