using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Contoso.Samples.ConnectedServices.Handlers.AddingFiles
{
    [ConnectedServiceHandlerExport(
        "Contoso.Samples.AddingFiles",
        AppliesTo = "CSharp")]
    internal class Handler : ConnectedServiceHandler
    {
        public override async Task<AddServiceInstanceResult> AddServiceInstanceAsync(ConnectedServiceHandlerContext context, CancellationToken ct)
        {
            // Generate a code file into the user's project from a template.
            // The tokens in the template will be replaced by the HandlerHelper.
            // Place service specific scaffolded code under the service folder
            string templateResourceUri = "pack://application:,,/" + this.GetType().Assembly.ToString() + ";component/Templates/SampleServiceTemplate.cs";
            string serviceFolderName = context.ServiceInstance.Name + "AddingFiles";
            string SampleSinglePagePath = Path.Combine(
                context.HandlerHelper.GetServiceArtifactsRootFolder(),
                serviceFolderName,
                "SampleSinglePage.cs");
            await context.HandlerHelper.AddFileAsync(templateResourceUri, SampleSinglePagePath);

            // Adds the 'ConnectedService.json' and 'Getting Started' artifacts to the project in the "SampleSinglePage" directory and opens the page
            // This would be your guidance on how a developer would complete development for the service
            // What Happened, and required Next Steps, and Sample code
            return new AddServiceInstanceResult(serviceFolderName, new Uri("https://github.com/Microsoft/ConnectedServices-ProviderAuthorSamples"));
        }
    }
}
