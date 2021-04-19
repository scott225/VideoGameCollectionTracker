using System.Windows;
using VideoGameCollectionTracker.DataAccess;
using VideoGameCollectionTracker.Model;
using VideoGameCollectionTracker.UI.Data.Repositories;
using VideoGameCollectionTracker.UI.Events;
using VideoGameCollectionTracker.UI.ViewModels;
using VideoGameCollectionTracker.UI.ViewModels.MultipleEntity;
using VideoGameCollectionTracker.UI.ViewModels.SingleEntity;
using VideoGameCollectionTracker.UI.Views.Services;

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
      var messageDialogService = new MessageDialogService();

      //view models
      var navigationViewModel = new NavigationViewModel(eventAggregator, messageDialogService);
      var videoGameSystemViewModel = new VideoGameSystemViewModel(eventAggregator, messageDialogService, videoGameSystemRepository);
      var videoGameViewModel = new VideoGameViewModel(eventAggregator, messageDialogService, videoGameRepository);
      var genreViewModel = new GenreViewModel(eventAggregator, messageDialogService, genreRepository);
      var videoGameListViewModel = new EntityListViewModel<VideoGame>(eventAggregator, messageDialogService, lookupRepository, videoGameSystemViewModel, videoGameViewModel, genreViewModel);
      var videoGameSystemListViewModel = new EntityListViewModel<VideoGameSystem>(eventAggregator, messageDialogService, lookupRepository, videoGameSystemViewModel, videoGameViewModel, genreViewModel);
      var genreListViewModel = new EntityListViewModel<Genre>(eventAggregator, messageDialogService, lookupRepository, videoGameSystemViewModel, videoGameViewModel, genreViewModel);
      var mainViewModel = new MainViewModel(eventAggregator, messageDialogService, lookupRepository, navigationViewModel, videoGameListViewModel, videoGameSystemListViewModel, genreListViewModel);

      var mainWindow = new MainWindow(mainViewModel);
      mainWindow.Show();
    }

    private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {

    }
  }
}
