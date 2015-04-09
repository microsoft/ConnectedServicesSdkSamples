using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ConnectedServiceSample
{
    [ConnectedServiceProviderExport("Contoso.SampleService")]
    internal class Provider : ConnectedServiceProvider
    {
        public Provider()
        {
            this.Category = "Sample";
            this.Name = "Sample Provider";
            this.Description = "A sample provider for Connected Services";
            this.Icon = new BitmapImage(new Uri("pack://application:,,/" + Assembly.GetExecutingAssembly().ToString() + ";component/" + "Resources/Icon.png"));
            this.CreatedBy = "Contoso";
            this.Version = new Version(1, 0, 0);
            this.MoreInfoUri = new Uri("https://github.com/Microsoft/ConnectedServices-ProviderAuthorSamples");
        }

        public override Task<ConnectedServiceConfigurator> CreateConfiguratorAsync(ConnectedServiceProviderContext context)
        {
            ConnectedServiceConfigurator configurator = new ViewModels.SinglePageViewModel();
            return Task.FromResult<ConnectedServiceConfigurator>(configurator);
        }
    }
}