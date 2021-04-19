﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoGameCollectionTracker.Model;
using VideoGameCollectionTracker.UI.Commands;
using VideoGameCollectionTracker.UI.Data.Repositories;
using VideoGameCollectionTracker.UI.Events;
using VideoGameCollectionTracker.UI.Views.Services;
using VideoGameCollectionTracker.UI.Wrappers;

namespace VideoGameCollectionTracker.UI.ViewModels.MultipleEntity
{
  public class EntityListViewModel<T> : MultipleEntityViewModel
  {
    private readonly ILookupItemRepository _lookupItemRepository;
    private readonly IEventAggregator _eventAggregator;
    private IViewModel _videoGameSystemViewModel;
    private IViewModel _videoGameViewModel;
    private IViewModel _genreViewModel;
    private List<IViewModel> _viewModels;

    public EntityListViewModel(IEventAggregator eventAggregator,
      IMessageDialogService messageDialogService,
      ILookupItemRepository lookupItemRepository,
      IViewModel videoGameSystemViewModel,
      IViewModel videoGameViewModel,
      IViewModel genreViewModel)
      : base(eventAggregator,messageDialogService)
    {
      _lookupItemRepository = lookupItemRepository;
      EventAggregator.RegisterHandler<ReloadEntitiesMessage>(OnReloadEntitiesMessage);
      Entities = new ObservableCollection<LookupItemWrapper<T>>();
      NewCommand = new RelayCommand(OnCreateNew, OnCanCreateNew);
      _eventAggregator = eventAggregator;
      _videoGameSystemViewModel = videoGameSystemViewModel;
      _videoGameViewModel = videoGameViewModel;
      _genreViewModel = genreViewModel;
      _viewModels = new List<IViewModel>
      {
        _videoGameSystemViewModel,
        _videoGameViewModel,
        genreViewModel
      };
    }



    public ICommand NewCommand { get; private set; }

    public IViewModel VideoGameSystemViewModel
    {
      get { return _videoGameSystemViewModel; }
      set
      {
        _videoGameSystemViewModel = value;
        OnPropertyChanged();
      }
    }

    public IViewModel VideoGameViewModel
    {
      get { return _videoGameViewModel; }
      set
      {
        _videoGameViewModel = value;
        OnPropertyChanged();
      }
    }

    public IViewModel GenreViewModel
    {
      get { return _genreViewModel; }
      set
      {
        _genreViewModel = value;
        OnPropertyChanged();
      }
    }


    public ObservableCollection<LookupItemWrapper<T>> Entities { get; set; }

    public override async Task LoadAsyncBase()
    {
      if (Visibility == System.Windows.Visibility.Hidden) return;
      Entities.Clear();

      if (typeof(T) == typeof(VideoGameSystem))
      {
        UpdateActiveViewModel(_videoGameSystemViewModel);
        await GetEntities(_lookupItemRepository.GetVideoGameSystemsAsync());
      }
      else if (typeof(T) == typeof(VideoGame))
      {
        UpdateActiveViewModel(_videoGameViewModel);
        await GetEntities(_lookupItemRepository.GetVideoGamesAsync());
      }
      else if (typeof(T) == typeof(Genre))
      {
        UpdateActiveViewModel(_genreViewModel);
        await GetEntities(_lookupItemRepository.GetGenresAsync());
      }
    }

    private void UpdateActiveViewModel(IViewModel viewModel)
    {
      foreach (var vm in _viewModels)
      {
        if (!vm.Name.Equals(viewModel.Name))
        {
          vm.Visibility = System.Windows.Visibility.Hidden;
        }
      }
    }

    private async Task GetEntities(Task<IEnumerable<LookupItem>> task)
    {
      var lookupItems = await task;
      foreach (var item in lookupItems)
      {
        Entities.Add(new LookupItemWrapper<T>(item, _eventAggregator));
      }
    }

    private async void OnReloadEntitiesMessage(ReloadEntitiesMessage obj)
    {
      await LoadAsyncBase();
    }
    private bool OnCanCreateNew()
    {
      return true;
    }

    private Task OnCreateNew()
    {
      _eventAggregator.SendMessage(
        new OpenViewModelMessage
        {
          Id = 0,
          EntityType = typeof(T)
        });
      return Task.CompletedTask;
    }
  }
}
