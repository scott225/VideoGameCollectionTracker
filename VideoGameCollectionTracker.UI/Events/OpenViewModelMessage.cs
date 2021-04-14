using System;

namespace VideoGameCollectionTracker.UI.Events
{
  public class OpenViewModelMessage
  {
    public int Id { get; set; }
    public Type EntityType { get; set; }
  }
}
