using System;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoGameCollectionTracker.Model;
using VideoGameCollectionTracker.UI.Commands;
using VideoGameCollectionTracker.UI.Events;

namespace VideoGameCollectionTracker.UI.ViewModels.MultipleEntity
{
  public class NavigationViewModel : MultipleEntityViewModel
  {
    private IEventAggregator _eventAggregator;

    public NavigationViewModel(IEventAggregator eventAggregator)
      : base(eventAggregator)
    {
      _eventAggregator = eventAggregator;
      OpenCommand = new RelayCommand(OnOpenViewModel, OnCanOpenViewModel);
    }

    public ICommand OpenCommand { get; private set; }

    public override Task LoadAsync()
    {
      return null;
    }

    public bool OnCanOpenViewModel()
    {
      return true;
    }

    public void OnOpenViewModel(object message)
    {
      var button = Convert.ToString(message);
      if (button.Equals("videoGameSystems"))
      {
        _eventAggregator.SendMessage(
          new OpenEntityListMessage
          {
            EntityType = typeof(VideoGameSystem)
          });
      }
      else if (button.Equals("videoGames"))
      {
        _eventAggregator.SendMessage(
          new OpenEntityListMessage
          {
            EntityType = typeof(VideoGame)
          });
      }
      else if (button.Equals("genres"))
      {
        _eventAggregator.SendMessage(
          new OpenEntityListMessage
          {
            EntityType = typeof(Genre)
          });
      }
    }
  }
}
