using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameCollectionTracker.UI.Events;

namespace VideoGameCollectionTracker.UI.ViewModels
{
  public class NavigationViewModel:BaseViewModel
  {
    public NavigationViewModel(IEventAggregator eventAggregator)
      :base(eventAggregator)
    {
      //EventAggregator.RegisterHandler<OpenViewModelMessage>(OnOpenViewModelMessage);
    }

    //private void OnOpenViewModelMessage(OpenViewModelMessage obj)
    //{
    //  throw new NotImplementedException();
    //}

    public override Task LoadAsync()
    {
      //throw new NotImplementedException();
      return null;
    }
  }
}
