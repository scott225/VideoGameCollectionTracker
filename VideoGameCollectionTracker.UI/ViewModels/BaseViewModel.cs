using System.Threading.Tasks;
using System.Windows;
using VideoGameCollectionTracker.UI.Events;
using VideoGameCollectionTracker.UI.Views.Services;

namespace VideoGameCollectionTracker.UI.ViewModels
{
  public abstract class BaseViewModel : EventAggregatorEntity, IViewModel
  {
    private Visibility _visibility;
    private bool _hasChanges;

    protected IMessageDialogService MessageDialogService { get; private set; }

    public BaseViewModel(IEventAggregator eventAggregator, 
      IMessageDialogService messageDialogService):base(eventAggregator)
    {
      MessageDialogService = messageDialogService;
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

    public bool HasChanges
    {
      get { return _hasChanges; }
      set { _hasChanges = value; }
    }


    public string Name
    {
      get
      {
        return GetType().Name;
      }
    }

    public abstract Task LoadAsyncBase();
  }
}
