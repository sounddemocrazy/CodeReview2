﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{ 
    /// <summary>
    /// Represents a base address element.
    /// </summary>
    public class AddressInfo
    {
        /// <summary>
        /// First line of the street address
        /// </summary>
        public String line1 { get; set; }

        /// <summary>
        /// Second line of the street address
        /// </summary>
        public String line2 { get; set; }

        /// <summary>
        /// Third line of the street address
        /// </summary>
        public String line3 { get; set; }

        /// <summary>
        /// City component of the address
        /// </summary>
        public String city { get; set; }

        /// <summary>
        /// State / Province / Region component of the address.
        /// </summary>
        public String region { get; set; }

        /// <summary>
        /// Two character ISO 3166 Country Code. Call `ListCountries` for a list of ISO 3166 country codes.
        /// </summary>
        public String country { get; set; }

        /// <summary>
        /// Postal Code / Zip Code component of the address.
        /// </summary>
        public String postalCode { get; set; }

        /// <summary>
        /// Geospatial latitude measurement, in Decimal Degrees floating point format.
        /// </summary>
        public Decimal? latitude { get; set; }

        /// <summary>
        /// Geospatial longitude measurement, in Decimal Degrees floating point format.
        /// </summary>
        public Decimal? longitude { get; set; }


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
