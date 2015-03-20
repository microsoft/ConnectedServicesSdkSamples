using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Contoso.Samples.ConnectedServices.UITemplates.Grid.ViewModels
{
    internal class GridViewModel : ConnectedServiceGrid
    {
        private List<ConnectedServiceInstance> instances;

        public GridViewModel()
        {
            this.Description = "Description: Configure the Contoso Service";
            // Enables the Configure Service link above the grid. 
            // Implication is configuration to the overall service, not one of the consumption units of the service
            // For instance, Configure the overall Azure Storage service, vs. some storage containers
            this.CanConfigureService = true;
            // Text displayed. At one point, there was no default text. 
            this.ConfigureServiceText = "Config Service";

            // Toggles the Create button in the bottom left corner allowing the developer to create new instances 
            // and populate rows in the grid
            this.CanCreateServiceInstance = true;
            // Changes the default text in the bottom left of the grid
            this.CreateServiceInstanceText = "Create*";

            // Toggles the visibility of the configure in the right pane
            this.CanConfigureServiceInstance = true;
            // Change of default text for configuring in the right pane
            this.ConfigureServiceInstanceText = "Configure Instance";

            // The first column of the grid. Allowing the provider author to customize the column heading
            this.ServiceInstanceNameLabelText = "Service Name";
            // Text over the top of the grid. Overrides the default text
            this.GridHeaderText = "GridHeaderText: explaining what the developer should do";
        }

        public override IEnumerable<Tuple<string, string>> ColumnMetadata
        {
            get
            {
                // Ability to set the column names, and can add new columns, 
                // Note, the Name, or first parameter of th Tuple must be unique across ColumnMetaData and DetailMetadata
                // The single Instance.Metadata collection is shared across Column and Detail properties
                yield return Tuple.Create("Column2", "Column2 Display");
                yield return Tuple.Create("Column3", "Column3 Display");
            }
        }

        public override IEnumerable<Tuple<string, string>> DetailMetadata
        {
            get
            {
                // Labels added
                yield return Tuple.Create("Detail1", "Detail1 Display");
                yield return Tuple.Create("Detail2", "Detail2 Display");
                yield return Tuple.Create("Detail3", "Detail3 Display");
            }
        }

        public override Task<ConnectedServiceAuthenticator> CreateAuthenticatorAsync()
        {
            // Adds content to the Authenticator "black box" in the top right corner
            ConnectedServiceAuthenticator authenticator = new AuthenticatorViewModel();
            authenticator.AuthenticationChanged += (sender, e) =>
            {
                // If not set to true, the grid has default behavior to prompt for authentication
                this.CanCreateServiceInstance = authenticator.IsAuthenticated;
            };

            return Task.FromResult(authenticator);
        }
        /// <summary>
        /// Retrieve the service instances
        /// Called by the Refresh link as well. 
        /// </summary>
        public override Task<IEnumerable<ConnectedServiceInstance>> EnumerateServiceInstancesAsync(CancellationToken ct)
        {
            // for the purposes of this sample, we re-create them each time
            // In a real scenario, you'd like call a discovery api on your service to retrieve the info
            // Notice that clicking Refresh replaces all the instances
            this.instances = new List<ConnectedServiceInstance>(){
                // Note: CreateInstance is method in this class that generalizes adding Columns and Metadata 
                // to a grid row, or a specific instance
                this.CreateInstance("#1", "1st column2", "1st Column3", "1st detail1", "1st detail2", "1st detail3"),
                this.CreateInstance("#2", "2nd column2", "2nd Column3", "2nd detail1", "2nd detail2", "2nd detail3"),
            };

            return Task.FromResult<IEnumerable<ConnectedServiceInstance>>(this.instances);
        }

        /// <summary>
        /// Configured the overall service
        /// </summary>
        public override Task ConfigureServiceAsync(CancellationToken ct)
        {
            System.Windows.MessageBox.Show("Configure Your Service", "Connected Service", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Information);
            return base.ConfigureServiceAsync(ct);
        }

        /// <summary>
        /// Configures the specific instance, a unit within the overall service
        /// </summary>
        /// <returns></returns>
        public override Task<bool> ConfigureServiceInstanceAsync(ConnectedServiceInstance instance, CancellationToken ct)
        {
            // Called by the Configure link on the right pane
            instance.Metadata["Column2"] = "Configured";
            return Task.FromResult(true);
        }

        /// <summary>
        /// Creates an entry displayed in the grid
        /// </summary>
        public override Task<ConnectedServiceInstance> CreateServiceInstanceAsync(CancellationToken ct)
        {
            // Called by the Create link in the bottom left corner, if enabled
            int instanceNumber = this.instances.Count + 1;
            ConnectedServiceInstance newInstance = this.CreateInstance(
                "#" + instanceNumber,
                instanceNumber + " column2",
                instanceNumber + " column3",
                instanceNumber + " detail1",
                instanceNumber + " detail2",
                instanceNumber + " detail3");
            this.instances.Add(newInstance);

            return Task.FromResult(newInstance);
        }

        /// <summary>
        /// Creates a specific instance for this particualr provider
        /// </summary>
        /// <param name="name">The display name of the configured instance</param>
        /// <param name="column2">Value in the 2nd column. First column is the name</param>
        /// <param name="column3">Value in the 3rd column</param>
        /// <param name="detail1">Metadata displayed to the right of the grid</param>
        /// <param name="detail2">Metadata displayed to the right of the grid</param>
        /// <param name="detail3">Metadata displayed to the right of the grid</param>
        /// <returns></returns>
        private ConnectedServiceInstance CreateInstance(string name, string column2, string column3, string detail1, string detail2, string detail3)
        {
            ConnectedServiceInstance instance = new ConnectedServiceInstance();
            instance.Name = name;
            instance.InstanceId = name;
            instance.Metadata.Add("Column2", column2);
            instance.Metadata.Add("Column3", column3);
            instance.Metadata.Add("Detail1", detail1);
            instance.Metadata.Add("Detail2", detail2);
            instance.Metadata.Add("Detail3", detail3);
            return instance;
        }
    }
}