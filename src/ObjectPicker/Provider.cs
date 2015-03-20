using Contoso.Samples.ConnectedServices.ViewModels;
using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Contoso.Samples.ConnectedServices
{
    /// <summary>
    /// A connected service provider that shows how an object picker control can be implemented.
    /// </summary>
    [ConnectedServiceProviderExport("Contoso.Samples.ObjectPicker")]
    internal class Provider : ConnectedServiceProvider
    {
        public Provider()
        {
            this.Name = "Sample: Object Picker";
            this.Category = "Contoso";
            this.Description = "A sample provider that demonstrates an object picker control.";
            this.Icon = new BitmapImage(new Uri("pack://application:,,/" + Assembly.GetExecutingAssembly().ToString() + ";component/" + "Resources/Icon.png"));
            this.CreatedBy = "Microsoft";
            this.Version = new Version(1, 0, 0);
            this.MoreInfoUri = new Uri("http://Microsoft.com");
        }

        public override Task<ConnectedServiceConfigurator> CreateConfiguratorAsync(ConnectedServiceProviderContext context)
        {
            ConnectedServiceConfigurator configurator = new SinglePageViewModel(context);
            return Task.FromResult(configurator);
        }
    }
}
