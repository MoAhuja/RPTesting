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
namespace Microsoft.MyResourceProvider;

interface Operations extends Azure.ResourceManager.Operations {}

#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-path-segment-invalid-chars" "Existing Template"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-key-invalid-chars" "Existing template"
@doc("A MyResourceProviderProviderHub resource")
model MoTestRPModel is TrackedResource<MoTestRPProperties> {
  @doc("The name of the employee")
  @pattern("^[a-zA-Z0-9-]{3,24}$")
  @key("MetadataName")
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

@doc("Details of the MyResourceProvider Metadata.")
model MoTestRPProperties {
  @visibility("read")
  @doc("The status of the last operation.")
  provisioningState?: ProvisioningState;
}

@armResourceOperations(MoTestRPModel)
interface Metadatas {
  get is ArmResourceRead<MoTestRPModel>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<MoTestRPModel>;
  update is ArmResourcePatchSync<MoTestRPModel, MoTestRPProperties>;
  delete is ArmResourceDeleteSync<MoTestRPModel>;
  listByResourceGroup is ArmResourceListByParent<MoTestRPModel>;
  listBySubscription is ArmListBySubscription<MoTestRPModel>;
}
