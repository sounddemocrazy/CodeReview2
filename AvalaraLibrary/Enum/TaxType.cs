using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    /// <summary>
    /// Tax type
    /// </summary>
    public enum TaxType
    {
        /// <summary>
        /// Match Lodging tax type
        /// </summary>
        Lodging,

        /// <summary>
        /// Match bottle tax type
        /// </summary>
        Bottle,

        /// <summary>
        /// Consumer Use Tax
        /// </summary>
        ConsumerUse,

        /// <summary>
        /// Medical Excise Tax
        /// </summary>
        Excise,

        /// <summary>
        /// Fee - PIFs (Public Improvement Fees) and RSFs (Retail Sales Fees)
        /// </summary>
        Fee,

        /// <summary>
        /// VAT/GST Input tax
        /// </summary>
        Input,

        /// <summary>
        /// VAT/GST Nonrecoverable Input tax
        /// </summary>
        Nonrecoverable,

        /// <summary>
        /// VAT/GST Output tax
        /// </summary>
        Output,

        /// <summary>
        /// Rental Tax
        /// </summary>
        Rental,

        /// <summary>
        /// Sales tax
        /// </summary>
        Sales,

        /// <summary>
        /// Use tax
        /// </summary>
        Use,

    }
}
