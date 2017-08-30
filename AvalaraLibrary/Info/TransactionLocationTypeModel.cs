using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    /// <summary>
    /// Information about a location type
    /// </summary>
    public class TransactionLocationTypeModel
    {
        /// <summary>
        /// Location type ID for this location type in transaction
        /// </summary>
        public Int64? documentLocationTypeId { get; set; }

        /// <summary>
        /// Transaction ID
        /// </summary>
        public Int64? documentId { get; set; }

        /// <summary>
        /// Address ID for the transaction
        /// </summary>
        public Int64? documentAddressId { get; set; }

        /// <summary>
        /// Location type code
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
