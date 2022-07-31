using System;
using System.Collections.Generic;
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
    /// Interaction logic for ValidationControl.xaml
    /// </summary>
    public partial class ValidationControl : UserControl
    {
        public ValidationControl()
        {
            InitializeComponent();
            this.DataContext = new DoubleData();
            var int_data = new IntData();
            textBoxException.DataContext = int_data;
            labelException.DataContext = int_data;
            var some_data = new SomeData();
            textBoxInterface1.DataContext = some_data;
            labelInterface1.DataContext = some_data;
            validationGrid.DataContext = new SimpleData();
        }
    }
}
