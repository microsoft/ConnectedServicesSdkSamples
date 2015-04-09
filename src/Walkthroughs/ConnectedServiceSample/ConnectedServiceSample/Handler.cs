using Microsoft.VisualStudio.ConnectedServices;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConnectedServiceSample
{
    [ConnectedServiceHandlerExport("Contoso.SampleService",
        AppliesTo = "CSharp+Web")]
    internal class Handler : ConnectedServiceHandler
    {
        public async override Task<AddServiceInstanceResult> AddServiceInstanceAsync(ConnectedServiceHandlerContext context, CancellationToken ct)
        {
            await context.Logger.WriteMessageAsync(LoggerMessageCategory.Information, "Updating Config");
            using (EditableXmlConfigHelper configHelper = context.CreateEditableXmlConfigHelper())
            {
                configHelper.SetAppSetting(
                    string.Format("{0}:ConnectionString", context.ServiceInstance.Name),
                    "SomeServiceConnectionString",
                    context.ServiceInstance.Name
                    );
                configHelper.Save();
            }
            Thread.Sleep(1000);
            await context.Logger.WriteMessageAsync(LoggerMessageCategory.Information, "Adding NuGets");
            Thread.Sleep(1000);
            await context.Logger.WriteMessageAsync(LoggerMessageCategory.Information, "Adding References");
            Thread.Sleep(1000);

            AddServiceInstanceResult result = new AddServiceInstanceResult(
                    context.ServiceInstance.Name,
                    new Uri("https://github.com/Microsoft/ConnectedServices-ProviderAuthorSamples"));

            return result;
        }

    }
}
