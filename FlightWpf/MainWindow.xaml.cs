using FlightWpf.Models;
using FlightWpf.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlightWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //ObservableCollection<PassengerDetails> _details = new ObservableCollection<PassengerDetails>();
        ObservableCollection<PassengerDetails> _newDetails = new ObservableCollection<PassengerDetails>();
        public MainWindow(IMainWindowVM vm)
        {
            InitializeComponent();

            DataContext = vm;//new MainWindowVM(this);
            tabControlPassengers.ItemsSource = _newDetails;
            buttonAsync.DataContext = new AsyncVM();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _newDetails.Add(new PassengerDetails());
            tabControlPassengers.SelectedIndex = _newDetails.Count - 1;
        }
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //_details.Add(new PassengerDetails("Fred", 12));
        //    PassengerDetailsBuilderVM pdbvm = new PassengerDetailsBuilderVM();
        //    AddWindow addDlg = new AddWindow();
        //    addDlg.Owner = this;
        //    addDlg.DataContext = pdbvm;
        //    if( addDlg.ShowDialog() ?? false)
        //    {
        //        _details.Add(pdbvm.Create());
        //    }
        //}
    }
}
