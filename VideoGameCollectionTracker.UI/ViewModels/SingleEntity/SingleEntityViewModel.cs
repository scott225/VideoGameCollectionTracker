using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using VideoGameCollectionTracker.UI.Commands;
using VideoGameCollectionTracker.UI.Data.Repositories;
using VideoGameCollectionTracker.UI.Events;
using VideoGameCollectionTracker.UI.Views.Services;
using VideoGameCollectionTracker.UI.Wrappers;

namespace VideoGameCollectionTracker.UI.ViewModels.SingleEntity
{
  public abstract class SingleEntityViewModel<T> : BaseViewModel where T : class, new()
  {
    protected int Id;
    protected BaseModelWrapper<T> _modelWrapper;
    protected IBaseRepository<T> Repository;

    public SingleEntityViewModel(IEventAggregator eventAggregator,
      IMessageDialogService messageDialogService,
      IBaseRepository<T> repository) : base(eventAggregator, messageDialogService)
    {
      Repository = repository;
      SaveCommand = new RelayCommand(OnSave, OnCanSave);
      DeleteCommand = new RelayCommand(OnDelete, OnCanDelete);
      Visibility = System.Windows.Visibility.Hidden;
      EventAggregator.RegisterHandler<OpenViewModelMessage>(OnOpenViewModelMessage);
    }

    public ICommand SaveCommand { get; private set; }
    public ICommand DeleteCommand { get; private set; }

    protected abstract Task LoadAsync();
    protected abstract void CreateModelWrapper(T model);

    public override async Task LoadAsyncBase()
    {
      if(Id > 0)
      {
        await LoadAsync();
      }
      else
      {
        var model = new T();
        Repository.Add(model);
        CreateModelWrapper(model);
        //ModelWrapper = new BaseModelWrapper<T>(model, 0);
      }
      
      ModelWrapper.PropertyChanged += OnPropertyChanged_Event;
    }

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
      HasChanges = Repository.HasChanges();
      EventAggregator.SendMessage(new ReloadEntitiesMessage());
    }

    private bool OnCanSave()
    {
      return ModelWrapper != null && !ModelWrapper.HasErrors && HasChanges;
    }

    private async Task OnDelete()
    {
      var userSelection = MessageDialogService.ShowYesNo("Are you sure you want to delete this item?", "Question");
      if (userSelection == System.Windows.MessageBoxResult.No)return;

      Repository.Delete(ModelWrapper.Model);
      await Repository.SaveAsync();
      ModelWrapper = null;
      Visibility = System.Windows.Visibility.Hidden;
      EventAggregator.SendMessage(new ReloadEntitiesMessage());
    }

    private bool OnCanDelete()
    {
      return true;
    }

    private async void OnOpenViewModelMessage(OpenViewModelMessage obj)
    {
      //check if you want to navigate away
      if (HasChanges)
      {
        var userSelection = MessageDialogService.ShowYesNo("There are unsaved changes. Are you sure you want to navigate away?", "Question");
        if (userSelection == System.Windows.MessageBoxResult.No)
        {
          return;
        }
        else
        {
          await ReloadAsync();
        }
      }

      if (obj.EntityType != typeof(T))
      {
        Visibility = System.Windows.Visibility.Hidden;
        return;
      }
      Visibility = System.Windows.Visibility.Visible;

      Id = obj.Id;
      await LoadAsyncBase();
    }

    private async Task ReloadAsync()
    {
      await Repository.ReloadAsync(ModelWrapper.Model);
      HasChanges = Repository.HasChanges();
    }

    private void OnPropertyChanged_Event(object sender, PropertyChangedEventArgs e)
    {
      HasChanges = Repository.HasChanges();
    }
  }
}
