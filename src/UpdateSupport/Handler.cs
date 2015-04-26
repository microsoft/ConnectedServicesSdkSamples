using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Contoso.Samples.ConnectedServices.UpdateSupport
{
    [ConnectedServiceHandlerExport(
        "Microsoft.Samples.UpdateSupport",
        AppliesTo = "CSharp")]
    internal class Handler : ConnectedServiceHandler
    {
        private const string GettingStartedUrl = "https://github.com/Microsoft/ConnectedServices-ProviderAuthorSamples";

        /// <summary>
        /// Called to add a new Connected Service to the project.
        /// </summary>
        public override async Task<AddServiceInstanceResult> AddServiceInstanceAsync(ConnectedServiceHandlerContext context, CancellationToken ct)
        {
            // See Handler samples for examples of how to work with the project system 
            await context.Logger.WriteMessageAsync(LoggerMessageCategory.Information, "Handler Invoked to Add Project Artifacts");

            // Adds the 'ConnectedService.json' and 'Getting Started' artifacts to the project in the "SampleSinglePage" directory and opens the page
            // This would be your guidance on how a developer would complete development for the service
            // What Happened, and required Next Steps, and Sample code
            return new AddServiceInstanceResult(context.ServiceInstance.Name + " UpdateSupport", new Uri(Handler.GettingStartedUrl));
        }

        /// <summary>
        /// Called to update an existing Connected Service to the project.
        /// </summary>
        public override async Task<UpdateServiceInstanceResult> UpdateServiceInstanceAsync(ConnectedServiceHandlerContext context, CancellationToken ct)
        {
            // See Handler samples for examples of how to work with the project system 
            await context.Logger.WriteMessageAsync(LoggerMessageCategory.Information, "Handler Invoked to Update Project Artifacts");
            UpdateServiceInstanceResult updateResult = new UpdateServiceInstanceResult();
            updateResult.GettingStartedDocument = new GettingStartedDocument(new Uri(Handler.GettingStartedUrl));
            return updateResult;
        }
    }
}
