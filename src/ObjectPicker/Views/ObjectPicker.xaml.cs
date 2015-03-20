using Contoso.Samples.ConnectedServices.ViewModels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Contoso.Samples.ConnectedServices.Views
{
    /// <summary>
    /// A control that displays a set of objects in a hierarchical view and allows the user to select
    /// a subset of the objects.  This control is intended allow users to choose which objects to include
    /// in their connected service.
    /// </summary>
    internal partial class ObjectPicker : UserControl
    {
        /// <summary>
        /// The DependencyProperty for the ObjectPicker.Categories property.
        /// </summary>
        public static readonly DependencyProperty CategoriesProperty = DependencyProperty.Register(
            nameof(ObjectPicker.Categories),
            typeof(IEnumerable<ObjectPickerCategory>),
            typeof(ObjectPicker),
            new PropertyMetadata(null));

        /// <summary>
        /// The DependencyProperty for the ObjectPicker.ErrorMessage property.
        /// </summary>
        public static readonly DependencyProperty ErrorMessageProperty = DependencyProperty.Register(
            nameof(ObjectPicker.ErrorMessage),
            typeof(string),
            typeof(ObjectPicker),
            new PropertyMetadata(null));

        /// <summary>
        /// Instantiates a new instance of the ObjectPicker class.
        /// </summary>
        public ObjectPicker()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the collection of ObjectPickerCategory objects to display in the ObjectPicker.
        /// </summary>
        public IEnumerable<ObjectPickerCategory> Categories
        {
            get { return (IEnumerable<ObjectPickerCategory>)this.GetValue(ObjectPicker.CategoriesProperty); }
            set { this.SetValue(ObjectPicker.CategoriesProperty, value); }
        }

        /// <summary>
        /// Gets or sets the error message that occurred while constructing the objects to display in the
        /// ObjectPicker.  This error message gets displayed within the ObjectPicker as a means to indicate
        /// to the end user what the issue was that prevented the objects from being displayed.
        /// </summary>
        public string ErrorMessage
        {
            get { return (string)this.GetValue(ObjectPicker.ErrorMessageProperty); }
            set { this.SetValue(ObjectPicker.ErrorMessageProperty, value); }
        }
    }
}

