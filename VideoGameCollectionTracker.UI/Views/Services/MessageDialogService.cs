using System.Windows;

namespace VideoGameCollectionTracker.UI.Views.Services
{
  public class MessageDialogService : IMessageDialogService
  {
    public MessageBoxResult ShowYesNo(string message, string caption)
    {
      return MessageBox.Show(message, caption, MessageBoxButton.YesNo);
    }

    public void Show(string message)
    {
      MessageBox.Show(message);
    }
  }
}
