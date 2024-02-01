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
    /// Extensions for easy PUT and PATCH copying of a resource
    /// </summary>
    public static class ArmResourceBaseExtensions
    {
        /// <summary>
        /// Copy the properties of this ArmResourceBase to another ArmResourceBase
        /// </summary>
        /// <param name="source">The source ArmResourceBase</param>
        /// <param name="target">The target ArmResourceBase</param>
        /// <param name="copySettings">The kind of copy you would like to perform (using PUT or PATCH semantics)</param>
        public static void CopyTo(this ArmResourceBase source, ArmResourceBase target, CopySettings copySettings = CopySettings.UsePutSemantics)
        {
            var helper = new ArmResourceBaseCopyHelper();
            switch (copySettings)
            {
                case CopySettings.UsePatchSemantics:
                    helper.CopyForPatch(source, target);
                    break;
                case CopySettings.UsePutSemantics:
                    helper.CopyForPut(source, target);
                    break;
            }
        }
    }
}
