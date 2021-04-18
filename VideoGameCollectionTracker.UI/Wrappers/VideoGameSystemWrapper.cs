﻿using VideoGameCollectionTracker.Model;

namespace VideoGameCollectionTracker.UI.Wrappers
{
  public class VideoGameSystemWrapper:BaseModelWrapper<VideoGameSystem>
  {
    public VideoGameSystemWrapper(VideoGameSystem model) : base(model, model.Id)
    {
    }

    public string Name
    {
      get { return GetValue<string>(); }
      set { SetValue(value); }
    }
  }
}
