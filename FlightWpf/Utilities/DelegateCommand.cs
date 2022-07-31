using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightWpf.Utilities
{
    class DelegateCommand : ICommand
    {
        private Action<object> _act;
        private Predicate<object> _pred;
        public DelegateCommand(Action<object> act, Predicate<object> pred = null)
        {
            _act = act;
            _pred = pred;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return _pred != null ? _pred(parameter): true;
        }
        public void Execute(object parameter)
        {
            _act(parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
