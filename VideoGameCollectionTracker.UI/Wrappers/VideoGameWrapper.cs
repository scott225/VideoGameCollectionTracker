using VideoGameCollectionTracker.Model;

namespace VideoGameCollectionTracker.UI.Wrappers
{
  public class VideoGameWrapper:BaseModelWrapper<VideoGame>
  {
    public VideoGameWrapper(VideoGame model) : base(model,model.Id)
    {
    }
    public string Name
    {
      get { return GetValue<string>(); }
      set { SetValue(value); }
    }
  }
}
