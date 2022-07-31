using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfDemoApp
{
    class SelectAllBehaviour :Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.GotFocus += AssociatedObject_GotFocus;
        }

        private void AssociatedObject_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.SelectAll();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.GotFocus -= AssociatedObject_GotFocus;
        }
    }
}
