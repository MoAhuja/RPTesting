using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.MyResourceProvider.Service.Controllers;
using Microsoft.MyResourceProvider.Service.Models;
using Microsoft.TypeSpec.ProviderHub.Controller;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.MyResourceProvider.Service.Controllers
{
    public partial class MoTestRPModelController : MoTestRPModelControllerBase
    { 
        protected override Task<ValidationResponse> OnValidateCreate(string subscriptionId, string resourceGroupName, string MetadataName, MoTestRPModel body, CancellationToken cancellationToken)
        {
            //return Task.FromResult(ValidationResponse.Valid);

            Debug.WriteLine($"{subscriptionId}");

            var _logValidateRead = LoggerMessage.Define(
                LogLevel.Information,
                new EventId(13, "ValidateOperation detail"),
                $"OnValidateCreate() body.Id, {body.Id}");

            _logValidateRead(_logger, null);

            return Task.FromResult(ValidationResponse.Valid);

        }

        protected override Task<IActionResult> OnCreateAsync(string subscriptionId, string resourceGroupName, string MetadataName, MoTestRPModel body, CancellationToken cancellationToken)
        {
            MoTestRPProperties properties = new MoTestRPProperties();
            properties.ProvisioningState = ProvisioningState.Succeeded;

            return Task.FromResult<IActionResult>(Ok(properties));
        }
    }
}
