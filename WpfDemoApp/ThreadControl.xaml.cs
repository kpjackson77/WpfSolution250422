using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfDemoApp
{
    /// <summary>
    /// Interaction logic for ThreadControl.xaml
    /// </summary>
    public partial class ThreadControl : UserControl
    {
        BackgroundWorker _bgw = new BackgroundWorker();
        ObservableCollection<string> _items = new ObservableCollection<string>();
        Object _syncObject = new object();
        ManualResetEvent _mre = new ManualResetEvent(false);
        public ThreadControl()
        {
            InitializeComponent();
            listBoxEntries.ItemsSource = _items;
            _bgw.DoWork += _bgw_DoWork;
            _bgw.WorkerReportsProgress = true;
            _bgw.ProgressChanged += _bgw_ProgressChanged;
            BindingOperations.EnableCollectionSynchronization(_items, _syncObject);
        }
        private void _bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action<string>(UpdateList), $"Progress: {e.ProgressPercentage}");
        }
        private void _bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            int size = 5;// (int)st;
            for (int i = 0; i < size; i++)
            {
                //listBoxEntries.Items.Add(i);
                Thread.Sleep(1000);
                _bgw.ReportProgress((int)((i+1) * 100.0) / size);
                Dispatcher.BeginInvoke(new Action<string>(UpdateList), i.ToString());
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _bgw.RunWorkerAsync();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((st) =>
            {
                int size = (int)st;
                for (int i = 0; !_mre.WaitOne(0, false) && i < size; i++)
                {
                    Thread.Sleep(1000);
                    //listBoxEntries.Items.Add(i);
                    UpdateList(i.ToString());
                    //Dispatcher.BeginInvoke(new Action<string>(UpdateList), i.ToString());
                }
            }),10);
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            _mre.Set();
            Thread.Sleep(1500);
            _mre.Reset();
        }
        private void UpdateList(string msg)
        {
            //listBoxEntries.Items.Add(msg);
            _items.Add(msg);
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var th = new Thread(new ParameterizedThreadStart((st) =>
            {
                int size = (int)st;
                for (int i = 0; i < size; i++)
                {
                    //listBoxEntries.Items.Add(i);
                    Dispatcher.BeginInvoke(new Action<string>(UpdateList), i.ToString());
                }
            }));

            th.Start(10);

            //th.Join();
        }
        private Task<string> GetMessage()
        {
            return Task<string>.FromResult("Greetings from Async!");
        }
        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string result = await GetMessage();

            _items.Add(result);
        }

      
    }
}
