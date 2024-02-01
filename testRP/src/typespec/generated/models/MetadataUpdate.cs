// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated />

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.TypeSpec.ProviderHub.Controller;

namespace Microsoft.MyResourceProvider.Service.Models
{
    /// <summary>
    /// The type used for update operations of the Metadata.
    /// </summary>
    public partial class MetadataUpdate : ISerializationTracker
    {

        /// <summary>
        /// Extensibility point - allows changing class properties during construction.
        /// </summary>
        partial void OnBeforeInitialize();

        /// <summary>
        /// Extensibility point - allows changing class properties during construction.
        /// </summary>
        partial void OnAfterInitialize();

        /// <summary>
        /// Initializes a new instance of the MetadataUpdate class.
        /// </summary>
        public MetadataUpdate()
        {
            OnBeforeInitialize();
            OnAfterInitialize();
        }

        /// <summary>
        /// Resource tags.
        /// </summary>
        [JsonProperty("tags")]
        public IDictionary<string, string> Tags { get; set; }


        /// <summary>
        /// Tracks deserialization of the resource.
        /// </summary>
        [JsonIgnore]
        public ResourceSerializationInfo SerializationInfo { get; set; } = new DefaultSerializationInfo();
    }
}
