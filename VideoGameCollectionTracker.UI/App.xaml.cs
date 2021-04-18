using System.Windows;
using VideoGameCollectionTracker.DataAccess;
using VideoGameCollectionTracker.Model;
using VideoGameCollectionTracker.UI.Data.Repositories;
using VideoGameCollectionTracker.UI.Events;
using VideoGameCollectionTracker.UI.ViewModels;
using VideoGameCollectionTracker.UI.ViewModels.MultipleEntity;
using VideoGameCollectionTracker.UI.ViewModels.SingleEntity;

namespace VideoGameCollectionTracker.UI
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private void Application_Startup(object sender, StartupEventArgs e)
    {
      var dbContext = new VideoGameCollectionTrackerDbContext();

      //repos
      var videoGameSystemRepository = new VideoGameSystemRepository(dbContext);
      var videoGameRepository = new VideoGameRepository(dbContext);
      var genreRepository = new GenreRepository(dbContext);
      var lookupRepository = new LookupItemRepository(dbContext);

      var eventAggregator = new EventAggregator();

      //view models
      var navigationViewModel = new NavigationViewModel(eventAggregator);
      var videoGameSystemViewModel = new VideoGameSystemViewModel(eventAggregator, videoGameSystemRepository);
      var videoGameViewModel = new VideoGameViewModel(eventAggregator, videoGameRepository);
      var genreViewModel = new GenreViewModel(eventAggregator, genreRepository);
      var videoGameListViewModel = new EntityListViewModel<VideoGame>(eventAggregator, lookupRepository, videoGameSystemViewModel, videoGameViewModel, genreViewModel);
      var videoGameSystemListViewModel = new EntityListViewModel<VideoGameSystem>(eventAggregator, lookupRepository, videoGameSystemViewModel, videoGameViewModel, genreViewModel);
      var genreListViewModel = new EntityListViewModel<Genre>(eventAggregator, lookupRepository, videoGameSystemViewModel, videoGameViewModel, genreViewModel);
      var mainViewModel = new MainViewModel(eventAggregator, lookupRepository, navigationViewModel, videoGameListViewModel, videoGameSystemListViewModel, genreListViewModel);

      var mainWindow = new MainWindow(mainViewModel);
      mainWindow.Show();
    }

    private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {

    }
  }
}
