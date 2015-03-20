using Microsoft.VisualStudio.ConnectedServices;
using System.Threading;
using System.Threading.Tasks;

namespace Contoso.Samples.ConnectedServices.Authentication.SinglePage
{
    [ConnectedServiceHandlerExport(
        "Contoso.Samples.SinglePageAuth",
        AppliesTo = "CSharp")]
    internal class Handler : ConnectedServiceHandler
    {
        /// <summary>
        /// AddServiceInstanceAsync is responsible for adding any artifacts to the project that will be used
        /// to connect to the service.
        /// </summary>
        public override async Task<AddServiceInstanceResult> AddServiceInstanceAsync(ConnectedServiceHandlerContext context, CancellationToken ct)
        {
            // See Handler Samples for how to work with the project system 
            await context.Logger.WriteMessageAsync(LoggerMessageCategory.Information, "Handler Invoked");

            return new AddServiceInstanceResult("SampleServiceSinglePageAuth", null);
        }
    }
}
