using FlightWpf.Models;
using FlightWpf.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FlightWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
            var vm = new MainWindowVM();
            MainWindow = new MainWindow(vm);
            vm.AddPassengerLambda = () =>
              {
                  PassengerDetailsBuilderVM pdbvm = new PassengerDetailsBuilderVM();
                  pdbvm.Title = "Add Passenger";
                  AddWindow addDlg = new AddWindow();
                  addDlg.Owner = MainWindow;//Owner;//_wnd;
                addDlg.DataContext = pdbvm;
                  PassengerDetails pd = null;
                  if (addDlg.ShowDialog() ?? false)
                  {
                      pd = pdbvm.Create();
                  }
                  return pd;
              };

            vm.Owner = MainWindow;

            MainWindow.Show();
        }
    }
}
