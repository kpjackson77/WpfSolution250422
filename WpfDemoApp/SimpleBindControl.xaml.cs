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
    /// Interaction logic for SimpleBindControl.xaml
    /// </summary>
    public partial class SimpleBindControl : UserControl
    {
        public SimpleBindControl()
        {
            InitializeComponent();
            this.DataContext = new SomeData() { Name = "Fred", Val = 42 };
            textBoxName.DataContext = new SomeData { Name = null, Val = 12 };
            textBoxVal.DataContext = null;
         }
    }
}
