using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VideoGameCollectionTracker.UI.Events;

namespace VideoGameCollectionTracker.UI.ViewModels
{
  public class DataErrorEntity : PropertyChangedEntity,INotifyDataErrorInfo
  {
    private readonly Dictionary<string, List<ValidationResult>> _errors;

    public DataErrorEntity()
    {
      _errors = new Dictionary<string, List<ValidationResult>>();
    }

    public bool HasErrors => _errors.Any();

    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    public IEnumerable GetErrors(string propertyName)
    {
      _ = _errors.TryGetValue(propertyName, out List<ValidationResult> validationResults);
      return validationResults;
    }

    protected void ValidateDataAnnotations(object model, object value, string propertyName)
    {
      _errors.Remove(propertyName);
      var context = new ValidationContext(model) { MemberName = propertyName };
      var results = new List<ValidationResult>();
      Validator.TryValidateProperty(value, context, results);
      List<ValidationResult> propertyErrors = new List<ValidationResult>();
      results.ForEach(r => propertyErrors.Add(r));
      if (propertyErrors.Count == 0) return;
      _errors.Add(propertyName, propertyErrors);
      ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
  }
}
