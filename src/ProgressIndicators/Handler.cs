using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Contoso.Samples.ConnectedServices.ProgressIndicators
{
    [ConnectedServiceHandlerExport(
        "Microsoft.Samples.ProgressIndicators",
        AppliesTo = "CSharp")]
    internal class Handler : ConnectedServiceHandler
    {
        private const string GettingStartedUrl = "https://github.com/Microsoft/ConnectedServices-ProviderAuthorSamples";

        /// <summary>
        /// Called to add a new Connected Service to the project.
        /// </summary>
        public override Task<AddServiceInstanceResult> AddServiceInstanceAsync(ConnectedServiceHandlerContext context, CancellationToken ct)
        {
            return Task.FromResult(new AddServiceInstanceResult(context.ServiceInstance.Name, new Uri(Handler.GettingStartedUrl)));
        }
    }
}
