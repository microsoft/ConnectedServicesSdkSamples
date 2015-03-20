using Microsoft.VisualStudio.ConnectedServices;

namespace Contoso.Samples.ConnectedServices.UITemplates.Grid.ViewModels
{
    internal class AuthenticatorViewModel : ConnectedServiceAuthenticator
    {
        public AuthenticatorViewModel()
        {
            this.View = new Views.AuthenticatorView();
            this.View.DataContext = this;
            this.IsAuthenticated = true;
        }
    }
}