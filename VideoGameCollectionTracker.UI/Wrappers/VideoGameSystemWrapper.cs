using VideoGameCollectionTracker.Model;

namespace VideoGameCollectionTracker.UI.Wrappers
{
  public class VideoGameSystemWrapper:BaseModelWrapper<VideoGameSystem>
  {
    public VideoGameSystemWrapper(VideoGameSystem model)
    {
      Model = model;
    }

    public string Name
    {
      get => Model.Name;
      set 
      { 
        Model.Name = value;
        OnPropertyChanged();
      }
    }
  }
}
