// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using EnsureThat;
using Microsoft.Health.Fhir.Core.Features.Search.SearchValues;
using Microsoft.Health.Fhir.CosmosDb.Features.Search;
using Newtonsoft.Json.Linq;

namespace Microsoft.Health.Fhir.CosmosDb.Features.Storage.Search
{
    public class SortValueJObjectGenerator : ISearchValueVisitor
    {
        private string _prefix;

        private JObject CurrentEntry { get; set; }

        public JObject Generate(SortValue entry)
        {
            EnsureArg.IsNotNull(entry, nameof(entry));

            CreateEntry();

            if (entry.Low != null)
            {
                _prefix = SearchValueConstants.SortLowValueFieldName;
                entry.Low.AcceptVisitor(this);
            }
            else
            {
                AddProperty(SearchValueConstants.SortLowValueFieldName, null);
            }

            if (entry.Hi != null)
            {
                _prefix = SearchValueConstants.SortHighValueFieldName;
                entry.Hi.AcceptVisitor(this);
            }
            else
            {
                AddProperty(SearchValueConstants.SortHighValueFieldName, null);
            }

            return CurrentEntry;
        }

        public void Visit(CompositeSearchValue composite)
        {
        }

        public void Visit(DateTimeSearchValue dateTime)
        {
            AddProperty(_prefix, dateTime.Start.ToString("o", CultureInfo.InvariantCulture));
        }

        public void Visit(NumberSearchValue number)
        {
            AddProperty(_prefix, number.Low ?? number.High);
        }

        public void Visit(QuantitySearchValue quantity)
        {
            AddProperty(_prefix, quantity.Low ?? quantity.High);
        }

        public void Visit(ReferenceSearchValue reference)
        {
            AddProperty(_prefix, reference.ToString().ToUpperInvariant());
        }

        public void Visit(StringSearchValue s)
        {
            AddProperty(_prefix, s.String.NormalizeAndRemoveAccents().ToUpperInvariant());
        }

        public void Visit(TokenSearchValue token)
        {
        }

        public void Visit(UriSearchValue uri)
        {
            AddProperty(_prefix, uri.Uri);
        }

        private void CreateEntry()
        {
            CurrentEntry = new JObject();
        }

        private void AddProperty(string name, object value)
        {
            CurrentEntry.Add(new JProperty(name, value));
        }
    }
}
