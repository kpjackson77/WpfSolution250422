using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemoApp.Models
{
    class SimpleData : INotifyDataErrorInfo
    {
        Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        private string _desc;
        public string Desc
        {
            get { return _desc; }
            set
            {
                ClearErrors(nameof(Desc));
                if (value.Length > 20)
                {
                    AddError(nameof(Desc), "Description too long!");
                }
                else
                {
                    _desc = value;
                }
            }
        }
        private int _val;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        public int Val
        {
            get { return _val; }
            set
            {
                ClearErrors(nameof(Val));
                int cnt = 0;
                if (value < 0 || value > 100)
                {
                    AddError(nameof(Val), "Value out of range!");
                    cnt++;
                }
                if (value % 2 != 0)
                {
                    AddError(nameof(Val), "Value odd!");
                    cnt++;
                }
                if (cnt == 0)
                {
                    _val = value;
                }
            }
        }
        private void ClearErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }
        private void AddError(string propertyName, string message)
        {
            if (!_errors.ContainsKey(propertyName)) _errors[propertyName] = new List<string>();

            if (!_errors[propertyName].Contains(message))
            {
                _errors[propertyName].Add(message);
                OnErrorsChanged(propertyName);
            }
        }
        public bool HasErrors => _errors.Any();
        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) return null;
            if (_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }
            return null;
        }
    }
}
