using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using VideoGameCollectionTracker.DataAccess;
using VideoGameCollectionTracker.Model;

namespace VideoGameCollectionTracker.UI.Data.Repositories
{
  public class VideoGameRepository : BaseRepository<VideoGame>, IVideoGameRepository
  {
    public VideoGameRepository(VideoGameCollectionTrackerDbContext dbContext) : base(dbContext)
    {
    }

    public async override Task<List<VideoGame>> GetAllAsync()
    {
      return await DbContext.VideoGames.ToListAsync();
    }

    public async override Task<VideoGame> GetById(int id)
    {
      return await DbContext.VideoGames
        .Include(vg=>vg.Systems)
        .Include(vg=>vg.Genres)
        .FirstAsync(vg=>vg.Id==id);
    }
  }
}
