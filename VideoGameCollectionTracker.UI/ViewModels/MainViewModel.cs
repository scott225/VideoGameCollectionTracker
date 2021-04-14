using System;
using System.Threading.Tasks;
using VideoGameCollectionTracker.UI.Events;

namespace VideoGameCollectionTracker.UI.ViewModels
{
  public class MainViewModel:BaseViewModel
  {
    public MainViewModel(IEventAggregator eventAggregator,
      IBaseViewModel navigationViewModel,
      IBaseViewModel entityListViewModel)
      : base(eventAggregator)
    {
      NavigationViewModel = navigationViewModel;
      EntityListViewModel = entityListViewModel;
    }

    public IBaseViewModel NavigationViewModel { get; private set; }
    public IBaseViewModel EntityListViewModel { get; private set; }

    public override Task LoadAsync()
    {
      //throw new NotImplementedException();
      return null;
    }
  }
}
