using Contoso.Samples.ConnectedServices.Views;
using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Contoso.Samples.ConnectedServices.ViewModels
{
    /// <summary>
    /// A view model for a single page configurator that contains an object picker control.
    /// </summary>
    internal class SinglePageViewModel : ConnectedServiceSinglePage
    {
        private ObservableCollection<ObjectPickerCategory> categories;
        private string errorMessage;

        public SinglePageViewModel()
        {
            this.categories = new ObservableCollection<ObjectPickerCategory>();
            this.Title = "Object Picker Sample";
            this.Description = "A sample provider that demonstrates an object picker control";
            this.IsFinishEnabled = true;
            this.View = new SinglePageView(this);
        }

        /// <summary>
        /// Access to the Context for config, progress and logging APIs
        /// </summary>
        public ConnectedServiceProviderContext Context { get; set; }

        /// <summary>
        /// Gets the top level categories that appear within the object picker control.
        /// </summary>
        public IEnumerable<ObjectPickerCategory> Categories
        {
            get { return this.categories; }
        }

        /// <summary>
        /// Gets the message that describes any errors that occurred while loading the objects to display in the object
        /// picker control.  If no errors occurred, null is returned.
        /// </summary>
        public string ErrorMessage
        {
            get { return this.errorMessage; }
            private set
            {
                this.errorMessage = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Loads the objects to display in the object picker control asynchronously.  A progress indicator
        /// is displayed while the objects are being loaded.
        /// </summary>
        public async Task LoadObjectsAsync()
        {
            using (this.Context.StartBusyIndicator("Loading Objects..."))
            {
                await Task.Delay(2000);  // A delay that illustrates the progress indicator functionality.

                try
                {
                    this.ErrorMessage = null;
                    this.categories.Clear();

                    // This code illustrates building up the tree content.  More than likely the provider
                    // would need to read metadata from the service and dynamically build up the content.
                    for (int i = 0; i < 2; i++)
                    {
                        ObjectPickerCategory category = new ObjectPickerCategory("Category " + i);
                        List<ObjectPickerObject> children = new List<ObjectPickerObject>();
                        category.Children = children;

                        for (int j = 0; j < 10; j++)
                        {
                            children.Add(new ObjectPickerObject(category, "Child " + j));
                        }

                        this.categories.Add(category);
                    }
                }
                catch (Exception e)
                {
                    // If an error occurs, display a message to the end user.
                    this.ErrorMessage = string.Format(
                        CultureInfo.CurrentCulture,
                        "There was an unexpected error while loading the objects. \r\n{0}",
                        e.ToString());
                }
            };
        }

        public override Task<ConnectedServiceInstance> GetFinishedServiceInstanceAsync()
        {
            Instance instance = new Instance();

            // Find which objects the end user has selected.
            instance.SelectedObjects = this.Categories
                ?.SelectMany(category => category.Children)
                .Where(child => child.IsChecked)
                .ToArray();

            return Task.FromResult<ConnectedServiceInstance>(instance);
        }
    }
}
