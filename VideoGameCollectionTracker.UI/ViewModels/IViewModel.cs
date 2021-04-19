using System.Threading.Tasks;
using System.Windows;

namespace VideoGameCollectionTracker.UI.ViewModels
{
  public interface IViewModel
  {
    Task LoadAsyncBase();
    Visibility Visibility { get; set; }
    string Name { get; }
  }
}