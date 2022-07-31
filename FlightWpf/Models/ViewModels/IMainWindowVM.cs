using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace FlightWpf.Models.ViewModels
{
    public interface IMainWindowVM
    {
        ICommand AddPassengerCommand { get; }
        ICommand Edit2PassengerCommand { get; }
        ICommand EditPassengerCommand { get; }
        ObservableCollection<PassengerDetails> Passengers { get; }
        ICommand RemovePassengerCommand { get; }
        ICommand SelectionChangedCommand { get; }
        Window Owner { get; set; }
    }
}