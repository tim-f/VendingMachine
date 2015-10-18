using System;
using System.Diagnostics;
using System.Windows.Input;

namespace VendingMachine.Presentation.Wpf.Utility
{
    public abstract class AlwaysEnabledCommand : ICommand
    {
        bool ICommand.CanExecute(object parameter) => true;
        void ICommand.Execute(object parameter) => Execute();

        event EventHandler ICommand.CanExecuteChanged
        {
            add { }
            remove { }
        }

        protected abstract void Execute();
    }

    public abstract class AlwaysEnabledCommand<T> : ICommand
    {
        bool ICommand.CanExecute(object parameter) => true;

        void ICommand.Execute(object parameter)
        {
            Debug.Assert(parameter is T, $"Command parameter is not of type {typeof (T).FullName}");
            Execute((T)parameter);
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add { }
            remove { }
        }

        protected abstract void Execute(T parameter);
    }
}