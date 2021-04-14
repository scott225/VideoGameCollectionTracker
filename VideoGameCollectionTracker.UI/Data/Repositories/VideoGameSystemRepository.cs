using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using VideoGameCollectionTracker.DataAccess;
using VideoGameCollectionTracker.Model;

namespace VideoGameCollectionTracker.UI.Data.Repositories
{
  public class VideoGameSystemRepository:BaseRepository
  {
    public VideoGameSystemRepository(VideoGameCollectionTrackerDbContext dbContext)
      : base(dbContext)
    {
    }
    public async Task<List<VideoGameSystem>> GetAllAsync()
    {
      return await DbContext.VideoGameSystems.ToListAsync();
    }
  }
}
