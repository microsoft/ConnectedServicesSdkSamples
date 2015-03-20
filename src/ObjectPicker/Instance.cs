using Contoso.Samples.ConnectedServices.ViewModels;
using Microsoft.VisualStudio.ConnectedServices;
using System.Collections.Generic;

namespace Contoso.Samples.ConnectedServices
{
    /// <summary>
    /// A connected service instance that contains the objects the user selected within the object picker control.
    /// </summary>
    internal class Instance : ConnectedServiceInstance
    {
        public Instance()
        {
        }

        public IEnumerable<ObjectPickerObject> SelectedObjects { get; set; }
    }
}
