﻿using Newtonsoft.Json;
using AvalaraLibrary.Avalara;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    /// <summary>
    /// An address used within this transaction.
    /// </summary>
    public class TransactionAddressModel
    {
        /// <summary>
        /// The unique ID number of this address.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The unique ID number of the document to which this address belongs.
        /// </summary>
        public Int64? transactionId { get; set; }

        /// <summary>
        /// The boundary level at which this address was validated.
        /// </summary>
        public BoundaryLevel? boundaryLevel { get; set; }

        /// <summary>
        /// The first line of the address.
        /// </summary>
        public String line1 { get; set; }

        /// <summary>
        /// The second line of the address.
        /// </summary>
        public String line2 { get; set; }

        /// <summary>
        /// The third line of the address.
        /// </summary>
        public String line3 { get; set; }

        /// <summary>
        /// The city for the address.
        /// </summary>
        public String city { get; set; }

        /// <summary>
        /// The region, state, or province for the address.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// The postal code or zip code for the address.
        /// </summary>
        public String postalCode { get; set; }

        /// <summary>
        /// The country for the address.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// The unique ID number of the tax region for this address.
        /// </summary>
        public Int32? taxRegionId { get; set; }

        /// <summary>
        /// Latitude for this address (CALC - 13394)
        /// </summary>
        public String latitude { get; set; }

        /// <summary>
        /// Longitude for this address (CALC - 13394)
        /// </summary>
        public String longitude { get; set; }


        /// <summary>
        /// Convert this object to a JSON string of itself
        /// </summary>
        /// <returns>A JSON string of this object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings() { Formatting = Formatting.Indented });
        }
    }
}
