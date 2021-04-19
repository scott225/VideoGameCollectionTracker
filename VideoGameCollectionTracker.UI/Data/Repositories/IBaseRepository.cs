using System.Collections.Generic;
using System.Threading.Tasks;

namespace VideoGameCollectionTracker.UI.Data.Repositories
{
  public interface IBaseRepository<T>
  {
    Task<List<T>> GetAllAsync();
    Task<T> GetById(int id);
    Task SaveAsync();
    void Delete(T model);
    bool HasChanges();
    Task ReloadAsync(T model);
    void Add(T model);
  }
}