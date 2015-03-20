using Microsoft.VisualStudio.ConnectedServices;
using System.Threading.Tasks;

namespace Contoso.Samples.ConnectedServices.UITemplates.SinglePage.ViewModels
{
    internal class SinglePageViewModel : ConnectedServiceSinglePage
    {
        public SinglePageViewModel()
        {

            this.View = new Views.SinglePageView();
            this.Title = "Title: Single Page Config";
            this.Description = "Description: Configure the Contoso Service";
            this.IsFinishEnabled = true;
        }

        public override Task<ConnectedServiceAuthenticator> CreateAuthenticatorAsync()
        {
            // Add Authentication to the Auth UI Block
            // See the Auth Samples for additional info
            return Task.FromResult<ConnectedServiceAuthenticator>(new AuthenticatorViewModel());
        }

        public override Task<ConnectedServiceInstance> GetFinishedServiceInstanceAsync()
        {
            ConnectedServiceInstance instance = new ConnectedServiceInstance();
            instance.Name = "Contoso Service";
            return Task.FromResult(instance);
        }
    }
}