using System;
using System.Threading.Tasks;
using VideoGameCollectionTracker.Model;
using VideoGameCollectionTracker.UI.Data.Repositories;
using VideoGameCollectionTracker.UI.Events;
using VideoGameCollectionTracker.UI.Views.Services;
using VideoGameCollectionTracker.UI.Wrappers;

namespace VideoGameCollectionTracker.UI.ViewModels.SingleEntity
{
  public class GenreViewModel : SingleEntityViewModel<Genre>
  {
    public GenreViewModel(IEventAggregator eventAggregator, 
      IMessageDialogService messageDialogService,
      IBaseRepository<Genre> repository) : base(eventAggregator, messageDialogService, repository)
    {
    }

    protected override void CreateModelWrapper(Genre model)
    {
      ModelWrapper = new GenreWrapper(model, model.Id);
    }

    protected async override Task LoadAsync()
    {
      //if(Id > 0)
      //{
        var model = await Repository.GetById(Id);
        ModelWrapper = new GenreWrapper(model, model.Id);
      //}
      //else
      //{
      //  var model = new Genre();
      //  Repository.Add(model);
      //  ModelWrapper = new GenreWrapper(model, model.Id);
      //}
    }
  }
}
