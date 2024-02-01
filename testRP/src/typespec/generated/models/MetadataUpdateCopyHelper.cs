// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated />

using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Microsoft.TypeSpec.ProviderHub.Controller;

namespace Microsoft.MyResourceProvider.Service.Models
{
    /// <summary>
    /// Helper for merging canonical MetadataUpdate models as part of a PUT or PATCH operation
    /// </summary>
    public partial class MetadataUpdateCopyHelper
    {
        /// <summary>
        /// Extensibility point: perform actions before data is copied
        /// </summary>
        /// <param name="source">The source MetadataUpdate</param>
        /// <param name="target">The target MetadataUpdate</param>
        partial void OnBeginCopyForPatch(MetadataUpdate source, MetadataUpdate target);

        /// <summary>
        /// Extensibility point: perform actions after data is copied
        /// </summary>
        /// <param name="source">The source MetadataUpdate</param>
        /// <param name="target">The target MetadataUpdate</param>
        partial void OnEndCopyForPatch(MetadataUpdate source, MetadataUpdate target);

        /// <summary>
        /// Copy the properties of a source MetadataUpdate to a target MetadataUpdate, using PATCH semantics
        /// </summary>
        /// <param name="source">The source MetadataUpdate</param>
        /// <param name="target">The target MetadataUpdate</param>
        public void CopyForPatch(MetadataUpdate source, MetadataUpdate target)
        {
            var serialization = source.SerializationInfo;
            OnBeginCopyForPatch(source, target);
            if (serialization.IsSerializedProperty(nameof(source.Tags)))
                target.Tags = source.Tags;
            OnEndCopyForPatch(source, target);
        }

        /// <summary>
        /// Extensibility point: perform actions before data is copied
        /// </summary>
        /// <param name="source">The source MetadataUpdate</param>
        /// <param name="target">The target MetadataUpdate</param>
        partial void OnBeginCopyForPut(MetadataUpdate source, MetadataUpdate target);

        /// <summary>
        /// Extensibility point: perform actions after data is copied
        /// </summary>
        /// <param name="source">The source MetadataUpdate</param>
        /// <param name="target">The target MetadataUpdate</param>
        partial void OnEndCopyForPut(MetadataUpdate source, MetadataUpdate target);

        /// <summary>
        /// Copy the properties of a source MetadataUpdate to a target MetadataUpdate, using PUT semantics
        /// </summary>
        /// <param name="source">The source MetadataUpdate</param>
        /// <param name="target">The target MetadataUpdate</param>
        public void CopyForPut(MetadataUpdate source, MetadataUpdate target)
        {
            var serialization = source.SerializationInfo;
            OnBeginCopyForPut(source, target);
            target.Tags = source.Tags;
            OnEndCopyForPut(source, target);
        }
    }
}