using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using VideoGameCollectionTracker.DataAccess;
using VideoGameCollectionTracker.Model;

namespace VideoGameCollectionTracker.UI.Data.Repositories
{
  public class GenreRepository : BaseRepository<Genre>, IGenreRepository
  {
    public GenreRepository(VideoGameCollectionTrackerDbContext dbContext) : base(dbContext)
    {
    }

    public async override Task<List<Genre>> GetAllAsync()
    {
      return await DbContext.Genres.ToListAsync();
    }

    public async override Task<Genre> GetById(int id)
    {
      return await DbContext.Genres
      .FirstAsync(g => g.Id == id);
    }
  }
}
