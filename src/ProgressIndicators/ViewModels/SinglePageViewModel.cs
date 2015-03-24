using Contoso.Samples.ConnectedServices.ProgressIndicators.Views;
using Microsoft.VisualStudio.ConnectedServices;
using System.Threading.Tasks;

namespace Contoso.Samples.ConnectedServices.ProgressIndicators.ViewModels
{
    public class SinglePageViewModel : ConnectedServiceSinglePage
    {
        private bool isValidatingAuth = false;
        private bool isPerformingLongTask = false;
        //TODO: Move Context to ConnectedServiceConfigurator
        public ConnectedServiceProviderContext Context { get; set; }
        public SinglePageViewModel()
        {
            this.Title = "Samples";
            this.Description = "Demo of the Connected Service busy indicator, and a contextual busy indicator";
            this.View = new SinglePageView(this);
        }
        /// <summary>
        /// Auth might be a place where you want to show general progress. 
        /// </summary>
        public bool IsValidatingAuth
        {
            get { return isValidatingAuth; }
            set
            {
                if (isValidatingAuth != value)
                {
                    isValidatingAuth = value;
                    this.OnPropertyChanged("IsValidatingAuth");
                }
            }
        }

        /// <summary>
        /// Not meant to be a specific property, but a generalized sample of how to disable controls through databinding while performing some long task. 
        /// The task may be discovering some metadata from your management services to help the developer choose from several options
        /// </summary>
        public bool IsPerformingLongTask
        {
            get { return isPerformingLongTask; }
            set
            {
                if (isPerformingLongTask != value)
                {
                    isPerformingLongTask = value;
                    this.OnPropertyChanged("IsPerformingLongTask");
                }
            }
        }
        public async Task PerformLongTask()
        {
            // To get access to the BusyIndicator in the base ConnectedServices UI, call the StartBusyIndicator() method, passing in the text to display
            // When the object is disposed, the BusyIndicator will be disabled. You could also call StartBusyIndicator and hold a reference to the object 
            // and dispose when needed
            using (this.Context.StartBusyIndicator("Performing a longer task"))
            {
                // We want to disable certain controls when we're doing a given task 
                // The IsPerformingLongTask is used to bind the Button.Enabled
                this.IsPerformingLongTask = true;
                // do something that takes a while
                await Task.Delay(10000);
                this.IsPerformingLongTask = false;
            }

        }

        /// <summary>
        /// This method is called when the user finishes configuring the service.
        /// It returns the 'finished' ConnectedServiceInstance that will be passed to the Handler.
        /// </summary>
        public override Task<ConnectedServiceInstance> GetFinishedServiceInstanceAsync()
        {
            ConnectedServiceInstance instance = new ConnectedServiceInstance();

            return Task.FromResult(instance);
        }
    }
}