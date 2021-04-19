using System.Collections.Generic;
using System.Threading.Tasks;
using VideoGameCollectionTracker.DataAccess;

namespace VideoGameCollectionTracker.UI.Data.Repositories
{
  public abstract class BaseRepository<T> : IBaseRepository<T> where T:class
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

    public void Delete(T model)
    {
      DbContext.Set<T>().Remove(model);
    }

    public bool HasChanges()
    {
      return DbContext.ChangeTracker.HasChanges();
    }

    public async Task ReloadAsync(T model)
    {
      await DbContext.Entry(model).ReloadAsync();
    }

    public void Add(T model)
    {
      DbContext.Set<T>().Add(model);
    }
  }
}
