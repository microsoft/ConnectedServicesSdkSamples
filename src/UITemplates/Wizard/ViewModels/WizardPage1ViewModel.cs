using Microsoft.VisualStudio.ConnectedServices;

namespace Contoso.Samples.ConnectedServices.UITemplates.Wizard.ViewModels
{
    internal class WizardPage1ViewModel : ConnectedServiceWizardPage
    {
        public WizardPage1ViewModel(ServiceWizard wizard) : base(wizard)
        {
            this.Title = "Page 1";
            this.Description = "Page 1 Description";
            this.Legend = "Page 1 Legend";
            this.View = new Views.WizardPage1View();
            this.View.DataContext = this;
        }
    }
}