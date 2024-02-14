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
  @key("solutionName")
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

  imageName: string;
  imageTag: string;

  @visibility("read")
  parameters?: Array<Parameter>;
  @visibility("read")
  credentials?: Array<Credential>;
}




model Parameter {
 
  @doc("Parameter name")
  name: string;

  @doc("Data type of the parameter (string, int, etc)")
  type?: string;
  //default: unknown;

  @doc("Minimum value allowed (> than value specified).  Only applies to numerics.")
  exclusiveMinimum?: integer;

  @doc("Maximum value allowed (< than value specified). Only applies to numerics.")
  exclusiveMaximum?: integer;

  @doc("Whether the parameter is required or not")
  isRequired: boolean;

  @doc("Maximum value allowed (>= value specified). Only applies to numerics.")
  maximum?: integer;

  @doc("Minimum value allowed (<= value specified). Only applies to numerics.")
  minimum?: integer;

  @doc("Description of the parameter")
  description?: string;

  @doc("The maximum length of the parameter. Only applies to strings.")
  maxLength?: integer;

  @doc("The minimum length of the parameter. Only applies to strings.")
  minLength?: integer;

  @doc("Which operations this parameter applies to. If not specified, this parameter applies to all operations.")
  applicableOperations: Array<string>;

  @doc("Which Microsoft cloud(s) the parameter applies to")
  microsoftTargets: Array<string>;



}

model Credential {
  name: string;
  isRequired: boolean;
  applicableOperations: Array<string>;
}


@armResourceOperations
interface ImageTagResources {
  get is ArmResourceRead<SolutionInputsResource>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<SolutionInputsResource>;
}


