using Microsoft.VisualStudio.ConnectedServices;
using System.Threading;
using System.Threading.Tasks;

namespace Contoso.Samples.ConnectedServices.Handlers.XmlConfigManagement
{
    [ConnectedServiceHandlerExport(
        "Contoso.Samples.XmlConfigManagement",
        AppliesTo = "CSharp")]
    internal class Handler : ConnectedServiceHandler
    {
        public override async Task<AddServiceInstanceResult> AddServiceInstanceAsync(ConnectedServiceHandlerContext context, CancellationToken ct)
        {
            // See Handler Samples for how to work with the project system 
            await context.Logger.WriteMessageAsync(LoggerMessageCategory.Information, "Handler Invoked");
            await UpdateConfigFileAsync(context);

            return new AddServiceInstanceResult("SampleServiceXmlConfigManagement", null);
        }

        private static async Task UpdateConfigFileAsync(ConnectedServiceHandlerContext context)
        {
            // Push an update to the progress notifications
            // Introduce Resources as the means to manage strings shown to users, which may get localized
            // Or, at least verified by someone that should be viewing strings, not buried in the code
            await context.Logger.WriteMessageAsync(LoggerMessageCategory.Information, "Adding settings to the project's config file.");
            // Now that we're passing more elaborate values between the provider and the handler
            // We'll start using a specific Instance so we can get stronger type verification
            Instance instance = (Instance)context.ServiceInstance;

            // Launch the EditableConfigHelper to write several entries to the Config file
            using (EditableXmlConfigHelper configHelper = context.CreateEditableXmlConfigHelper())
            {
                // We ahve the option to write name/value pairs
                configHelper.SetAppSetting("ConsumerKey",
                    instance.ConfigOptions.ConsumerKey,
                    "Heading on the first entry to identify the block of settings");
                configHelper.SetAppSetting("ConsumerSecret",
                    instance.ConfigOptions.ConsumerSecret,
                    "Second Comment");
                configHelper.SetAppSetting("RedirectUrl",
                    instance.ConfigOptions.RedirectUrl);
                // no comment on the third

                // Write the values to disk
                configHelper.Save();
            }

            // Some updates to the progress dialog
            Thread.Sleep(1000);
            await context.Logger.WriteMessageAsync(LoggerMessageCategory.Information, "Doing Something Else");
            Thread.Sleep(1000);
            await context.Logger.WriteMessageAsync(LoggerMessageCategory.Information, "Another Entry to show progress");
            Thread.Sleep(1000);
        }
    }
}