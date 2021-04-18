using System.Windows.Input;
using VideoGameCollectionTracker.UI.Commands;
using VideoGameCollectionTracker.UI.Data.Repositories;
using VideoGameCollectionTracker.UI.Events;
using VideoGameCollectionTracker.UI.Wrappers;

namespace VideoGameCollectionTracker.UI.ViewModels.SingleEntity
{
  public abstract class SingleEntityViewModel<T> : BaseViewModel
  {
    protected int Id;
    protected BaseModelWrapper<T> _modelWrapper;
    protected IBaseRepository<T> Repository;

    public SingleEntityViewModel(IEventAggregator eventAggregator,
      IBaseRepository<T> repository):base(eventAggregator)
    {
      Repository = repository;
      SaveCommand = new RelayCommand(OnSave, OnCanSave);
      Visibility = System.Windows.Visibility.Hidden;
      EventAggregator.RegisterHandler<OpenViewModelMessage>(OnOpenViewModelMessage);
    }

    public ICommand SaveCommand { get; private set; }

    public BaseModelWrapper<T> ModelWrapper
    {
      get => _modelWrapper;
      set
      {
        _modelWrapper = value;
        OnPropertyChanged();
      }
    }

    private async void OnSave()
    {
      await Repository.SaveAsync();
      EventAggregator.SendMessage(new ReloadEntitiesMessage());
    }

    private bool OnCanSave()
    {
      return true;
    }
    private async void OnOpenViewModelMessage(OpenViewModelMessage obj)
    {
      if (obj.EntityType != typeof(T))
      {
        Visibility = System.Windows.Visibility.Hidden;
        return;
      }
      Visibility = System.Windows.Visibility.Visible;

      Id = obj.Id;
      await LoadAsync();
    }
  }
}
