using Microsoft.AspNetCore.Mvc;
using Microsoft.Porter.Service.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.TypeSpec.ProviderHub.Controller;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using ReadBundleLibrary;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System;


namespace Microsoft.Porter.Service.Controllers
{
    /// <summary>
    /// Controller for user RP operations on the MoTest resource.
    /// </summary>
    public partial class SolutionInputsResourceController : SolutionInputsResourceControllerBase
    {
        private BundleLibrary _bundleLibrary;

        //This is needed because we are defining a constructor here (becuase we want to use dependency injection to get the BundleLibrary instance) and there is already
        // a constructor defined in the partial class. This decorator tells the compiler to use this constructor instead of the one in the partial class.
        [ActivatorUtilitiesConstructor]
        public SolutionInputsResourceController(BundleLibrary library, ILogger<SolutionInputsResourceController> logger)
            : base(logger)
        {
            _bundleLibrary = library;
        }

        protected override Task<IActionResult> OnReadAsync(string subscriptionId, string resourceGroupName, string repo, CancellationToken cancellationToken)
        {
            const string endpoint = "https://moporterregistry.azurecr.io";
            const string repository = "porter-hello";
            const string tag = "v0.4.0";

            var paramMapperConfig = new MapperConfiguration(cfg =>
            {
                //Required so that the enum list from the CNAB Parameters definition is mapped as null instead of a list with 0 entries.
                cfg.AllowNullCollections = true;

                //Maps the applicableClouds property from the CNAB Parameters definition to the MicrosoftTargets property in the Porter Parameters definition
                cfg.CreateMap<ReadBundleLibrary.Models.UnifiedDeployment.Parameter, Parameter>().ForMember(dest => dest.MicrosoftTargets, opt => opt.MapFrom(src => src.applicableClouds));

            });

            var credentialMapperConfig = new MapperConfiguration(cfg =>
            {
                //Required so that the enum list from the CNAB Parameters definition is mapped as null instead of a list with 0 entries.
                cfg.AllowNullCollections = true;
                cfg.CreateMap<ReadBundleLibrary.Models.UnifiedDeployment.Credential, Credential>();
      
            });

            var parameterAutomapper = new Mapper(paramMapperConfig);
            var credentialAutomapper = new Mapper(credentialMapperConfig);

            var inputs = _bundleLibrary.RetrieveBundleRequiredInputs(endpoint, repository, tag);

            //Create a new solution resource response object
            SolutionInputsResource resource = new SolutionInputsResource();
            resource.Properties = new SolutionInputsResourceProperties();    
            resource.Properties.ImageName = "porter-hello";
            resource.Properties.ImageTag = "v0.4.0";


            List<Parameter> udParameters = parameterAutomapper.Map<List<Parameter>>(inputs.Parameters);
            List<Credential> credentials = credentialAutomapper.Map<List<Credential>>(inputs.Credentials);
            resource.Properties.Parameters = udParameters.ToArray();
            resource.Properties.Credentials = credentials.ToArray();

            //var parameter = _parameterAutomapper.Map<Parameter>(definitionModel);
            return Task.FromResult<IActionResult>(Ok(resource));
        }
    }
}
