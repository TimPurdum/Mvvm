using System;
using System.Windows.Input;


namespace Mvvm.Business
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            _execute = execute ??
                       throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }


        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }


        public void Execute(object parameter)
        {
            _execute(parameter);
        }


        public event EventHandler CanExecuteChanged;
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
    }


    public class RelayCommand<T> : ICommand
    {
        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
        {
            _execute = execute ??
                       throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }
        
        public bool CanExecute(object parameter)
        {
            return parameter is T typedObject && (_canExecute?.Invoke(typedObject) ?? true);
        }


        public void Execute(object parameter)
        {
            if (parameter is T typedobject)
            {
                _execute(typedobject);
            }
        }
        
        
        public event EventHandler CanExecuteChanged;
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;
    }
}