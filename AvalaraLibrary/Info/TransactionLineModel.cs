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
    /// One line item on this transaction.
    /// </summary>
    public class TransactionLineModel
    {
        /// <summary>
        /// The unique ID number of this transaction line item.
        /// </summary>
        public Int64? id { get; set; }

        /// <summary>
        /// The unique ID number of the transaction to which this line item belongs.
        /// </summary>
        public Int64? transactionId { get; set; }

        /// <summary>
        /// The line number or code indicating the line on this invoice or receipt or document.
        /// </summary>
        public String lineNumber { get; set; }

        /// <summary>
        /// The unique ID number of the boundary override applied to this line item.
        /// </summary>
        public Int32? boundaryOverrideId { get; set; }

        /// <summary>
        /// The customer usage type for this line item. Usage type often affects taxability rules.
        /// </summary>
        public String customerUsageType { get; set; }

        /// <summary>
        /// A description of the item or service represented by this line.
        /// </summary>
        public String description { get; set; }

        /// <summary>
        /// The unique ID number of the destination address where this line was delivered or sold.
        /// In the case of a point-of-sale transaction, the destination address and origin address will be the same.
        /// In the case of a shipped transaction, they will be different.
        /// </summary>
        public Int64? destinationAddressId { get; set; }

        /// <summary>
        /// The unique ID number of the origin address where this line was delivered or sold.
        /// In the case of a point-of-sale transaction, the origin address and destination address will be the same.
        /// In the case of a shipped transaction, they will be different.
        /// </summary>
        public Int64? originAddressId { get; set; }

        /// <summary>
        /// The amount of discount that was applied to this line item. This represents the difference between list price and sale price of the item.
        /// In general, a discount represents money that did not change hands; tax is calculated on only the amount of money that changed hands.
        /// </summary>
        public Decimal? discountAmount { get; set; }

        /// <summary>
        /// The type of discount, if any, that was applied to this line item.
        /// </summary>
        public Int32? discountTypeId { get; set; }

        /// <summary>
        /// The amount of this line item that was exempt.
        /// </summary>
        public Decimal? exemptAmount { get; set; }

        /// <summary>
        /// The unique ID number of the exemption certificate that applied to this line item.
        /// </summary>
        public Int32? exemptCertId { get; set; }

        /// <summary>
        /// If this line item was exempt, this string contains the word `Exempt`.
        /// </summary>
        public String exemptNo { get; set; }

        /// <summary>
        /// True if this item is taxable.
        /// </summary>
        public Boolean? isItemTaxable { get; set; }

        /// <summary>
        /// True if this item is a Streamlined Sales Tax line item.
        /// </summary>
        public Boolean? isSSTP { get; set; }

        /// <summary>
        /// The code string of the item represented by this line item.
        /// </summary>
        public String itemCode { get; set; }

        /// <summary>
        /// The total amount of the transaction, including both taxable and exempt. This is the total price for all items.
        /// To determine the individual item price, divide this by quantity.
        /// </summary>
        public Decimal? lineAmount { get; set; }

        /// <summary>
        /// The quantity of products sold on this line item.
        /// </summary>
        public Decimal? quantity { get; set; }

        /// <summary>
        /// A user-defined reference identifier for this transaction line item.
        /// </summary>
        public String ref1 { get; set; }

        /// <summary>
        /// A user-defined reference identifier for this transaction line item.
        /// </summary>
        public String ref2 { get; set; }

        /// <summary>
        /// The date when this transaction should be reported. By default, all transactions are reported on the date when the actual transaction took place.
        /// In some cases, line items may be reported later due to delayed shipments or other business reasons.
        /// </summary>
        public DateTime? reportingDate { get; set; }

        /// <summary>
        /// The revenue account number for this line item.
        /// </summary>
        public String revAccount { get; set; }

        /// <summary>
        /// Indicates whether this line item was taxed according to the origin or destination.
        /// </summary>
        public Sourcing? sourcing { get; set; }

        /// <summary>
        /// The amount of tax generated for this line item.
        /// </summary>
        public Decimal? tax { get; set; }

        /// <summary>
        /// The taxable amount of this line item.
        /// </summary>
        public Decimal? taxableAmount { get; set; }

        /// <summary>
        /// The tax calculated for this line by Avalara. If the transaction was calculated with a tax override, this amount will be different from the "tax" value.
        /// </summary>
        public Decimal? taxCalculated { get; set; }

        /// <summary>
        /// The code string for the tax code that was used to calculate this line item.
        /// </summary>
        public String taxCode { get; set; }

        /// <summary>
        /// The unique ID number for the tax code that was used to calculate this line item.
        /// </summary>
        public Int32? taxCodeId { get; set; }

        /// <summary>
        /// The date that was used for calculating tax amounts for this line item. By default, this date should be the same as the document date.
        /// In some cases, for example when a consumer returns a product purchased previously, line items may be calculated using a tax date in the past
        /// so that the consumer can receive a refund for the correct tax amount that was charged when the item was originally purchased.
        /// </summary>
        public DateTime? taxDate { get; set; }

        /// <summary>
        /// The tax engine identifier that was used to calculate this line item.
        /// </summary>
        public String taxEngine { get; set; }

        /// <summary>
        /// If a tax override was specified, this indicates the type of tax override.
        /// </summary>
        public TaxOverrideTypeId? taxOverrideType { get; set; }

        /// <summary>
        /// VAT business identification number used for this transaction.
        /// </summary>
        public String businessIdentificationNo { get; set; }

        /// <summary>
        /// If a tax override was specified, this indicates the amount of tax that was requested.
        /// </summary>
        public Decimal? taxOverrideAmount { get; set; }

        /// <summary>
        /// If a tax override was specified, represents the reason for the tax override.
        /// </summary>
        public String taxOverrideReason { get; set; }

        /// <summary>
        /// True if tax was included in the purchase price of the item.
        /// </summary>
        public Boolean? taxIncluded { get; set; }

        /// <summary>
        /// Optional: A list of tax details for this line item. To fetch this list, add the query string "?$include=Details" to your URL.
        /// </summary>
        public List<TransactionLineDetailModel> details { get; set; }

        /// <summary>
        /// Optional: A list of location types for this line item. To fetch this list, add the query string "?$include=LineLocationTypes" to your URL.
        /// </summary>
        public List<TransactionLineLocationTypeModel> lineLocationTypes { get; set; }

        /// <summary>
        /// Contains a list of extra parameters that were set when the transaction was created.
        /// </summary>
        public Dictionary<string, string> parameters { get; set; }


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
