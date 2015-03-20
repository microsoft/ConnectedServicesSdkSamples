using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Contoso.Samples.ConnectedServices.Authentication.Grid.ViewModels
{
    /// <summary>
    /// A sample grid provider that:
    /// - shows one extra column in the grid and two properties in the details pane on the right
    /// - allows users to sign in and out by clicking a hyperlink
    /// - allows users to create new instances when they are signed in
    /// - allows users to configure instances
    /// </summary>
    internal class GridViewModel : ConnectedServiceGrid
    {
        private List<ConnectedServiceInstance> instances;

        public GridViewModel()
        {
            this.Description = "A sample Connected Service";

            this.CreateServiceInstanceText = "Create";

            this.CanConfigureServiceInstance = true;
            this.ConfigureServiceInstanceText = "Configure";
        }

        public override IEnumerable<Tuple<string, string>> ColumnMetadata
        {
            get { return new[] { Tuple.Create("Column1", "Column1 Display") }; }
        }

        public override IEnumerable<Tuple<string, string>> DetailMetadata
        {
            get
            {
                return new[]
                {
                    Tuple.Create("Detail1", "Detail1 Display"),
                    Tuple.Create("Detail2", "Detail2 Display")
                };
            }
        }

        /// <summary>
        /// Retrieves the ConnectedServiceInstance objects.  This is called when the grid gets loaded
        /// and when the user clicks the "Refresh" button.
        /// </summary>
        public override Task<IEnumerable<ConnectedServiceInstance>> EnumerateServiceInstancesAsync(CancellationToken ct)
        {
            // retrieve the service instances
            this.instances = new List<ConnectedServiceInstance>()
            {
                this.CreateInstance("#1", "1st column1", "1st detail1", "1st detail2"),
                this.CreateInstance("#2", "2nd column1", "2nd detail1", "2nd detail2"),
            };

            return Task.FromResult<IEnumerable<ConnectedServiceInstance>>(this.instances);
        }

        /// <summary>
        /// Creates the ConnectedServiceAuthenticator object, which controls whether the user is signed in.
        /// </summary>
        public override Task<ConnectedServiceAuthenticator> CreateAuthenticatorAsync()
        {
            ConnectedServiceAuthenticator authenticator = new AuthenticatorViewModel();
            authenticator.AuthenticationChanged += (sender, e) =>
            {
                this.CanCreateServiceInstance = authenticator.IsAuthenticated;
            };

            return Task.FromResult(authenticator);
        }

        /// <summary>
        /// Configures the selected ConnectedServiceInstance.
        /// </summary>
        public override Task<bool> ConfigureServiceInstanceAsync(ConnectedServiceInstance instance, CancellationToken ct)
        {
            // setting the Column1 property to "Configured" to show that this instance has been configured
            instance.Metadata["Column1"] = "Configured";

            return Task.FromResult(true);
        }

        /// <summary>
        /// Adds a new service instance to the grid.
        /// </summary>
        public override Task<ConnectedServiceInstance> CreateServiceInstanceAsync(CancellationToken ct)
        {
            int instanceNumber = this.instances.Count + 1;
            ConnectedServiceInstance newInstance = this.CreateInstance(
                "#" + instanceNumber,
                instanceNumber + " column1",
                instanceNumber + " detail1",
                instanceNumber + " detail2");
            this.instances.Add(newInstance);

            return Task.FromResult(newInstance);
        }

        /// <summary>
        /// Creates a new ConnectedServiceInstance with the specified values.
        /// </summary>
        private ConnectedServiceInstance CreateInstance(string name, string column1, string detail1, string detail2)
        {
            ConnectedServiceInstance instance = new ConnectedServiceInstance();
            instance.Name = name;
            instance.InstanceId = name;
            instance.Metadata.Add("Column1", column1);
            instance.Metadata.Add("Detail1", detail1);
            instance.Metadata.Add("Detail2", detail2);
            return instance;
        }
    }
}
