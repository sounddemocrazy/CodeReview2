﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    /// <summary>
    /// Represents information about location types stored in a line
    /// </summary>
    public class TransactionLineLocationTypeModel
    {
        /// <summary>
        /// The unique ID number of this line location address model
        /// </summary>
        public Int64? documentLineLocationTypeId { get; set; }

        /// <summary>
        /// The unique ID number of the document line associated with this line location address model
        /// </summary>
        public Int64? documentLineId { get; set; }

        /// <summary>
        /// The address ID corresponding to this model
        /// </summary>
        public Int64? documentAddressId { get; set; }

        /// <summary>
        /// The location type code corresponding to this model
        /// </summary>
        public String locationTypeCode { get; set; }


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
