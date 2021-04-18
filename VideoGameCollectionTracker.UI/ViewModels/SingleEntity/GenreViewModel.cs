using System;
using System.Threading.Tasks;
using VideoGameCollectionTracker.Model;
using VideoGameCollectionTracker.UI.Data.Repositories;
using VideoGameCollectionTracker.UI.Events;
using VideoGameCollectionTracker.UI.Wrappers;

namespace VideoGameCollectionTracker.UI.ViewModels.SingleEntity
{
  public class GenreViewModel : SingleEntityViewModel<Genre>
  {
    public GenreViewModel(IEventAggregator eventAggregator, IBaseRepository<Genre> repository) : base(eventAggregator, repository)
    {
    }

    public async override Task LoadAsync()
    {
      var model = await Repository.GetById(Id);
      ModelWrapper = new GenreWrapper(model,model.Id);
    }
  }
}
