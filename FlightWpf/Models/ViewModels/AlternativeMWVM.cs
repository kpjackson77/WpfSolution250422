using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FlightWpf.Models.ViewModels
{
    class AlternativeMWVM : IMainWindowVM
    {
        public ICommand AddPassengerCommand => throw new NotImplementedException();

        public ICommand Edit2PassengerCommand => throw new NotImplementedException();

        public ICommand EditPassengerCommand => throw new NotImplementedException();

        public ObservableCollection<PassengerDetails> Passengers => throw new NotImplementedException();

        public ICommand RemovePassengerCommand => throw new NotImplementedException();

        public ICommand SelectionChangedCommand => throw new NotImplementedException();

        public Window Owner { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
