using System.Collections.Generic;
using System.Threading.Tasks;
using VideoGameCollectionTracker.Model;
using VideoGameCollectionTracker.UI.Data.Repositories;
using VideoGameCollectionTracker.UI.Events;
using VideoGameCollectionTracker.UI.Views.Services;

namespace VideoGameCollectionTracker.UI.ViewModels.MultipleEntity
{
  public class MainViewModel:MultipleEntityViewModel
  {
    private IViewModel _videoGameListViewModel;
    private IViewModel _videoGameSystemListViewModel;
    private IViewModel _genreListViewModel;
    private IViewModel _entityListViewModel;
    private List<IViewModel> _viewModels;

    public MainViewModel(IEventAggregator eventAggregator,
      IMessageDialogService messageDialogService,
      ILookupItemRepository lookupItemRepository,
      IViewModel navigationViewModel,
      IViewModel videoGameListViewModel,
      IViewModel videoGameSystemListViewModel,
      IViewModel genreListViewModel)
      : base(eventAggregator,messageDialogService)
    {
      NavigationViewModel = navigationViewModel;
      eventAggregator.RegisterHandler<OpenEntityListMessage>(OnOpenEntityListMessage);
      _videoGameListViewModel = videoGameListViewModel;
      _videoGameSystemListViewModel = videoGameSystemListViewModel;
      _genreListViewModel = genreListViewModel;
      _viewModels = new List<IViewModel>();
      _viewModels.AddRange( new List<IViewModel> { videoGameListViewModel, videoGameSystemListViewModel, genreListViewModel });
      _videoGameListViewModel.Visibility = System.Windows.Visibility.Hidden;
      _videoGameSystemListViewModel.Visibility = System.Windows.Visibility.Hidden;
      _genreListViewModel.Visibility = System.Windows.Visibility.Hidden;
    }

    private async void OnOpenEntityListMessage(OpenEntityListMessage obj)
    {
      foreach (var viewModel in _viewModels)
      {
        viewModel.Visibility = System.Windows.Visibility.Hidden;
      }

      if (obj.EntityType == typeof(VideoGame))
      {
        EntityListViewModel = _videoGameListViewModel;
        _videoGameListViewModel.Visibility = System.Windows.Visibility.Visible;
      }
      else if(obj.EntityType == typeof(VideoGameSystem))
      {
        EntityListViewModel = _videoGameSystemListViewModel;
        _videoGameSystemListViewModel.Visibility = System.Windows.Visibility.Visible;
      }
      else if (obj.EntityType == typeof(Genre))
      {
        EntityListViewModel = _genreListViewModel;
        _genreListViewModel.Visibility = System.Windows.Visibility.Visible;
      }
      await EntityListViewModel.LoadAsyncBase();
    }

    public IViewModel NavigationViewModel { get; private set; }
    public IViewModel EntityListViewModel { get { return _entityListViewModel; } 
      set 
      {
        _entityListViewModel = value;
        OnPropertyChanged();
      } 
    }

    public override Task LoadAsyncBase()
    {
      return null;
    }
  }
}
