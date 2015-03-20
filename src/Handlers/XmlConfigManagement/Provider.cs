using Contoso.Samples.ConnectedServices.Handlers.XmlConfigManagement.ViewModels;
using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Contoso.Samples.ConnectedServices.Handlers.XmlConfigManagement
{
    [ConnectedServiceProviderExport("Contoso.Samples.XmlConfigManagement")]
    internal class Provider : ConnectedServiceProvider
    {
        public Provider()
        {
            this.Name = "Sample: Xml Config Management";
            this.Category = "Contoso";
            this.Description = "A sample provider demonstrating xml config management";
            this.Icon = new BitmapImage(new Uri("pack://application:,,/" + Assembly.GetExecutingAssembly().ToString() + ";component/" + "Resources/Icon.png"));
            this.CreatedBy = "Microsoft";
            this.Version = new Version(1, 0, 0);
            this.MoreInfoUri = new Uri("http://Microsoft.com");
        }

        public override IEnumerable<Tuple<string, Uri>> GetSupportedTechnologyLinks()
        {
            yield return Tuple.Create("Azure Redis Cache", new Uri("http://azure.microsoft.com/en-us/services/cache/"));
        }

        public override Task<ConnectedServiceConfigurator> CreateConfiguratorAsync(ConnectedServiceProviderContext context)
        {
            return Task.FromResult<ConnectedServiceConfigurator>(new SinglePageViewModel());
        }
    }
}