using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VideoGameCollectionTracker.Model;
using VideoGameCollectionTracker.UI.Data.Repositories;
using VideoGameCollectionTracker.UI.Events;
using VideoGameCollectionTracker.UI.Wrappers;

namespace VideoGameCollectionTracker.UI.ViewModels
{
  public class EntityListViewModel<T> : BaseViewModel
  {
    private ILookupItemRepository _lookupItemRepository;

    public EntityListViewModel(IEventAggregator eventAggregator,
      ILookupItemRepository lookupItemRepository,
      IBaseViewModel videoGameSystemViewModel)
      : base(eventAggregator)
    {
      _lookupItemRepository = lookupItemRepository;
      EventAggregator.RegisterHandler<OpenViewModelMessage>(OnOpenViewModelMessage);
      Entities = new ObservableCollection<LookupItemWrapper>();
    }

    private async void OnOpenViewModelMessage(OpenViewModelMessage obj)
    {
      await LoadAsync();
    }

    public ObservableCollection<LookupItemWrapper> Entities { get; set; }
    public IBaseViewModel VideoGameSystemViewModel { get; private set; }

    public async override Task LoadAsync()
    {
      if(typeof(T) == typeof(VideoGameSystem))
      {
        var videoGameSystems = await _lookupItemRepository.GetVideoGameSystemsAsync();
        foreach (var item in videoGameSystems)
        {
          Entities.Add(new LookupItemWrapper(item));
        }
      }
    }
  }
}
