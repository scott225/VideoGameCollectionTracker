using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VideoGameCollectionTracker.Model;
using VideoGameCollectionTracker.UI.Data.Repositories;
using VideoGameCollectionTracker.UI.Events;
using VideoGameCollectionTracker.UI.Wrappers;

namespace VideoGameCollectionTracker.UI.ViewModels.SingleEntity
{
  public class VideoGameViewModel : SingleEntityViewModel<VideoGame>
  {
    private ObservableCollection<VideoGameSystem> _videoGameSystems;
    private ObservableCollection<Genre> _genres;

    public VideoGameViewModel(IEventAggregator eventAggregator,
      IVideoGameRepository repository) : base(eventAggregator, repository)
    {
      VideoGameSystems = new ObservableCollection<VideoGameSystem>();
      Genres = new ObservableCollection<Genre>();
    }

    public ObservableCollection<VideoGameSystem> VideoGameSystems
    {
      get { return _videoGameSystems; }
      set
      {
        _videoGameSystems = value;
        OnPropertyChanged();
      }
    }

    public ObservableCollection<Genre> Genres
    {
      get { return _genres; }
      set
      {
        _genres = value;
        OnPropertyChanged();
      }
    }

    public async override Task LoadAsync()
    {
      VideoGameSystems.Clear();
      Genres.Clear();
      var model = await Repository.GetById(Id);
      ModelWrapper = new VideoGameWrapper(model);
      foreach (var videoGameSystem in model.Systems)
      {
        VideoGameSystems.Add(videoGameSystem);
      }
      if(model.Genres != null)
      {
        foreach (var genre in model.Genres)
        {
          Genres.Add(genre);
        }
      }
    }
  }
}
