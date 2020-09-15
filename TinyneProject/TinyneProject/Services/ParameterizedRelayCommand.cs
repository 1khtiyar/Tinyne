using System;
using System.Windows.Input;

namespace TinyneProject.Services
{
    internal class ParameterizedRelayCommand:ICommand
    {
        public Action<object> action;

        public ParameterizedRelayCommand(Action<object> action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
