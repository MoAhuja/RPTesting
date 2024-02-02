// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated />

using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.TypeSpec.ProviderHub;
using Microsoft.TypeSpec.ProviderHub.Controller;
using Microsoft.TypeSpec.ProviderHub.Controller.SubscriptionLifeCycle;
using Microsoft.MyResourceProvider.Service.Models;

namespace Microsoft.MyResourceProvider.Service.Controllers
{
    /// <summary>
    /// Controller for user RP operations on the MoTestRPModel resource.
    /// </summary>
    [ApiController]
    public abstract partial class MoTestRPModelControllerBase : ResourceControllerBase
    {
        protected readonly ILogger<MoTestRPModelControllerBase> _logger;

        static MoTestRPModelControllerBase()
        {
            InitializeLogger();
        }

        protected MoTestRPModelControllerBase(ILogger<MoTestRPModelControllerBase> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Validate the request to Read the MoTestRPModel resource.
        /// </summary>
        /// <param name="subscriptionId">
        /// The ID of the target subscription.
        /// </param>
        /// <param name="resourceGroupName">
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name="MetadataName">
        /// The name of the employee
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns> A ValidationResponse indicating the validity of the Read request.</returns>
        [HttpPost]
        [Route(MyResourceProviderServiceRoutes.MoTestRPModelValidateRead)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ValidationResponse))]
        public async Task<IActionResult> ValidateReadAsync(string subscriptionId, string resourceGroupName, string MetadataName, CancellationToken cancellationToken)
        {
            _logValidateRead(_logger, null);

            var modelValidation = await OnValidateRead(subscriptionId, resourceGroupName, MetadataName, cancellationToken);
            return Ok(modelValidation);
        }

        protected virtual Task<ValidationResponse> OnValidateRead(string subscriptionId, string resourceGroupName, string MetadataName, CancellationToken cancellationToken)
        {
            return Task.FromResult(ValidationResponse.Valid);
        }

