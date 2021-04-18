using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VideoGameCollectionTracker.DataAccess;
using VideoGameCollectionTracker.Model;

namespace VideoGameCollectionTracker.UI.Data.Repositories
{
  public class LookupItemRepository : ILookupItemRepository
  {
    private readonly VideoGameCollectionTrackerDbContext _dbContext;

    public LookupItemRepository(VideoGameCollectionTrackerDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<IEnumerable<LookupItem>> GetGenresAsync()
    {
      return await _dbContext.Genres.AsNoTracking().Select(g =>
        new LookupItem
        {
          Id = g.Id,
          DisplayMember = g.Name
        }
        ).ToListAsync();
    }

    public async Task<IEnumerable<LookupItem>> GetVideoGamesAsync()
    {
      return await _dbContext.VideoGames.AsNoTracking().Select(vg =>
      new LookupItem
      {
        Id = vg.Id,
        DisplayMember = vg.Name
      }
      ).ToListAsync();
    }

    public async Task<IEnumerable<LookupItem>> GetVideoGameSystemsAsync()
    {
      return await _dbContext.VideoGameSystems.AsNoTracking().Select(vgs =>
      new LookupItem
      {
        Id = vgs.Id,
        DisplayMember = vgs.Name
      }
      ).ToListAsync();
    }
  }
}
