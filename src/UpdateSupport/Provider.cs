using Contoso.Samples.ConnectedServices.UpdateSupport.ViewModels;
using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Contoso.Samples.ConnectedServices.UpdateSupport
{
    [ConnectedServiceProviderExport(
        "Contoso.Samples.UpdateSupport",
        SupportsUpdate = true)]
    internal class Provider : ConnectedServiceProvider
    {
        public Provider()
        {
            this.Name = "Sample: Update Support";
            this.Category = "Contoso";
            this.Description = "A sample handler demonstrating supporting update of a service";
            this.Icon = new BitmapImage(new Uri("pack://application:,,/" + Assembly.GetExecutingAssembly().ToString() + ";component/" + "Resources/Icon.png"));
            this.CreatedBy = "Microsoft";
            this.Version = new Version(1, 0, 0);
            this.MoreInfoUri = new Uri("http://Microsoft.com");
        }

        public override Task<ConnectedServiceConfigurator> CreateConfiguratorAsync(ConnectedServiceProviderContext context)
        {
            ConnectedServiceConfigurator configurator = new SinglePageViewModel();
            ((SinglePageViewModel)(configurator)).Context = context;

            return Task.FromResult(configurator);
        }
    }
}