        /// <summary>
        /// Read the MoTestRPModel resource.
        /// </summary>
        /// <param name="subscriptionId">
        /// The ID of the target subscription.
        /// </param>
        /// <param name="resourceGroupName">
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name="MetadataName">
        /// The name of the employee
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns> The MoTestRPModel resource.</returns>
        [HttpPost]
        [Route(MyResourceProviderServiceRoutes.MoTestRPModelBeginRead)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MoTestRPModel))]
        public async Task<IActionResult> BeginReadAsync(string subscriptionId, string resourceGroupName, string MetadataName, CancellationToken cancellationToken)
        {
            _logBeginRead(_logger, null);

            if (Request is null)
            {
                _logRequestNull(_logger, null);
                return BadRequest("Request is null");
            }

            var result = await OnReadAsync(subscriptionId, resourceGroupName, MetadataName, cancellationToken);
            return result;
        }

        protected virtual Task<IActionResult> OnReadAsync(string subscriptionId, string resourceGroupName, string MetadataName, CancellationToken cancellationToken)
        {
            return Task.FromResult<IActionResult>(Ok());
        }

        /// <summary>
        /// Validate the request to Create the MoTestRPModel resource.
        /// </summary>
        /// <param name="subscriptionId">
        /// The ID of the target subscription.
        /// </param>
        /// <param name="resourceGroupName">
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name="MetadataName">
        /// The name of the employee
        /// </param>
        /// <param name="body">
        /// The resource data.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns> A ValidationResponse indicating the validity of the Create request.</returns>
        [HttpPost]
        [Route(MyResourceProviderServiceRoutes.MoTestRPModelValidateCreate)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ValidationResponse))]
        public async Task<IActionResult> ValidateCreateAsync(string subscriptionId, string resourceGroupName, string MetadataName, MoTestRPModel body, CancellationToken cancellationToken)
        {
            _logValidateCreate(_logger, null);

            var modelValidation = ValidationHelpers.ValidateModel(body);
            if (modelValidation.IsValid)
            {
                modelValidation = await OnValidateCreate(subscriptionId, resourceGroupName, MetadataName, body, cancellationToken);
            }
            return Ok(modelValidation);
        }

        protected virtual Task<ValidationResponse> OnValidateCreate(string subscriptionId, string resourceGroupName, string MetadataName, MoTestRPModel body, CancellationToken cancellationToken)
        {
            return Task.FromResult(ValidationResponse.Valid);
        }

        /// <summary>
        /// Called after the end of the request to Create the MoTestRPModel resource.
        /// </summary>
        /// <param name="subscriptionId">
        /// The ID of the target subscription.
        /// </param>
        /// <param name="resourceGroupName">
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name="MetadataName">
        /// The name of the employee
        /// </param>
        /// <param name="body">
        /// The resource data.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        [HttpPost]
        [Route(MyResourceProviderServiceRoutes.MoTestRPModelEndCreate)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(void))]
        public async Task<IActionResult> EndCreateAsync(string subscriptionId, string resourceGroupName, string MetadataName, MoTestRPModel body, CancellationToken cancellationToken)
        {
            _logEndCreate(_logger, null);

            await OnEndCreate(subscriptionId, resourceGroupName, MetadataName, body, cancellationToken);
            return Ok();
        }

        protected virtual Task OnEndCreate(string subscriptionId, string resourceGroupName, string MetadataName, MoTestRPModel body, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Create the MoTestRPModel resource.
        /// </summary>
        /// <param name="subscriptionId">
        /// The ID of the target subscription.
        /// </param>
        /// <param name="resourceGroupName">
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name="MetadataName">
        /// The name of the employee
        /// </param>
        /// <param name="body">
        /// The resource data.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns> The MoTestRPModel resource.</returns>
        [HttpPut]
        [Route(MyResourceProviderServiceRoutes.MoTestRPModelItem)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MoTestRPModel))]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(MoTestRPModel))]
        public async Task<IActionResult> BeginCreateAsync(string subscriptionId, string resourceGroupName, string MetadataName, MoTestRPModel body, CancellationToken cancellationToken)
        {
            _logBeginCreate(_logger, null);

            body = body ?? throw new ArgumentNullException(nameof(body));
            if (Request is null)
            {
                _logRequestNull(_logger, null);
                return BadRequest("Request is null");
            }

            var result = await OnCreateAsync(subscriptionId, resourceGroupName, MetadataName, body, cancellationToken);
            return result;
        }

        protected virtual Task<IActionResult> OnCreateAsync(string subscriptionId, string resourceGroupName, string MetadataName, MoTestRPModel body, CancellationToken cancellationToken)
        {
            return Task.FromResult<IActionResult>(Ok());
        }

        /// <summary>
        /// Validate the request to Patch the MoTestRPModel resource.
        /// </summary>
        /// <param name="subscriptionId">
        /// The ID of the target subscription.
        /// </param>
        /// <param name="resourceGroupName">
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name="MetadataName">
        /// The name of the employee
        /// </param>
        /// <param name="body">
        /// The type used for update operations of the MoTestRPModel.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns> A ValidationResponse indicating the validity of the Patch request.</returns>
        [HttpPost]
        [Route(MyResourceProviderServiceRoutes.MoTestRPModelValidatePatch)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ValidationResponse))]
        public async Task<IActionResult> ValidatePatchAsync(string subscriptionId, string resourceGroupName, string MetadataName, MoTestRPModelUpdate body, CancellationToken cancellationToken)
        {
            _logValidatePatch(_logger, null);

            var modelValidation = ValidationHelpers.ValidateModel(body);
            if (modelValidation.IsValid)
            {
                modelValidation = await OnValidatePatch(subscriptionId, resourceGroupName, MetadataName, body, cancellationToken);
            }
            return Ok(modelValidation);
        }

        protected virtual Task<ValidationResponse> OnValidatePatch(string subscriptionId, string resourceGroupName, string MetadataName, MoTestRPModelUpdate body, CancellationToken cancellationToken)
        {
            return Task.FromResult(ValidationResponse.Valid);
        }

        /// <summary>
        /// Called after the end of the request to Patch the MoTestRPModel resource.
        /// </summary>
        /// <param name="subscriptionId">
        /// The ID of the target subscription.
        /// </param>
        /// <param name="resourceGroupName">
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name="MetadataName">
        /// The name of the employee
        /// </param>
        /// <param name="body">
        /// The type used for update operations of the MoTestRPModel.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        [HttpPost]
        [Route(MyResourceProviderServiceRoutes.MoTestRPModelEndPatch)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(void))]
        public async Task<IActionResult> EndPatchAsync(string subscriptionId, string resourceGroupName, string MetadataName, MoTestRPModelUpdate body, CancellationToken cancellationToken)
        {
            _logEndPatch(_logger, null);

            await OnEndPatch(subscriptionId, resourceGroupName, MetadataName, body, cancellationToken);
            return Ok();
        }

        protected virtual Task OnEndPatch(string subscriptionId, string resourceGroupName, string MetadataName, MoTestRPModelUpdate body, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Patch the MoTestRPModel resource.
        /// </summary>
        /// <param name="subscriptionId">
        /// The ID of the target subscription.
        /// </param>
        /// <param name="resourceGroupName">
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name="MetadataName">
        /// The name of the employee
        /// </param>
        /// <param name="body">
        /// The type used for update operations of the MoTestRPModel.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns> The MoTestRPModel resource.</returns>
        [HttpPatch]
        [Route(MyResourceProviderServiceRoutes.MoTestRPModelItem)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(MoTestRPModel))]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(MoTestRPModel))]
        public async Task<IActionResult> BeginPatchAsync(string subscriptionId, string resourceGroupName, string MetadataName, MoTestRPModelUpdate body, CancellationToken cancellationToken)
        {
            _logBeginPatch(_logger, null);

            body = body ?? throw new ArgumentNullException(nameof(body));
            if (Request is null)
            {
                _logRequestNull(_logger, null);
                return BadRequest("Request is null");
            }

            var result = await OnPatchAsync(subscriptionId, resourceGroupName, MetadataName, body, cancellationToken);
            return result;
        }

        protected virtual Task<IActionResult> OnPatchAsync(string subscriptionId, string resourceGroupName, string MetadataName, MoTestRPModelUpdate body, CancellationToken cancellationToken)
        {
            return Task.FromResult<IActionResult>(Ok(cancellationToken));
        }

        /// <summary>
        /// Validate the request to Delete the MoTestRPModel resource.
        /// </summary>
        /// <param name="subscriptionId">
        /// The ID of the target subscription.
        /// </param>
        /// <param name="resourceGroupName">
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name="MetadataName">
        /// The name of the employee
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns> A ValidationResponse indicating the validity of the Delete request.</returns>
        [HttpPost]
        [Route(MyResourceProviderServiceRoutes.MoTestRPModelValidateDelete)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ValidationResponse))]
        public async Task<IActionResult> ValidateDeleteAsync(string subscriptionId, string resourceGroupName, string MetadataName, CancellationToken cancellationToken)
        {
            _logValidateDelete(_logger, null);

            var modelValidation = await OnValidateDelete(subscriptionId, resourceGroupName, MetadataName, cancellationToken);
            return Ok(modelValidation);
        }

        protected virtual Task<ValidationResponse> OnValidateDelete(string subscriptionId, string resourceGroupName, string MetadataName, CancellationToken cancellationToken)
        {
            return Task.FromResult(ValidationResponse.Valid);
        }

        /// <summary>
        /// Called after the end of the request to Delete the MoTestRPModel resource.
        /// </summary>
        /// <param name="subscriptionId">
        /// The ID of the target subscription.
        /// </param>
        /// <param name="resourceGroupName">
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name="MetadataName">
        /// The name of the employee
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        [HttpPost]
        [Route(MyResourceProviderServiceRoutes.MoTestRPModelEndDelete)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(void))]
        public async Task<IActionResult> EndDeleteAsync(string subscriptionId, string resourceGroupName, string MetadataName, CancellationToken cancellationToken)
        {
            _logEndDelete(_logger, null);

            await OnEndDelete(subscriptionId, resourceGroupName, MetadataName, cancellationToken);
            return Ok();
        }

        protected virtual Task OnEndDelete(string subscriptionId, string resourceGroupName, string MetadataName, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// Delete the MoTestRPModel resource.
        /// </summary>
        /// <param name="subscriptionId">
        /// The ID of the target subscription.
        /// </param>
        /// <param name="resourceGroupName">
        /// The name of the resource group. The name is case insensitive.
        /// </param>
        /// <param name="MetadataName">
        /// The name of the employee
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns> The MoTestRPModel resource.</returns>
        [HttpDelete]
        [Route(MyResourceProviderServiceRoutes.MoTestRPModelItem)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(void))]
        [ProducesResponseType((int)HttpStatusCode.NoContent, Type = typeof(void))]
        public async Task<IActionResult> BeginDeleteAsync(string subscriptionId, string resourceGroupName, string MetadataName, CancellationToken cancellationToken)
        {
            _logBeginDelete(_logger, null);

            if (Request is null)
            {
                _logRequestNull(_logger, null);
                return BadRequest("Request is null");
            }

            var result = await OnDeleteAsync(subscriptionId, resourceGroupName, MetadataName, cancellationToken);
            return result;
        }

        protected virtual Task<IActionResult> OnDeleteAsync(string subscriptionId, string resourceGroupName, string MetadataName, CancellationToken cancellationToken)
        {
            return Task.FromResult<IActionResult>(Ok());
        }

        /// <summary>
        /// Listens for changes to the customer subscription with respect to the MoTestRPModel resource.
        /// </summary>
        /// <param name="subscriptionId">
        /// The ID of the target subscription.
        /// </param>
        /// <param name="body">
        /// The subscription registration state.
        /// </param>
        [HttpPut]
        [Route(MyResourceProviderServiceRoutes.MoTestRPModelSubscriptionLifeCycleNotification)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> SubscriptionLifeCycleNotification(string subscriptionId, RegistrationStatePayload body)
        {
            _logSubLifeCycleNotification(_logger, null);

            await OnSubLifeCycleNotification(subscriptionId, body);

            return Ok();
        }

        protected virtual Task OnSubLifeCycleNotification(string subscriptionId, RegistrationStatePayload body)
        {
            return Task.CompletedTask;
        }
    }
}