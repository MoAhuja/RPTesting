import "@typespec/http";
import "@typespec/rest";
import "@typespec/versioning";
import "@azure-tools/typespec-providerhub";
import "@azure-tools/typespec-azure-core";
import "@azure-tools/typespec-azure-resource-manager";

using TypeSpec.Http;
using TypeSpec.Rest;
using TypeSpec.Versioning;
using Azure.ResourceManager;

@armProviderNamespace("Private.Porter")
@service({
  title: "Private.Porter",
  version: "2021-08-01-preview",
})
@useDependency(Azure.ResourceManager.Versions.v1_0_Preview_1)
@armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
namespace Private.Porter;

interface Operations extends Azure.ResourceManager.Operations {}

#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-path-segment-invalid-chars" "Existing Template"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-key-invalid-chars" "Existing template"
@doc("A Private.Porter resource")


model SolutionInputsResource is TrackedResource<SolutionInputsResourceProperties> {
  @doc("The name of the moTest resource")
  @pattern("^[a-zA-Z0-9-]{3,24}$")
  @key("name")
  @segment("moTest")
  @path
  name: string;
  
}



@doc("The status of the current operation.")
@Azure.Core.lroStatus
enum ProvisioningState {
  ...ResourceProvisioningState,

  @doc("Initial provisioning in progress")
  Provisioning,

  @doc("Update in progress")
  Updating,

  @doc("Deletion in progress")
  Deleting,

  @doc("Change accepted for processing")
  Accepted,
}

@doc("Details of the Contoso Database.")
model SolutionInputsResourceProperties {
  @visibility("read")
  @doc("The status of the last operation.")
  provisioningState?: ProvisioningState;

  parameters?: Array<Parameter>;
}


model Parameter {
  name: string;
  type?: string;
  //default : Record<unknown>;
  exclusiveMinimum?: integer;
  exclusiveMaximum?: integer;
  isRequired: boolean;
  maximum?: integer;
  minimum?: integer;
  description?: string;
  maxLength?: integer;
  minLength?: integer;

  ApplicableOperations: Array<string>;



}


@armResourceOperations(SolutionInputsResource)
//interface SolutionInputsResources extends TrackedResourceOperations<SolutionInputsResource, SolutionInputsResourceProperties> {}@armResourceOperations(Metadata)
interface SolutionInputsResources {
  get is ArmResourceRead<SolutionInputsResource>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<SolutionInputsResource>;
}
