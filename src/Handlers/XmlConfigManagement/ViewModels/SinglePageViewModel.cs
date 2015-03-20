using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Threading.Tasks;

namespace Contoso.Samples.ConnectedServices.Handlers.XmlConfigManagement.ViewModels
{
    internal class SinglePageViewModel : ConnectedServiceSinglePage
    {
        private string redirectUrl;

        public SinglePageViewModel()
        {
            this.View = new Views.SinglePageView();
            this.View.DataContext = this;
            this.Title = "Title: Single Page Config";
            this.Description = "Description: Configure the Contoso Service";
            this.IsFinishEnabled = true;
            this.RedirectUrl = "http://MyCompanyLoginUrl.dot";
        }

        public string RedirectUrl
        {
            get { return redirectUrl; }
            set
            {
                if (value != redirectUrl)
                {
                    redirectUrl = value;
                    this.OnPropertyChanged("RedirectUrl");
                }
            }
        }

        public override Task<ConnectedServiceInstance> GetFinishedServiceInstanceAsync()
        {
            // Construct an instance, specific to this service
            // Used to more easily pass information to the various handlers, 
            // without having to use the instance.Metadata property bag
            Instance instance = new Instance();

            // Pass some specific values over, which may be generated as a result
            // of creating an OAuth endopint on the service
            instance.ConfigOptions.ConsumerKey = Guid.NewGuid().ToString();
            instance.ConfigOptions.ConsumerSecret = Guid.NewGuid().ToString();

            // Pass a value the user entered directly
            instance.ConfigOptions.RedirectUrl = this.RedirectUrl;

            return Task.FromResult<ConnectedServiceInstance>(instance);
        }
    }
}