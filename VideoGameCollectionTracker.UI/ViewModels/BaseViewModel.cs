using System.Threading.Tasks;
using System.Windows.Input;
using VideoGameCollectionTracker.UI.Commands;
using VideoGameCollectionTracker.UI.Events;

namespace VideoGameCollectionTracker.UI.ViewModels
{
  public abstract class BaseViewModel : PropertyChangedTracker, IBaseViewModel
  {
    protected readonly IEventAggregator EventAggregator;

    public BaseViewModel(IEventAggregator eventAggregator)
    {
      EventAggregator = eventAggregator;
      OpenCommand = new RelayCommand(OnOpenViewModel, OnCanOpenViewModel);
    }

    public ICommand OpenCommand { get; private set; }

    public abstract Task LoadAsync();

    private void OnOpenViewModel()
    {
      EventAggregator.SendMessage(
        new OpenViewModelMessage
        {
          Id = 0, //TODO: 0 or null?
          EntityType = typeof(VideoGameSystemViewModel)
        });
    }

    private bool OnCanOpenViewModel()
    {
      return true;
    }
  }
}
