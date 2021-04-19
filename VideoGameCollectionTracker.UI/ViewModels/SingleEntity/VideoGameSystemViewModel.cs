using System.Threading.Tasks;
using VideoGameCollectionTracker.Model;
using VideoGameCollectionTracker.UI.Data.Repositories;
using VideoGameCollectionTracker.UI.Events;
using VideoGameCollectionTracker.UI.Views.Services;
using VideoGameCollectionTracker.UI.Wrappers;

namespace VideoGameCollectionTracker.UI.ViewModels.SingleEntity
{
  public class VideoGameSystemViewModel : SingleEntityViewModel<VideoGameSystem>
  {
    public VideoGameSystemViewModel(IEventAggregator eventAggregator,
      IMessageDialogService messageDialogService,
      IVideoGameSystemRepository repository) : base(eventAggregator, messageDialogService,repository)
    {
    }

    protected override void CreateModelWrapper(VideoGameSystem model)
    {
      ModelWrapper = new VideoGameSystemWrapper(model);
    }

    protected async override Task LoadAsync()
    {
      var model = await Repository.GetById(Id);
      ModelWrapper = new VideoGameSystemWrapper(model);
    }
  }
}
