using System.Windows;
using VideoGameCollectionTracker.DataAccess;
using VideoGameCollectionTracker.Model;
using VideoGameCollectionTracker.UI.Data.Repositories;
using VideoGameCollectionTracker.UI.Events;
using VideoGameCollectionTracker.UI.ViewModels;

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
      var eventAggregator = new EventAggregator();
      var lookupRepository = new LookupItemRepository(dbContext);
      var navigationViewModel = new NavigationViewModel(eventAggregator);
      var videoGameSystemViewModel = new VideoGameSystemViewModel(eventAggregator);
      var entityListViewModel = new EntityListViewModel<VideoGameSystem>(eventAggregator, lookupRepository, videoGameSystemViewModel);
      var mainViewModel = new MainViewModel(eventAggregator,navigationViewModel,entityListViewModel);
      var mainWindow = new MainWindow(mainViewModel);
      mainWindow.Show();
    }

    private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {

    }
  }
}
