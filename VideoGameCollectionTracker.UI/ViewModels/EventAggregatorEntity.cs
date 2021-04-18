using VideoGameCollectionTracker.UI.Events;

namespace VideoGameCollectionTracker.UI.ViewModels
{
  public class EventAggregatorEntity: PropertyChangedEntity
  {
    protected readonly IEventAggregator EventAggregator;

    public EventAggregatorEntity(IEventAggregator eventAggregator)
    {
      EventAggregator = eventAggregator;
    }
  }
}
