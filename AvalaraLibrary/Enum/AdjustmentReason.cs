using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    /// <summary>
    /// Indicates the type of adjustment that was performed on a transaction
    /// </summary>
    public enum AdjustmentReason
    {
        /// <summary>
        /// The transaction has not been adjusted
        /// </summary>
        NotAdjusted,

        /// <summary>
        /// A sourcing issue existed which caused the transaction to be adjusted
        /// </summary>
        SourcingIssue,

        /// <summary>
        /// Transaction was adjusted to reconcile it with a general ledger
        /// </summary>
        ReconciledWithGeneralLedger,

        /// <summary>
        /// Transaction was adjusted after an exemption certificate was applied
        /// </summary>
        ExemptCertApplied,

        /// <summary>
        /// Transaction was adjusted when the price of an item changed
        /// </summary>
        PriceAdjusted,

        /// <summary>
        /// Transaction was adjusted due to a product return
        /// </summary>
        ProductReturned,

        /// <summary>
        /// Transaction was adjusted due to a product exchange
        /// </summary>
        ProductExchanged,

        /// <summary>
        /// Transaction was adjusted due to bad or uncollectable debt
        /// </summary>
        BadDebt,

        /// <summary>
        /// Transaction was adjusted for another reason not specified
        /// </summary>
        Other,

        /// <summary>
        /// Offline
        /// </summary>
        Offline,

    }
}
