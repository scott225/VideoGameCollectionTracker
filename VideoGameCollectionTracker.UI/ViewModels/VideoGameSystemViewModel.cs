using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameCollectionTracker.UI.Events;

namespace VideoGameCollectionTracker.UI.ViewModels
{
  public class VideoGameSystemViewModel : BaseViewModel
  {
    public VideoGameSystemViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
    {
    }

    public override Task LoadAsync()
    {
      return null;
    }
  }
}
