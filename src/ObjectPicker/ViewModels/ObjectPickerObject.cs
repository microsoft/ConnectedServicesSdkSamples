namespace Contoso.Samples.ConnectedServices.ViewModels
{
    /// <summary>
    /// Represents a selectable object within the ObjectPicker.
    /// </summary>
    public class ObjectPickerObject : ObjectPickerItem
    {
        private bool isChecked;
        private ObjectPickerCategory parent;
        private object state;

        /// <summary>
        /// Instantiates a new instance of the ObjectPickerObject class.
        /// </summary>
        /// <param name="parent">
        /// The ObjectPickerCategory that contains this object.
        /// </param>
        /// <param name="name">
        /// The name of the object.
        /// </param>
        public ObjectPickerObject(ObjectPickerCategory parent, string name)
            : base(name, false)
        {
            this.parent = parent;
        }

        /// <summary>
        /// Gets or sets a Boolean value that indicates whether the object is checked.
        /// </summary>
        public bool IsChecked
        {
            get { return this.isChecked; }
            set
            {
                if (this.isChecked != value)
                {
                    this.isChecked = value;
                    this.parent.UpdateSelectionState();
                    this.OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Gets or sets custom state to track with this object.
        /// </summary>
        public object State
        {
            get { return this.state; }
            set { this.state = value; }
        }
    }
}
