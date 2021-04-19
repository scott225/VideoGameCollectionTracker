using System.Runtime.CompilerServices;
using VideoGameCollectionTracker.UI.ViewModels;

namespace VideoGameCollectionTracker.UI.Wrappers
{
  public class BaseModelWrapper<T>:DataErrorEntity
  {
    public BaseModelWrapper(T model, int id)
    {
      Model = model;
      Id = id;
    }
    public T Model { get; set; }
    public int Id
    {
      set { SetValue(value); }
      get { return GetValue<int>(); }
    }

    protected TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
    {
      return (TValue)typeof(T).GetProperty(propertyName).GetValue(Model);
    }

    protected void SetValue<TValue>(TValue value, [CallerMemberName] string propertyName = null)
    {
      typeof(T).GetProperty(propertyName).SetValue(Model, value);
      OnPropertyChanged(propertyName);
      ValidateDataAnnotations(Model, value, propertyName);
    }
  }
}
