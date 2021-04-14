using VideoGameCollectionTracker.Model;

namespace VideoGameCollectionTracker.UI.Wrappers
{
  public class LookupItemWrapper:BaseModelWrapper<LookupItem>
  {
    public LookupItemWrapper(LookupItem model)
    {
      Model = model;
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
  }
}
