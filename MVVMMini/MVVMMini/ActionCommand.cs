using System;
using System.Windows.Input;

namespace MVVMMini
{
  public class ActionCommand : ICommand
  {
    public string DisplayText { get; set; }
    public string ToolTipText { get; set; }

    private readonly Action action;
    private readonly Action<object> action2;

    public ActionCommand(Action action)
    {
      this.action = action;
    }

    public ActionCommand(Action<object> action)
    {
      action2 = action;
    }

    private bool isEnabled = true;

    public bool IsEnabled
    {
      get { return isEnabled; }
      set
      {
        isEnabled = value;
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
      }
    }


    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
      return isEnabled;
    }

    public void Execute(object parameter)
    {
      action?.Invoke();
      action2?.Invoke(parameter);
    }
  }
}
