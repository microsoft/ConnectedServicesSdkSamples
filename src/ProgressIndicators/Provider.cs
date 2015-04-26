using Contoso.Samples.ConnectedServices.ProgressIndicators.ViewModels;
using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Contoso.Samples.ConnectedServices.ProgressIndicators
{
    [ConnectedServiceProviderExport(
        "Microsoft.Samples.ProgressIndicators")]
    internal class Provider : ConnectedServiceProvider
    {
        public Provider()
        {
            this.Name = "Sample: Progress Indicators";
            this.Category = "Contoso";
            this.Description = "A sample handler demonstrating supporting progress indication";
            this.Icon = new BitmapImage(new Uri("pack://application:,,/" + this.GetType().Assembly.ToString() + ";component/Resources/ProviderIcon.png"));
            this.CreatedBy = "Microsoft";
            this.Version = new Version(1, 0, 0);
            this.MoreInfoUri = new Uri("http://aka.ms/ConnectedServicesSDK");
        }

        public override Task<ConnectedServiceConfigurator> CreateConfiguratorAsync(ConnectedServiceProviderContext context)
        {
            ConnectedServiceConfigurator configurator = new SinglePageViewModel();
            ((SinglePageViewModel)(configurator)).Context = context;

            return Task.FromResult(configurator);
        }
    }
}
