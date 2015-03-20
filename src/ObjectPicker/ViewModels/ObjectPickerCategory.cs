using System.Collections.Generic;
using System.Linq;

namespace Contoso.Samples.ConnectedServices.ViewModels
{
    /// <summary>
    /// Represents a category that groups similar objects within the ObjectPicker.
    /// </summary>
    public class ObjectPickerCategory : ObjectPickerItem
    {
        private IEnumerable<ObjectPickerObject> children;

        /// <summary>
        /// Instantiates a new instance of the ObjectPickerCategory class.
        /// </summary>
        /// <param name="name">
        /// The name of the category.
        /// </param>
        public ObjectPickerCategory(string name) : base(name, true)
        {
        }

        /// <summary>
        /// Gets or sets the collection of ObjectPickerObjects to display within the category.
        /// </summary>
        public IEnumerable<ObjectPickerObject> Children
        {
            get
            {
                return this.children ?? Enumerable.Empty<ObjectPickerObject>();
            }
            set
            {
                this.children = value;
                this.OnPropertyChanged();
                this.UpdateSelectionState();
            }
        }

        /// <summary>
        /// Gets or sets a Boolean value indicating whether none (false), some (null), or all (true) of the category's
        /// children are checked.
        /// </summary>
        public bool? IsChecked
        {
            get
            {
                if (this.Children.All(c => !c.IsChecked))
                {
                    return false;
                }
                else if (this.Children.All(c => c.IsChecked))
                {
                    return true;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value.HasValue)
                {
                    // Checking/Unchecking should never change disabled items.  This is applicable in update
                    // scenarios where previously picked objects are disabled and can't be changed.
                    foreach (ObjectPickerObject child in this.Children.Where(c => c.IsEnabled))
                    {
                        child.IsChecked = value.Value;
                    }
                }
            }
        }

        /// <summary>
        /// Recomputes the selection state of the category.
        /// </summary>
        public void UpdateSelectionState()
        {
            this.OnPropertyChanged(nameof(ObjectPickerCategory.IsChecked));
        }
    }
}

