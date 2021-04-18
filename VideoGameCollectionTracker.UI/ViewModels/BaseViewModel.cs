using System.Threading.Tasks;
using System.Windows;
using VideoGameCollectionTracker.UI.Events;

namespace VideoGameCollectionTracker.UI.ViewModels
{
  public abstract class BaseViewModel : EventAggregatorEntity,IViewModel
  {
    private Visibility _visibility;

    public BaseViewModel(IEventAggregator eventAggregator):base(eventAggregator)
    {
      
    }

    public Visibility Visibility
    {
      get { return _visibility; }
      set
      {
        _visibility = value;
        OnPropertyChanged();
      }
    }

    public string Name
    {
      get
      {
        return GetType().Name;
      }
    }

    public abstract Task LoadAsync();
  }
}
