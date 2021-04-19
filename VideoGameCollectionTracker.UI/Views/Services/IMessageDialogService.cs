using System.Windows;

namespace VideoGameCollectionTracker.UI.Views.Services
{
  public interface IMessageDialogService
  {
    MessageBoxResult ShowYesNo(string message, string caption);
    void Show(string message);
  }
}
