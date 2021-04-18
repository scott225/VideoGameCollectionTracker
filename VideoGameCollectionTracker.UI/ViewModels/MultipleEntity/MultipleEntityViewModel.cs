using VideoGameCollectionTracker.UI.Events;

namespace VideoGameCollectionTracker.UI.ViewModels.MultipleEntity
{
  public abstract class MultipleEntityViewModel : BaseViewModel
  {
    public MultipleEntityViewModel(IEventAggregator eventAggregator):base(eventAggregator)
    {
    }
  }
}
