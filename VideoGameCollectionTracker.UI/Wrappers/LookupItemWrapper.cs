using System.Windows.Input;
using VideoGameCollectionTracker.Model;
using VideoGameCollectionTracker.UI.Commands;
using VideoGameCollectionTracker.UI.Events;

namespace VideoGameCollectionTracker.UI.Wrappers
{
  public class LookupItemWrapper<T>:BaseModelWrapper<LookupItem>
  {
    private readonly IEventAggregator _eventAggregator;
    public LookupItemWrapper(LookupItem model, IEventAggregator eventAggregator):base(model, model.Id)
    {
      _eventAggregator = eventAggregator;
      OpenCommand = new RelayCommand(OnOpenViewModel, OnCanOpenViewModel);
    }

    public string DisplayMember
    {
      get => Model.DisplayMember;
      set 
      { 
        Model.DisplayMember = value;
        OnPropertyChanged();
      }
    }

    public ICommand OpenCommand { get; private set; }

    public bool OnCanOpenViewModel()
    {
      return true;
    }

    public void OnOpenViewModel()
    {
      _eventAggregator.SendMessage(
      new OpenViewModelMessage
      {
        Id = Id,
              EntityType = typeof(T)
      });
    }
  }
}
