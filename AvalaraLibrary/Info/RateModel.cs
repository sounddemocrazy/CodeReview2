using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    /// <summary>
    /// Indicates one element of a sales tax rate.
    /// </summary>
    public class RateModel
    {
        /// <summary>
        /// The sales tax rate for general tangible personal property in this jurisdiction.
        /// </summary>
        public Decimal? rate { get; set; }

        /// <summary>
        /// A readable name of the tax or taxing jurisdiction related to this tax rate.
        /// </summary>
        public String name { get; set; }

        /// <summary>
        /// The type of jurisdiction associated with this tax rate.
        /// </summary>
        public JurisdictionType? type { get; set; }


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
