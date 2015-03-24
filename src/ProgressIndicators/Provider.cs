using Contoso.Samples.ConnectedServices.ProgressIndicators.ViewModels;
using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Contoso.Samples.ConnectedServices.ProgressIndicators
{
    [ConnectedServiceProviderExport(
        "Contoso.Samples.ProgressIndicators")]
    internal class Provider : ConnectedServiceProvider
    {
        public Provider()
        {
            this.Name = "Sample: Progress Indicators";
            this.Category = "Contoso";
            this.Description = "A sample handler demonstrating supporting progress indication";
            this.Icon = new BitmapImage(new Uri("pack://application:,,/" + Assembly.GetExecutingAssembly().ToString() + ";component/" + "Resources/Icon.png"));
            this.CreatedBy = "Microsoft";
            this.Version = new Version(1, 0, 0);
            this.MoreInfoUri = new Uri("http://Microsoft.com");
        }

        //TODO: Move context to ConnectedServiceConfigurator, remove from CreateConfiguratorAsync to improve programming model, 
        // and support WPF default constructors for intellisense and WYSIWYG designers
        public override Task<ConnectedServiceConfigurator> CreateConfiguratorAsync(ConnectedServiceProviderContext context)
        {
            ConnectedServiceConfigurator configurator = new SinglePageViewModel();
            //TODO: Move context to ConnectedServiceConfigurator
            ((SinglePageViewModel)(configurator)).Context = context;

            return Task.FromResult(configurator);
        }
    }
}
