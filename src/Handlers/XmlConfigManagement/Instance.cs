using Microsoft.VisualStudio.ConnectedServices;

namespace Contoso.Samples.ConnectedServices.Handlers.XmlConfigManagement
{
    internal class Instance : ConnectedServiceInstance
    {

        public Instance()
        {
            this.InstanceId = "Contoso Service";
            this.Name = "Contoso Service";
            this.ConfigOptions = new Models.ConfigOptions();
        }

        public Models.ConfigOptions ConfigOptions { get; set; }
    }
}
