using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using VideoGameCollectionTracker.DataAccess;
using VideoGameCollectionTracker.Model;

namespace VideoGameCollectionTracker.UI.Data.Repositories
{
  public class VideoGameSystemRepository : BaseRepository<VideoGameSystem>, IVideoGameSystemRepository
  {
    public VideoGameSystemRepository(VideoGameCollectionTrackerDbContext dbContext)
      : base(dbContext)
    {
    }
    public override async Task<List<VideoGameSystem>> GetAllAsync()
    {
      return await DbContext.VideoGameSystems.ToListAsync();
    }

    public override async Task<VideoGameSystem> GetById(int id)
    {
      return await DbContext.VideoGameSystems.FindAsync(id);
    }
  }
}
