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
using System.Windows.Shapes;

namespace WpfDemoApp
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            theBorder.Child = new MainWindow();
        }

        private void Panels_Click(object sender, RoutedEventArgs e)
        {
            theBorder.Child = new PanelControl();
        }

        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            theBorder.Child = new GridControl();
        }

        private void Flow_Click(object sender, RoutedEventArgs e)
        {
            theBorder.Child = new FlowDocControl();
        }

        private void ElementBinding_Click(object sender, RoutedEventArgs e)
        {
            theBorder.Child = new ElementBindControl();
        }

        private void SimpleBinding_Click(object sender, RoutedEventArgs e)
        {
            theBorder.Child = new SimpleBindControl();
        }

        private void ListBinding_Click(object sender, RoutedEventArgs e)
        {
            theBorder.Child = new ListBindControl();
        }

        private void Validation_Click(object sender, RoutedEventArgs e)
        {
            theBorder.Child = new ValidationControl();
        }

        private void Colours_Click(object sender, RoutedEventArgs e)
        {
            theBorder.Child = new ColourControl();
        }

        private void ControlTemplate_Click(object sender, RoutedEventArgs e)
        {
            theBorder.Child = new ControlTemplateControl();
        }

        private void ResourcesStyles_Click(object sender, RoutedEventArgs e)
        {
            theBorder.Child = new ResourcesStylesControl();
        }
        private void AppCommand_Click(object sender, RoutedEventArgs e)
        {
            theBorder.Child = new AppCommandControl();
        }

        private void Threading_Click(object sender, RoutedEventArgs e)
        {
            theBorder.Child = new ThreadControl();
        }
    }
}
