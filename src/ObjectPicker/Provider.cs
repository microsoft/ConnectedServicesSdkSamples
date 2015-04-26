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
    [ConnectedServiceProviderExport("Microsoft.Samples.ObjectPicker")]
    internal class Provider : ConnectedServiceProvider
    {
        public Provider()
        {
            this.Name = "Sample: Object Picker";
            this.Category = "Contoso";
            this.Description = "A sample Connected Service demonstrating an object picker control.";
            this.Icon = new BitmapImage(new Uri("pack://application:,,/" + this.GetType().Assembly.ToString() + ";component/Resources/ProviderIcon.png"));
            this.CreatedBy = "Microsoft";
            this.Version = new Version(1, 0, 0);
            this.MoreInfoUri = new Uri("http://aka.ms/ConnectedServicesSDK");
        }

        public override Task<ConnectedServiceConfigurator> CreateConfiguratorAsync(ConnectedServiceProviderContext context)
        {
            SinglePageViewModel configurator = new SinglePageViewModel();
            configurator.Context = context;

            return Task.FromResult(configurator as ConnectedServiceConfigurator);

        }
    }
}
