using System.Collections.Generic;
using System.Threading.Tasks;

namespace VideoGameCollectionTracker.UI.Data.Repositories
{
  public interface IBaseRepository<T>
  {
    Task<List<T>> GetAllAsync();
    Task<T> GetById(int id);
    Task SaveAsync();
  }
}