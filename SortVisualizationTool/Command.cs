using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SortVisualizationTool
{
    class Command : ICommand

    {
        public event EventHandler CanExecuteChanged;
        public Action<Object> executeMethod;
        public Func<object, bool> canExecuteMethod;

        public Command(Action<object> action, Func<object, bool> func)
        {
            this.executeMethod = action;
            this.canExecuteMethod = func;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }
    }
}
