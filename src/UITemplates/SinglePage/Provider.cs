using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Contoso.Samples.ConnectedServices.UITemplates.SinglePage
{
    [ConnectedServiceProviderExport("Contoso.Samples.SinglePageUITemplate")]
    internal class Provider : ConnectedServiceProvider
    {
        public Provider()
        {
            this.Name = "Sample: Single Page Template";
            this.Category = "Contoso";
            this.Description = "A sample provider demonstrating the Single Page UI template";
            this.Icon = new BitmapImage(new Uri("pack://application:,,/" + Assembly.GetExecutingAssembly().ToString() + ";component/" + "Resources/Icon.png"));
            this.CreatedBy = "Microsoft";
            this.Version = new Version(1, 0, 0);
            this.MoreInfoUri = new Uri("http://Microsoft.com");
        }

        public override IEnumerable<Tuple<string, Uri>> GetSupportedTechnologyLinks()
        {
            // A list of supported technolgoies, such as which services it supports
            // If a Provider configured Dynamics CRM with Azure Redis Cache and Azure Auth, 
            // it would include the following
            yield return Tuple.Create("Dynamics CRM", new Uri("http://www.microsoft.com/en-us/dynamics/crm.aspx"));
            yield return Tuple.Create("Azure Redis Cache", new Uri("http://azure.microsoft.com/en-us/services/cache/"));
            yield return Tuple.Create("Azure Active Directory", new Uri("http://azure.microsoft.com/en-us/services/active-directory/"));
        }

        public override Task<ConnectedServiceConfigurator> CreateConfiguratorAsync(ConnectedServiceProviderContext context)
        {
            return Task.FromResult<ConnectedServiceConfigurator>(new ViewModels.SinglePageViewModel());
        }
    }
}
