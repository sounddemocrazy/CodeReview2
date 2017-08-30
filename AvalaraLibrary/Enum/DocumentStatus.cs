﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    /// <summary>
    /// Document Status
    /// </summary>
    public enum DocumentStatus
    {
        /// <summary>
        /// Temporary document not saved (SalesOrder, PurchaseOrder)
        /// </summary>
        Temporary,

        /// <summary>
        /// Saved document (SalesInvoice or PurchaseInvoice) ready to be posted
        /// </summary>
        Saved,

        /// <summary>
        /// A posted document (not committed)
        /// </summary>
        Posted,

        /// <summary>
        /// A posted document that has been committed
        /// </summary>
        Committed,

        /// <summary>
        /// A Committed document that has been cancelled
        /// </summary>
        Cancelled,

        /// <summary>
        /// A document that has been adjusted
        /// </summary>
        Adjusted,

        /// <summary>
        /// A document which is in Queue status and processed later
        /// </summary>
        Queued,

        /// <summary>
        /// A document which is Pending for Approval
        /// </summary>
        PendingApproval,

        /// <summary>
        /// Any status (for searching)
        /// </summary>
        Any,

    }
}
