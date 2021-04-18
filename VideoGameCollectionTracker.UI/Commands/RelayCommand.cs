using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VideoGameCollectionTracker.UI.Commands
{
  public class RelayCommand : ICommand
  {
    private readonly Func<Task> _executeFunc;
    private readonly Action _executeAction;
    private readonly Action<object> _executeActionWithParam;
    private readonly Func<bool> _canExecuteMethod;

    public RelayCommand(Func<Task> executeMethod, Func<bool> canExecuteMethod)
    {
      _executeFunc = executeMethod;
      _canExecuteMethod = canExecuteMethod;
    }

    public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
    {
      _executeAction = executeMethod;
      _canExecuteMethod = canExecuteMethod;
    }

    public RelayCommand(Action<object> executeMethod, Func<bool> canExecuteMethod)
    {
      _executeActionWithParam = executeMethod;
      _canExecuteMethod = canExecuteMethod;
    }

    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; } //TODO: understand these two lines better
      remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object parameter)
    {
      return _canExecuteMethod.Invoke();
    }

    public void Execute(object parameter)
    {
      if (_executeAction != null) _executeAction.Invoke();
      if (_executeActionWithParam != null) _executeActionWithParam.Invoke(parameter);
      if (_executeFunc != null) _executeFunc.Invoke();
    }
  }
}
