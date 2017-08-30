﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    /// <summary>
    /// Information about a tax authority relevant for an address.
    /// </summary>
    public class TaxAuthorityInfo
    {
        /// <summary>
        /// A unique ID number assigned by Avalara to this tax authority.
        /// </summary>
        public String avalaraId { get; set; }

        /// <summary>
        /// The friendly jurisdiction name for this tax authority.
        /// </summary>
        public String jurisdictionName { get; set; }

        /// <summary>
        /// The type of jurisdiction referenced by this tax authority.
        /// </summary>
        public JurisdictionType? jurisdictionType { get; set; }

        /// <summary>
        /// An Avalara-assigned signature code for this tax authority.
        /// </summary>
        public String signatureCode { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
    /// <summary>
    /// Jurisdiction Type
    /// </summary>
    public enum JurisdictionType
    {
        /// <summary>
        /// Country
        /// </summary>
        Country,

        /// <summary>
        /// Deprecated
        /// </summary>
        Composite,

        /// <summary>
        /// State
        /// </summary>
        State,

        /// <summary>
        /// County
        /// </summary>
        County,

        /// <summary>
        /// City
        /// </summary>
        City,

        /// <summary>
        /// Special Tax Jurisdiction
        /// </summary>
        Special,

    }
}