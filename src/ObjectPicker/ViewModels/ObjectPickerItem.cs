using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Contoso.Samples.ConnectedServices.ViewModels
{
    /// <summary>
    /// Represents an item within the ObjectPicker.
    /// </summary>
    public abstract class ObjectPickerItem : INotifyPropertyChanged
    {
        private bool isTextSearchEnabled;
        private bool isEnabled;
        private bool isSelected;
        private string name;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Instantiates a new instance of the ObjectPickerItem class.
        /// </summary>
        /// <param name="name">
        /// The name of the item.
        /// </param>
        /// <param name="isTextSearchEnabled">
        /// A Boolean value which indicates whether TextSearch is enabled on this item.
        /// </param>
        protected ObjectPickerItem(string name, bool isTextSearchEnabled)
        {
            this.isTextSearchEnabled = isTextSearchEnabled;
            this.name = name;
            this.isEnabled = true;
        }

        /// <summary>
        /// Gets a Boolean value which indicates whether TextSearch is enabled on this item.
        /// </summary>
        public bool IsTextSearchEnabled
        {
            get { return this.isTextSearchEnabled; }
        }

        /// <summary>
        /// Gets a Boolean value which indicates whether the item is enabled.
        /// </summary>
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set
            {
                this.isEnabled = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets a Boolean value which indicates whether the item is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                this.isSelected = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            // ToString is overridden to support the screen readers.
            return this.Name;
        }

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="name">
        /// The name of the property that changed.
        /// </param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

