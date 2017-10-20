using System;
using System.Windows.Input;

namespace InteractionWithControls.Helpers
{
    public class RelayCommand : ICommand
    {
        #region Fields

        private readonly Action _execute;
        private readonly Predicate<object> _canExecute;

        #endregion

        #region Constructors

        public RelayCommand(Action execute) : this(execute, null)
        {
        }

        public RelayCommand(Action execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => _execute();

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        #endregion
    }
}
