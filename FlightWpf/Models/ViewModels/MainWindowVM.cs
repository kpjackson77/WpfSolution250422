using FlightWpf.Models.ViewModels;
using FlightWpf.Utilities;
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
    class MainWindowVM : IMainWindowVM
    {
        Window _wnd = null;
        public ObservableCollection<PassengerDetails> Passengers { get; }

        //private object _selectedItem;

        //public object SelectedItem
        //{
        //    get { return _selectedItem; }
        //    set { _selectedItem = value;
        //        ((DelegateCommand)RemovePassengerCommand).RaiseCanExecuteChanged();
        //        ((DelegateCommand)EditPassengerCommand).RaiseCanExecuteChanged();
        //    }
        //}

        public ICommand AddPassengerCommand { get; }
        public ICommand RemovePassengerCommand { get; }
        public ICommand EditPassengerCommand { get; }
        public ICommand Edit2PassengerCommand { get; }
        public ICommand SelectionChangedCommand { get; }

        public Window Owner { get; set; }
        public MainWindowVM(Window wnd = null)
        {
            //_wnd = wnd;
            Owner = wnd;
            Passengers = new ObservableCollection<PassengerDetails>();
            AddPassengerCommand = new DelegateCommand(AddPassenger);
            RemovePassengerCommand = new DelegateCommand(RemovePassenger, CanRemovePassenger);
            EditPassengerCommand = new DelegateCommand(EditPassenger, CanEditPassenger);
            Edit2PassengerCommand = new DelegateCommand(Edit2Passenger, CanEditPassenger);
            SelectionChangedCommand = new DelegateCommand(SelectionChanged);
        }
        private void SelectionChanged(object param = null)
        {
            ((DelegateCommand)RemovePassengerCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)EditPassengerCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)Edit2PassengerCommand).RaiseCanExecuteChanged();
        }
        public Func<PassengerDetails> AddPassengerLambda { get; set; }
        private void AddPassenger(object param)
        {
            //PassengerDetailsBuilderVM pdbvm = new PassengerDetailsBuilderVM();
            //pdbvm.Title = "Add Passenger";
            //AddWindow addDlg = new AddWindow();
            //addDlg.Owner = Owner;//_wnd;
            //addDlg.DataContext = pdbvm;
            //if (addDlg.ShowDialog() ?? false)
            //{
            //    Passengers.Add(pdbvm.Create());
            //    SelectionChanged();
            //}

            var pd = AddPassengerLambda();

            if( pd != null)
            {
                Passengers.Add(pd);
                SelectionChanged();
            }
        }
        private void EditPassenger(object param)
        {
            var pd = param as PassengerDetails;
            if (pd != null)
            {
                PassengerDetailsBuilderVM pdbvm = new PassengerDetailsBuilderVM(pd);
                pdbvm.Title = "Edit Passenger";
                AddWindow addDlg = new AddWindow();
                addDlg.Owner = _wnd;
                addDlg.DataContext = pdbvm;
                if (addDlg.ShowDialog() ?? false)
                {
                    Passengers.Remove(pd);
                    Passengers.Add(pdbvm.Create());
                    SelectionChanged();
                }
            }
        }
        private void Edit2Passenger(object param)
        {
            var pd = param as PassengerDetails;
            if (pd != null)
            {
                PassengerDetailsVM pdbvm = new PassengerDetailsVM(pd);
                pdbvm.Title = "Edit Passenger";
                EditWindow addDlg = new EditWindow();
                addDlg.Owner = _wnd;
                addDlg.DataContext = pdbvm;
                if (addDlg.ShowDialog() ?? false)
                {
                    SelectionChanged();
                }
            }
        }
        private bool CanRemovePassenger(object param)
        {
            return param != null;
        }
        private bool CanEditPassenger(object param)
        {
            return param != null;
        }
        private void RemovePassenger(object param)
        {
            var pd = param as PassengerDetails;
            if (pd != null)
            {
                Passengers.Remove(pd);
                //((DelegateCommand)RemovePassengerCommand).RaiseCanExecuteChanged();
                //((DelegateCommand)EditPassengerCommand).RaiseCanExecuteChanged();
                SelectionChanged();
            }
        }
    }
}
