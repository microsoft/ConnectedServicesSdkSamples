using Contoso.Samples.ConnectedServices.Authentication.Grid.ViewModels;
using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Contoso.Samples.ConnectedServices.Authentication.Grid
{
    [ConnectedServiceProviderExport("Microsoft.Samples.GridAuth")]
    internal class Provider : ConnectedServiceProvider
    {
        public Provider()
        {
            this.Category = "Contoso";
            this.Name = "Sample Configurator: Grid Auth";
            this.Description = "Sample Connected Service with Grid Auth functionality.";
            this.Icon = new BitmapImage(new Uri("pack://application:,,/" + this.GetType().Assembly.ToString() + ";component/Resources/ProviderIcon.png"));
            this.CreatedBy = "Microsoft";
            this.Version = new Version(1, 0, 0);
            this.MoreInfoUri = new Uri("http://aka.ms/ConnectedServicesSDK");
        }

        public override IEnumerable<Tuple<string, Uri>> GetSupportedTechnologyLinks()
        {
            // A list of supported technolgoies, such as which services it supports
            yield return Tuple.Create("Azure Active Directory", new Uri("http://azure.microsoft.com/en-us/services/active-directory/"));
        }

        public override Task<ConnectedServiceConfigurator> CreateConfiguratorAsync(ConnectedServiceProviderContext context)
        {
            ConnectedServiceConfigurator configurator = new GridViewModel();
            return Task.FromResult(configurator);
        }
    }
}
