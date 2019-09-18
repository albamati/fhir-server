﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

namespace Microsoft.Health.Fhir.TableStorage.Features.Storage
{
    public static class SearchValueConstants
    {
        public const string ParamName = "p";

        public const string DateTimeStartName = "st";

        public const string DateTimeEndName = "et";

        public const string NumberName = "n";

        public const string LowNumberName = "ln";

        public const string HighNumberName = "hn";

        public const string NormalizedPrefix = "n_";

        public const string NormalizedStringName = NormalizedPrefix + StringName;

        public const string NormalizedTextName = NormalizedPrefix + TextName;

        public const string QuantityName = "q";

        public const string LowQuantityName = "lq";

        public const string HighQuantityName = "hq";

        public const string SystemName = "s";

        public const string CodeName = "c";

        public const string ReferenceBaseUriName = "rb";

        public const string ReferenceResourceTypeName = "rt";

        public const string ReferenceResourceIdName = "ri";

        public const string StringName = "s";

        public const string TextName = "t";

        public const string UriName = "u";
    }
}