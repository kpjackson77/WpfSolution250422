using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemoApp.Models
{
    class SomeData : INotifyPropertyChanged, IDataErrorInfo
    {
        public static string Fallback => "A Fallback value!";
        public static string TargetNull => "Target null!!";
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private int _val;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Val
        {
            get { return _val; }
            set
            { 
                if (_val != value)
                {
                    _val = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public SomeData()
        {
            Name = string.Empty;
        }
        string _errorMessage = "";
        public string Error => _errorMessage;

        public string this[string columnName]
        {
            get
            {
                string message = "";
                switch (columnName)
                {
                    case nameof(Name):
                        if (Name.Length > 20)
                        {
                            message = "Name too long!";
                            _errorMessage = message;
                        }
                        break;
                    case nameof(Val):
                        if (Val < 0 || Val > 100)
                        {
                            message = "Value to large!";
                        }
                        break;
                }
                _errorMessage = message;
                return message;
            }
        }

        public SomeData(string n, int v)
        {
            _name = n;
            _val = v;
        }
        //public override string ToString()
        //{
        //    return $"Name: {Name}, val: {Val}";
        //}
        public void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
