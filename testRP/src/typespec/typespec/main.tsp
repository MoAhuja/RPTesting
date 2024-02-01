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

@armProviderNamespace("Microsoft.MyResourceProvider")
@service({
  title: "Microsoft.MyResourceProvider",
  version: "2021-08-01-preview",
})
@useDependency(Azure.ResourceManager.Versions.v1_0_Preview_1)
@armCommonTypesVersion(Azure.ResourceManager.CommonTypes.Versions.v5)
namespace Microsoft.MyResourceProvider;

interface Operations extends Azure.ResourceManager.Operations {}

#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-path-segment-invalid-chars" "Existing Template"
#suppress "@azure-tools/typespec-azure-resource-manager/arm-resource-key-invalid-chars" "Existing template"
@doc("A MyResourceProviderProviderHub resource")
model Metadata is TrackedResource<MetadataProperties> {
  @doc("The name of the employee")
  @pattern("^[a-zA-Z0-9-]{3,24}$")
  @key("MetadataName")
  @segment("Metadatas")
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
model MetadataProperties {
  @visibility("read")
  @doc("The status of the last operation.")
  provisioningState?: ProvisioningState;
}

@armResourceOperations(Metadata)
interface Metadatas {
  get is ArmResourceRead<Metadata>;
  createOrUpdate is ArmResourceCreateOrReplaceAsync<Metadata>;
  update is ArmResourcePatchSync<Metadata, MetadataProperties>;
  delete is ArmResourceDeleteSync<Metadata>;
  listByResourceGroup is ArmResourceListByParent<Metadata>;
  listBySubscription is ArmListBySubscription<Metadata>;
}
