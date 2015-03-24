using System.Windows.Controls;
using System.Threading.Tasks;
namespace Contoso.Samples.ConnectedServices.ProgressIndicators.Views
{
    /// <summary>
    /// Interaction logic for SingPageView.xaml
    /// </summary>
    public partial class SinglePageView : UserControl
    {
        public SinglePageView()
        {
            InitializeComponent();
        }
        public SinglePageView(ViewModels.SinglePageViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        private async void PerformLongTask_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            await ((ViewModels.SinglePageViewModel)(this.DataContext)).PerformLongTask();
        }
    }
}
