using Microsoft.VisualStudio.ConnectedServices;
using System.Threading.Tasks;

namespace ConnectedServiceSample.ViewModels
{
    public class SinglePageViewModel : ConnectedServiceSinglePage
    {
        public SinglePageViewModel()
        {
            this.View = new Views.SinglePageView();
            this.View.DataContext = this;
            this.Title = "Contoso Sample Provider";
            this.Description = "Configure the Contoso Service";
            this.PropertyChanged += SinglePageViewModel_PropertyChanged;
        }
        private string _serviceName;
        public string ServiceName
        {
            get { return _serviceName; }
            set
            {
                if (value != _serviceName)
                {
                    _serviceName = value;
                    OnPropertyChanged();
                }
            }
        }
        private void SinglePageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.IsFinishEnabled = !string.IsNullOrWhiteSpace(ServiceName);
        }

        public override Task<ConnectedServiceInstance> GetFinishedServiceInstanceAsync()
        {
            ConnectedServiceInstance instance = new ConnectedServiceInstance();
            instance.Name = this.ServiceName;
            return Task.FromResult(instance);
        }

    }
}
