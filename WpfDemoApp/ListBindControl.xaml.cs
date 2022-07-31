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
using WpfDemoApp.Models;

namespace WpfDemoApp
{
    /// <summary>
    /// Interaction logic for ListBindControl.xaml
    /// </summary>
    public partial class ListBindControl : UserControl
    {
        ObservableCollection<SomeData> _data = new ObservableCollection<SomeData>();
        public ListBindControl()
        {
            InitializeComponent();

            _data.Add(new SomeData() { Name = "Fred", Val = 12 });
            _data.Add(new SomeData() { Name = "Jim", Val = 43 });
            _data.Add(new SomeData() { Name = "Alice", Val = 32 });
            this.DataContext = _data;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _data.Add(new SomeData() { Name = "Albert", Val = 11 });
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (_data.Count > 0)
            {
                _data[0].Name = "Graham";
            }
        }
    }
}
