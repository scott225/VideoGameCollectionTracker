using System.Threading.Tasks;

namespace VideoGameCollectionTracker.UI.ViewModels
{
  public interface IBaseViewModel
  {
    Task LoadAsync();
  }
}