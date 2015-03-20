using System.Windows;
using System.Windows.Input;

namespace Contoso.Samples.ConnectedServices.Views
{
    /// <summary>
    /// Represents a virtual toggle button.  This is used when it is necessary for 
    /// non-toggleable control (e.g TreeViewItem) to behave like a toggle buttons.
    /// </summary>
    internal static class VirtualToggleButton
    {
        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.RegisterAttached(
            "IsChecked",
            typeof(bool?),
            typeof(VirtualToggleButton),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public static void SetIsChecked(DependencyObject element, bool value)
        {
            element.SetValue(VirtualToggleButton.IsCheckedProperty, value);
        }

        public static bool? GetIsChecked(DependencyObject element)
        {
            return (bool?)element.GetValue(VirtualToggleButton.IsCheckedProperty);
        }

        public static readonly DependencyProperty IsVirtualToggleButtonProperty = DependencyProperty.RegisterAttached(
            "IsVirtualToggleButton",
            typeof(bool),
            typeof(VirtualToggleButton),
            new FrameworkPropertyMetadata(false, new PropertyChangedCallback(VirtualToggleButton.OnIsVirtualToggleButtonChanged)));

        public static void SetIsVirtualToggleButton(DependencyObject element, bool value)
        {
            element.SetValue(VirtualToggleButton.IsVirtualToggleButtonProperty, value);
        }

        public static bool GetIsVirtualToggleButton(DependencyObject element)
        {
            return (bool)element.GetValue(VirtualToggleButton.IsVirtualToggleButtonProperty);
        }

        private static void OnIsVirtualToggleButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            IInputElement element = d as IInputElement;

            if (element != null)
            {
                if ((bool)e.NewValue)
                {
                    element.MouseLeftButtonDown += VirtualToggleButton.OnMouseLeftButtonDown;
                    element.KeyDown += VirtualToggleButton.OnKeyDown;
                }
                else
                {
                    element.MouseLeftButtonDown -= VirtualToggleButton.OnMouseLeftButtonDown;
                    element.KeyDown -= VirtualToggleButton.OnKeyDown;
                }
            }
        }

        private static void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            VirtualToggleButton.UpdateIsChecked((DependencyObject)sender);
        }

        private static void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.OriginalSource == sender && e.Key == Key.Space)
            {
                // ignore alt + space which invokes the system menu
                if ((Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt)
                {
                    return;
                }

                VirtualToggleButton.UpdateIsChecked((DependencyObject)sender);
                e.Handled = true;
            }
        }

        private static void UpdateIsChecked(DependencyObject d)
        {
            bool? isChecked = VirtualToggleButton.GetIsChecked(d);
            if (isChecked.HasValue == false)
            {
                VirtualToggleButton.SetIsChecked(d, false);
            }
            else if (isChecked == true)
            {
                VirtualToggleButton.SetIsChecked(d, false);
            }
            else if (isChecked == false)
            {
                VirtualToggleButton.SetIsChecked(d, true);
            }
        }
    }
}

