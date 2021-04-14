using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VideoGameCollectionTracker.DataAccess;
using VideoGameCollectionTracker.Model;

namespace VideoGameCollectionTracker.UI.Data.Repositories
{
  public class LookupItemRepository : BaseRepository, ILookupItemRepository
  {
    public LookupItemRepository(VideoGameCollectionTrackerDbContext dbContext) : base(dbContext)
    {

    }
    public async Task<IEnumerable<LookupItem>> GetVideoGameSystemsAsync()
    {
      return await DbContext.VideoGameSystems.AsNoTracking().Select(vgs =>
      new LookupItem
      {
        Id = vgs.Id,
        DisplayMember = vgs.Name
      }
      ).ToListAsync();
    }
  }
}
