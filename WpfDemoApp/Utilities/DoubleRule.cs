using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfDemoApp.Utilities
{
    class DoubleRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double result;
            ValidationResult vr = null;
            try
            {
                string strVal = value as string;
                result = double.Parse(strVal);
                vr = ValidationResult.ValidResult;
            }
            catch (FormatException)
            {
                vr = new ValidationResult(false, "Invalid Format!");
            }
            catch( OverflowException)
            {
                vr = new ValidationResult(false, "Number overflow!");
            }

            return vr;
        }
    }
}
