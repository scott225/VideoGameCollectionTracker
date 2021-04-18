using VideoGameCollectionTracker.Model;

namespace VideoGameCollectionTracker.UI.Wrappers
{
  public class GenreWrapper : BaseModelWrapper<Genre>
  {
    public GenreWrapper(Genre model, int id) : base(model, id)
    {
    }

    public string Name
    {
      get { return Model.Name; }
      set
      {
        Model.Name = value;
        OnPropertyChanged();
      }
    }

  }
}
