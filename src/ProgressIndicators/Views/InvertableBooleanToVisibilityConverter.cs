using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;

namespace Contoso.Samples.ConnectedServices.ProgressIndicators.Views
{
    internal class InvertableBooleanToVisibilityConverter : IValueConverter
    {
        public enum Parameters
        {
            Normal,
            Inverted
        }

        public InvertableBooleanToVisibilityConverter()
        {
            this.NonVisibleVisibility = Visibility.Collapsed;
        }

        public Visibility NonVisibleVisibility { get; set; }

        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            Debug.Assert(parameter != null, "you need to specify Normal or Inverted to your InvertableBooleanToVisibilityConverter!");
            if (value == null)
            {
                return this.NonVisibleVisibility;
            }

            bool boolVal = (bool)value;
            Parameters direction = (Parameters)Enum.Parse(typeof(Parameters), (string)parameter);

            if (direction == Parameters.Normal)
            {
                return boolVal ? Visibility.Visible : this.NonVisibleVisibility;
            }
            else
            {
                return boolVal ? this.NonVisibleVisibility : Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
