using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VideoGameCollectionTracker.UI.ViewModels
{
  public class PropertyChangedTracker : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }

}
