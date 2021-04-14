using System.Collections.Generic;
using System.Threading.Tasks;
using VideoGameCollectionTracker.Model;

namespace VideoGameCollectionTracker.UI.Data.Repositories
{
  public interface ILookupItemRepository
  {
    Task<IEnumerable<LookupItem>> GetVideoGameSystemsAsync();
  }
}