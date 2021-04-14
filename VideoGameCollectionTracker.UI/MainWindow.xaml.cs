using System.Windows;
using VideoGameCollectionTracker.UI.ViewModels;

namespace VideoGameCollectionTracker.UI
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private readonly MainViewModel _mainViewModel;

    public MainWindow(MainViewModel mainViewModel)
    {
      _mainViewModel = mainViewModel;
      InitializeComponent();
      DataContext = mainViewModel;
      Loaded += OnMainWindow_Loaded;
    }

    private void OnMainWindow_Loaded(object sender, RoutedEventArgs e)
    {
      _mainViewModel.LoadAsync();
    }
  }
}
