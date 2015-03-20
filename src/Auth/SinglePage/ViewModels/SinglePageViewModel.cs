using Contoso.Samples.ConnectedServices.Authentication.SinglePage.Views;
using Microsoft.VisualStudio.ConnectedServices;
using System.Threading.Tasks;

namespace Contoso.Samples.ConnectedServices.Authentication.SinglePage.ViewModels
{
    internal class SinglePageViewModel : ConnectedServiceSinglePage
    {
        private string serviceName;
        private string authenticateMessage;
        private AuthenticatorViewModel authenticator;

        public SinglePageViewModel()
        {
            this.Title = "Contoso Service";
            this.Description = "Sample SinglePage with Auth";
            this.View = new SinglePageView();
            this.View.DataContext = this;

            this.ServiceName = "SampleService";
        }

        /// <summary>
        /// Gets or sets the first value that the user can enter.
        /// </summary>
        public string ServiceName
        {
            get { return this.serviceName; }
            set
            {
                this.serviceName = value;
                this.OnPropertyChanged();
                this.CalculateIsFinishEnabled();
            }
        }

        /// <summary>
        /// Gets or sets the message shown to the user when he is not signed in.
        /// </summary>
        public string AuthenticateMessage
        {
            get { return this.authenticateMessage; }
            set
            {
                this.authenticateMessage = value;
                this.OnPropertyChanged();
            }
        }

        // Hosts the Authentication ViewModel
        public AuthenticatorViewModel Authenticator
        {
            get
            {
                if (this.authenticator == null)
                {
                    this.authenticator = new AuthenticatorViewModel();
                    this.authenticator.AuthenticationChanged += Authenticator_AuthenticationChanged;
                    this.CalculateAuthentication();
                }
                return this.authenticator;
            }
        }

        /// <summary>
        /// The event handler that is called when the user signs in and out.
        /// </summary>
        private void Authenticator_AuthenticationChanged(object sender, AuthenticationChangedEventArgs e)
        {
            this.CalculateAuthentication();
        }

        private void CalculateAuthentication()
        {
            if (this.Authenticator.IsAuthenticated)
            {
                this.AuthenticateMessage = null;
            }
            else
            {
                this.AuthenticateMessage = "Please click 'Sign In'";
            }

            this.CalculateIsFinishEnabled();
        }

        /// <summary>
        /// Creates the ConnectedServiceAuthenticator object, which controls whether the user is signed in.
        /// </summary>
        public override Task<ConnectedServiceAuthenticator> CreateAuthenticatorAsync()
        {
            return Task.FromResult<ConnectedServiceAuthenticator>(this.Authenticator);
        }

        /// <summary>
        /// The logic that sets whether the user can finish configuring the service.
        /// </summary>
        private void CalculateIsFinishEnabled()
        {
            // basic example for toggling the state of the Add/Update/Finish button
            this.IsFinishEnabled = this.Authenticator.IsAuthenticated &&
                !string.IsNullOrEmpty(this.ServiceName);
        }

        /// <summary>
        /// This method is called when the user finishes configuring the service.
        /// It returns the 'finished' ConnectedServiceInstance that will be passed to the Handler.
        /// </summary>
        public override Task<ConnectedServiceInstance> GetFinishedServiceInstanceAsync()
        {
            return Task.FromResult(new ConnectedServiceInstance());
        }
    }
}
