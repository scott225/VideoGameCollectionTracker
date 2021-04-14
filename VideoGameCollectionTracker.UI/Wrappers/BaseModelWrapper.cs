using VideoGameCollectionTracker.UI.ViewModels;

namespace VideoGameCollectionTracker.UI.Wrappers
{
  public class BaseModelWrapper<T>:PropertyChangedTracker
  {
    protected T Model;
  }
}
