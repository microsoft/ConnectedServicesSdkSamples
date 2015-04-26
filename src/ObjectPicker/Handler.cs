using Contoso.Samples.ConnectedServices.ViewModels;
using Microsoft.VisualStudio.ConnectedServices;
using System.Threading;
using System.Threading.Tasks;

namespace Contoso.Samples.ConnectedServices
{
    /// <summary>
    /// A connected service provider that shows how the objects that the user selected within the object picker control can be accessed.
    /// </summary>
    [ConnectedServiceHandlerExport(
        "Microsoft.Samples.ObjectPicker",
        AppliesTo = "CSharp")]
    internal class Hander : ConnectedServiceHandler
    {
        public override async Task<AddServiceInstanceResult> AddServiceInstanceAsync(ConnectedServiceHandlerContext context, CancellationToken ct)
        {
            // See Handler samples for examples of how to work with the project system 
            await context.Logger.WriteMessageAsync(LoggerMessageCategory.Information, "Handler Invoked");

            Instance instance = (Instance)context.ServiceInstance;
            foreach (ObjectPickerObject obj in instance.SelectedObjects)
            {
                await context.Logger.WriteMessageAsync(LoggerMessageCategory.Information, "Handler doing something with the selected '{0}' object.", obj.Name);
            }

            return new AddServiceInstanceResult("SampleServiceObjectPicker", null);
        }
    }
}
