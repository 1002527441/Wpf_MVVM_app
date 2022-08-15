using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    public class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return DoCanExecute?.Invoke(parameter) == true;
        }

        public void Execute(object? parameter)
        {
            if (!CanExecute(parameter)) return;
            DoAction?.Invoke(parameter);
        }


        public void RaiseCanChanged()
        {
            CanExecuteChanged?.Invoke(this,new EventArgs());
        }

        public Action<object?> DoAction { get; set; } 

        public Func<object?, bool> DoCanExecute { get; set; }
    }
}
