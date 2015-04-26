using Contoso.Samples.ConnectedServices.UITemplates.Wizard.ViewModels;
using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Contoso.Samples.ConnectedServices.UITemplates.Wizard
{
    [ConnectedServiceProviderExport("Microsoft.Samples.Wizard")]
    internal class Provider : ConnectedServiceProvider
    {
        public Provider()
        {
            this.Name = "Sample Configurator: Wizard";
            this.Category = "Contoso";
            this.Description = "A sample Connected Service demonstrating Wizard configuration";
            this.Icon = new BitmapImage(new Uri("pack://application:,,/" + this.GetType().Assembly.ToString() + ";component/Resources/ProviderIcon.png"));
            this.CreatedBy = "Microsoft";
            this.Version = new Version(1, 0, 0);
            this.MoreInfoUri = new Uri("http://aka.ms/ConnectedServicesSDK");
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
            return Task.FromResult<ConnectedServiceConfigurator>(new ServiceWizard());
        }
    }
}