using System.Threading.Tasks;
using System.Windows;

namespace VideoGameCollectionTracker.UI.ViewModels
{
  public interface IViewModel
  {
    Task LoadAsync();
    Visibility Visibility { get; set; }
    string Name { get; }
  }
}