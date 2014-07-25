using System;
using System.Windows.Input;

namespace Extender.WPF
{
    public class RelayCommand : ICommand
    {
        private Action methodToExecute;
        private Func<bool> canExecuteEvaluator;
                
        public event EventHandler CanExecuteChanged
        {
            add     { CommandManager.RequerySuggested += value; }
            remove  { CommandManager.RequerySuggested -= value; }
        }

        /// <param name="methodToExecute">Action to execute if the canExecuteEvaluator returns true after the command is called.</param>
        /// <param name="canExecuteEvaluator">Evaluator funciton to decide if the command can execute.</param>
        public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
        {
            this.methodToExecute        = methodToExecute;
            this.canExecuteEvaluator    = canExecuteEvaluator;
        }


        /// <param name="methodToExecute">Action to execute when the command is called.</param>
        public RelayCommand(Action methodToExecute)
            : this(methodToExecute, null)
        {
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecuteEvaluator == null)
            {
                return true;
            }
            else
            {
                bool result = this.canExecuteEvaluator.Invoke();
                return result;
            }
        }

        public void Execute(object parameter)
        {
            this.methodToExecute.Invoke();
        }
    }

    public class RelayFunction : ICommand
    {
        private Func<object, bool> FunctionToExecute;
        private Func<bool> CanExecuteEvaluator;
       
        public event EventHandler CanExecuteChanged
        {
            add     { CommandManager.RequerySuggested += value; }
            remove  { CommandManager.RequerySuggested -= value; }
        }

        public RelayFunction(Func<object, bool> functionToExecute, Func<bool> canExecuteEvaluator)
        {
            this.FunctionToExecute      = functionToExecute;
            this.CanExecuteEvaluator    = canExecuteEvaluator;
        }
        public RelayFunction(Func<object, bool> functionToExecute) : this(functionToExecute, null) { }

        public bool CanExecute(object parameter)
        {
            if (this.CanExecuteEvaluator == null)
            {
                return true;
            }
            else
            {
                bool result = this.CanExecuteEvaluator.Invoke();
                return result;
            }
        }

        public void Execute(object parameter)
        {
            FunctionToExecute.Invoke(parameter);
        }
    }
}
