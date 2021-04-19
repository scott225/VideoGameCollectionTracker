using VideoGameCollectionTracker.UI.Events;
using VideoGameCollectionTracker.UI.Views.Services;

namespace VideoGameCollectionTracker.UI.ViewModels.MultipleEntity
{
  public abstract class MultipleEntityViewModel : BaseViewModel
  {
    public MultipleEntityViewModel(IEventAggregator eventAggregator,
      IMessageDialogService messageDialogService):base(eventAggregator, messageDialogService)
    {
    }
  }
}
