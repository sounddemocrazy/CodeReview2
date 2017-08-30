using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    /// <summary>
    /// TaxOverrideTypeId
    /// </summary>
    public enum TaxOverrideTypeId
    {
        /// <summary>
        /// No override
        /// </summary>
        None,

        /// <summary>
        /// Tax was overriden by the client
        /// </summary>
        TaxAmount,

        /// <summary>
        /// Entity exemption was ignored (e.g. item was consumed)
        /// </summary>
        Exemption,

        /// <summary>
        /// Only the tax date was overriden
        /// </summary>
        TaxDate,

        /// <summary>
        /// To support Consumer Use Tax
        /// </summary>
        AccruedTaxAmount,

        /// <summary>
        /// Derive the taxable amount from the tax amount
        /// </summary>
        DeriveTaxable,

    }
}
